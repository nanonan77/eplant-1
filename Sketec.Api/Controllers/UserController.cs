using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sketec.Application.Interfaces;
using Sketec.Application.Resources.Gdc;
using Sketec.Core.Specifications;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Sketec.Application.Filters;
using System.IO;
using System.IO.Compression;
using System.Linq;
using Sketec.Application.Resources;
using Sketec.Application.Resources.Users;
using Microsoft.AspNetCore.Identity;
using Sketec.Application.Resources.Accounts;

namespace Sketec.Api.Controllers
{
    [ApiController]
    [Authorize]
    [Route("user")]
    public class UserController : ControllerBase
    {
        IMapper mapper;
        public IUserService userService;
        public IAccountService accountService;
        public BindPropertyCollection httpPatchBindPropertyCollection;
        public UserController(IUserService userService, IAccountService accountService, IMapper mapper)
        {
            this.userService = userService;
            this.accountService = accountService;
            this.mapper = mapper;
        }


        
        [HttpGet("{userName}")]
        public Task<EmployeeInfoByADAccount> Get(string userName) => userService.GetEmployeeInfoByADAccount(userName);

        [HttpGet("{id:int}")]
        public Task<UserResultDto> GetUserInfo(int id) => userService.GetUserInfo(id);

        [HttpPost]
        public Task<IEnumerable<UserResultDto>> GetUserData(UserFilter filter) => userService.GetUserData(filter);

        [HttpGet("update-info")]
        public Task UpdateInfo() => userService.UpdateInfo();

        [HttpPost("create")]
        public Task CreateUserInfo(UserCreateRequest request) => userService.CreateUserInfo(request);

        [HttpPatch("{id:int}")]
        [HttpPatchBindProperty]
        public Task UpdateUserInfo(int id, UserUpdateRequest request) => userService.UpdateUserInfo(id, request, httpPatchBindPropertyCollection);

        [HttpPut("{id:int}")]
        public Task UpdateUser(int id, UserUpdateRequest request) => userService.UpdateUserInfo(id, request);


        [HttpPost("Change-Password")]
        public async Task<IdentityResult> ChangePasswordAsync(ChangePassword request)
        {
            var result = await accountService.ChangePassword(request);

            return result;
        }
    }
}
