using Sketec.Application.Filters;
using Sketec.Application.Resources.Gdc;
using Sketec.Application.Resources.Users;
using Sketec.Core.Specifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sketec.Application.Interfaces
{
    public interface IUserService : IApplicationService
    {
        Task<UserResultDto> GetUserInfo(string username);
        Task<UserResultDto> GetUserInfo(int id);
        Task<EmployeeInfoByADAccount> GetEmployeeInfoByADAccount(string userName);
        //Task CreateUser(string username, string email, bool? isLocal);
        Task<IEnumerable<UserResultDto>> GetUserData(UserFilter filter);
        Task UpdateInfo();
        Task CreateUserInfo(UserCreateRequest request);
        Task UpdateUserInfo(int id, UserUpdateRequest request, BindPropertyCollection httpPatchBindProperty = null);

        Task<IEnumerable<RoleActivityDto>> GetRoleActivity(string role);
    }
}
