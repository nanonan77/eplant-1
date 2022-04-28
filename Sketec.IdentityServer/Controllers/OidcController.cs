using IdentityServer4.Models;
using IdentityServer4.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Sketec.IdentityServer.Resources.Oidc;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Sketec.IdentityServer.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OidcController : Controller
    {
        IIdentityServerInteractionService interactionService;
        UserManager<IdentityUser> userManager;
        public OidcController(IIdentityServerInteractionService interactionService, UserManager<IdentityUser> userManager)
        {
            this.interactionService = interactionService;
            this.userManager = userManager;
        }

        [HttpGet("Error/{id}")]
        public async Task<ErrorMessage> Error(string id)
        {
            var ctx = await interactionService.GetErrorContextAsync(id);
            return ctx;
        }

        [HttpPost("Logout")]
        public async Task<LogoutRequest> Logout()
        {
            var id = await interactionService.CreateLogoutContextAsync();
            if (!string.IsNullOrEmpty(id))
            {
                var context = await interactionService.GetLogoutContextAsync(id);
                return context;
            }

            return null;
        }

        [HttpGet("Logout/{id}")]
        public async Task<LogoutRequest> Logout(string id)
        {
            var ctx = await interactionService.GetLogoutContextAsync(id);
            return ctx;
        }

        [HttpGet("Authorization")]
        [Authorize]
        public async Task<AuthorizationConsentRequest> Authorization(string returnUrl)
        {
            var ctx = await interactionService.GetAuthorizationContextAsync(returnUrl);
            if (ctx != null)
            {

                var identity = (ClaimsIdentity)this.User.Identity;
                var sub = identity.Claims.FirstOrDefault(f => f.Type == "sub");
                if (sub == null)
                    return null;
                var account = await userManager.FindByIdAsync(sub.Value);
                if (account == null)
                    return null;

                return new AuthorizationConsentRequest
                {
                    ClientId = ctx.Client.ClientId,
                    ClientName = ctx.Client.ClientName,
                    ClientUri = ctx.Client.ClientUri,
                    Description = ctx.Client.Description,
                    LogoUri = ctx.Client.LogoUri,
                    ValidatedResources = ctx.ValidatedResources,
                    Email = account.Email,
                    Username = account.UserName
                };
            }


            return null;
        }

        [HttpPost("Consent")]
        [Authorize]
        public async Task<IActionResult> SubmitConsent(SubmitConsentRequest request)
        {
            if (request == null)
                return BadRequest();

            var ctx = await interactionService.GetAuthorizationContextAsync(request.ReturnUrl);
            if (ctx == null)
                return BadRequest("invalid_returnurl");

            if (!ctx.ValidatedResources.Succeeded)
                return BadRequest("invalid_transaction");

            if (request.Accept)
            {
                var consent = new ConsentResponse()
                {
                    Description = ctx.Client.Description,
                    RememberConsent = ctx.Client.AllowRememberConsent && true,
                    ScopesValuesConsented = ctx.ValidatedResources.RawScopeValues
                };

                await interactionService.GrantConsentAsync(ctx, consent);
            }
            else
            {
                var consent = new ConsentResponse()
                {
                    Description = ctx.Client.Description,
                    RememberConsent = ctx.Client.AllowRememberConsent && true,
                    ScopesValuesConsented = ctx.ValidatedResources.RawScopeValues,
                    Error = AuthorizationError.AccessDenied,
                };
                await interactionService.GrantConsentAsync(ctx, consent);
            }
            ctx = await interactionService.GetAuthorizationContextAsync(request.ReturnUrl);

            return Ok();
        }
    }
}
