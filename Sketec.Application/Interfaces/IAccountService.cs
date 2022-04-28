using Microsoft.AspNetCore.Identity;
using Sketec.Application.Resources.Accounts;
using System.Threading.Tasks;

namespace Sketec.Application.Interfaces
{
    public interface IAccountService : IApplicationService
    {
        Task ResetPasswordAsync(string email);
        Task<IdentityResult> ChangePasswordWithTokenAsync(ChangePasswordWithTokenRequest request);
        Task<IdentityResult> ChangePassword(ChangePassword request);
        Task<IdentityResult> Register(RegisterRequest request);
    }
}
