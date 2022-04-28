using IdentityServer4.AspNetIdentity;
using IdentityServer4.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Sketec.Application.Interfaces;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace Sketec.IdentityServer.Services
{
    public class SketecProfileService : ProfileService<IdentityUser>
    {
        private IUserService userService;
        public SketecProfileService(
            UserManager<IdentityUser> userManager,
            IUserClaimsPrincipalFactory<IdentityUser> claimsFactory,
            ILogger<ProfileService<IdentityUser>> logger,
            IUserService userService)
            : base(userManager, claimsFactory, logger)
        {
            this.userService = userService;
        }

        protected override Task GetProfileDataAsync(ProfileDataRequestContext context, IdentityUser user)
        {
            return base.GetProfileDataAsync(context, user);
        }

        protected override async Task<ClaimsPrincipal> GetUserClaimsAsync(IdentityUser user)
        {
            var principal = await base.GetUserClaimsAsync(user);
            var identity = (ClaimsIdentity)principal.Identity;

            var userInfo = await userService.GetUserInfo(user.UserName);
            if (userInfo != null)
            {
                var nameClaim = identity.FindFirst("name");
                if (nameClaim != null)
                {
                    identity.RemoveClaim(nameClaim);
                }

                identity.AddClaim(new Claim("name", $"{userInfo.E_FullName}".Trim()));
                identity.AddClaim(new Claim("role", $"{userInfo.Role}"));
                identity.AddClaim(new Claim("team", $"{userInfo.Team}"));
                identity.AddClaim(new Claim("email", $"{userInfo.Email}"));
                identity.AddClaim(new Claim("section", $"{userInfo.Sec_Name}"));
                identity.AddClaim(new Claim("department", $"{userInfo.Dep_Name}"));
                identity.AddClaim(new Claim("isForceChangePassword", $"{userInfo.IsForceChangePassword}"));

                if (!string.IsNullOrWhiteSpace(userInfo.Role))
                {
                    var role = await userService.GetRoleActivity(userInfo.Role);
                    if (role.Any())
                    {
                        var roleActivity = role.Select(o => new
                        {
                            o.Page,
                            o.Activity
                        });
                        identity.AddClaim(new Claim("role_activity", $"{JsonConvert.SerializeObject(roleActivity)}"));
                    }
                }
            }


            return principal;
        }
    }
}
