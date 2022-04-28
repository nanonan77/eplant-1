using IdentityServer4;
using IdentityServer4.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using Newtonsoft.Json;
using Sketec.Application.Interfaces;
using Sketec.Application.Resources.Accounts;
using Sketec.Application.Utils;
using Sketec.IdentityServer.Resources.Accounts;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Sketec.IdentityServer.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AccountController : ControllerBase
    {
        IIdentityServerInteractionService interactionService;
        UserManager<IdentityUser> userManager;
        SignInManager<IdentityUser> signInManager;
        IAccountService accountService;
        IUserService userService;
        AuthenticationOptions authenticationOptions;
        public AccountController(
            IIdentityServerInteractionService interactionService
            , UserManager<IdentityUser> userManager
            , SignInManager<IdentityUser> signInManager
            , IAccountService accountService
            , IUserService userService
            , IOptions<AuthenticationOptions> authenticationOptions
            )
        {
            this.interactionService = interactionService;
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.accountService = accountService;
            this.authenticationOptions = authenticationOptions.Value;
            this.userService = userService;
        }

        [HttpGet("Info")]
        [Authorize]
        public async Task<IdentityUser> Info()
        {
            var user = await userManager.FindByEmailAsync(User.Identity.Name);
            return user;
        }

        [HttpPost("Register")]
        [ValidateAntiForgeryToken]
        public Task<IdentityResult> Register(RegisterRequest request)
        {
            request.Email = request.Email?.ToLower();
            request.Username = request.Username?.ToLower();
            request.IsLocal = true;
            return accountService.Register(request);
        }

        [HttpPost("Reset-Password")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ResetPasswordAsync(ResetPasswordRequest request)
        {
            await accountService.ResetPasswordAsync(request.Email);
            return Ok();
        }

        [HttpPost("Change-Password")]
        [ValidateAntiForgeryToken]
        public async Task<IdentityResult> ChangePasswordAsync(ChangePasswordWithTokenRequest request)
        {
            var result = await accountService.ChangePasswordWithTokenAsync(request);

            return result;
        }


        [HttpPost("Login")]
        [ValidateAntiForgeryToken]
        public async Task<Microsoft.AspNetCore.Identity.SignInResult> Login(LoginRequest request)
        {
            var signinResult = await signInManager.PasswordSignInAsync(request.Username, request.Password, request.Remember, true);

            if (!signinResult.Succeeded)
                return signinResult;
            return signinResult;
        }

        [HttpPost("Logout")]
        public async Task LogoutAsync()
        {
            await signInManager.SignOutAsync();
        }

        [HttpGet("Microsoft-Login")]
        public ActionResult MicrosoftLogin([FromQuery] ExternalLoginRequest loginRequest)
        {
            var props = new AuthenticationProperties();

            props.RedirectUri = "/Account/Microsoft-Login-Callback";

            if (!string.IsNullOrWhiteSpace(loginRequest.RedirectUri))
                props.RedirectUri += $"?RedirectUri={WebUtility.UrlEncode(loginRequest.RedirectUri)}";

            if (!string.IsNullOrWhiteSpace(loginRequest.LoginHint))
                props.Parameters.Add("login_hint", loginRequest.LoginHint);

            return Challenge(props, IdentityServerConfig.MicrosoftOpenIdScheme);
        }

        [HttpGet("Microsoft-Login-Callback")]
        public async Task<ActionResult> ExternalLoginCallback(string redirectUri)
        {
            var externalAuthenticated = await HttpContext.AuthenticateAsync(IdentityServerConstants.ExternalCookieAuthenticationScheme);
            if (!externalAuthenticated.Succeeded)
                return Ok("Invalid login.");

            //remove external cookie auth
            await HttpContext.SignOutAsync(IdentityServerConstants.ExternalCookieAuthenticationScheme);

            //get external principal
            var principal = externalAuthenticated.Principal;
            var identity = (ClaimsIdentity)principal.Identity;
            var email = identity.Name;

            var redirect = "/";
            var userInSystem = await userService.GetUserData(new Core.Specifications.UserFilter { Email = email.ToLower(), IsActive = true });
            if(userInSystem.Any())
            { 
                var user = await userManager.FindByEmailAsync(email);
                //auto create account if not exitst in system.
                if (user == null)
                {
                    // auto create user for external provider login
                    var createResult = await accountService.Register(new RegisterRequest
                    {
                        Email = email.ToLower(),
                        Username = email.Split("@")[0].ToLower(),
                        Password = "P@ssw0rd",///SketecUtils.GenerateAccountPassword()
                    });

                    if (!createResult.Succeeded)
                        return Ok(string.Join(',', createResult.Errors.Select(s => $"{s.Code} : {s.Description}")));
                    user = await userManager.FindByEmailAsync(email);
                }

                // create claimprincipal
                var userPrincipal = await signInManager.CreateUserPrincipalAsync(user);

                //add claim sid of microsoft provider for signout
                var claims = userPrincipal.Claims.ToList();
                if (externalAuthenticated.Properties.Items.TryGetValue(OpenIdConnectSessionProperties.SessionState, out string sid))
                    claims.Add(new Claim(JwtRegisteredClaimNames.Sid, sid));

                var data = userInSystem.FirstOrDefault();
                claims.Add(new Claim("team", data.Team == null ? "" : data.Team));
                claims.Add(new Claim("email", data.Email == null ? "" : data.Email));
                claims.Add(new Claim("role", data.Role == null ? "" : data.Role));
                claims.Add(new Claim("section", data.Sec_Name == null ? "" : data.Sec_Name));
                claims.Add(new Claim("department", data.Dep_Name == null ? "" : data.Dep_Name));
                claims.Add(new Claim("isForceChangePassword", data.IsForceChangePassword.ToString()));

                if (!string.IsNullOrWhiteSpace(data.Role))
                {
                    var role = await userService.GetRoleActivity(data.Role);
                    if(role.Any())
                        claims.Add(new Claim("role_activity", JsonConvert.SerializeObject(role.Select(o => new
                        {
                            o.Page,
                            o.Activity
                        }))));
                    
                }

                // use identity server extendsion for login with external id
                var identityServerUser = new IdentityServerUser(user.Id)
                {
                    DisplayName = userPrincipal.Identity.Name,
                    AuthenticationMethods = { OpenIdConnectDefaults.AuthenticationScheme },
                    AuthenticationTime = externalAuthenticated.Properties.IssuedUtc.Value.LocalDateTime,
                    IdentityProvider = "microsoft",
                    AdditionalClaims = claims
                };

                //set remember cookie
                externalAuthenticated.Properties.IsPersistent = true;

                // this extention will signin at DefaultAuthenticateScheme, so we nned to logout it first.
                await HttpContext.SignOutAsync(authenticationOptions.DefaultAuthenticateScheme);
                await HttpContext.SignInAsync(identityServerUser, externalAuthenticated.Properties);


                // redirect 
                if (!string.IsNullOrWhiteSpace(redirectUri))
                    redirect = redirectUri;
            }
            else
            {
                redirect = "/consent"; // Unauthorized
            }
            return Redirect(redirect);
        }
    }
}
