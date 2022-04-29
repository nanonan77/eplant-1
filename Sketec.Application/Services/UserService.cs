using AutoMapper;
using EnsureThat;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Sketec.Application.Filters;
using Sketec.Application.Interfaces;
using Sketec.Application.Resources.Gdc;
using Sketec.Application.Resources.Users;
using Sketec.Application.Shared;
using Sketec.Application.Utils;
using Sketec.Core.Domains;
using Sketec.Core.Interfaces;
using Sketec.Core.Resources.Email;
using Sketec.Core.Specifications;
using Sketec.Core.Specifications.Users;
using Sketec.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sketec.Application.Services
{
    public class UserService : ApplicationService, IUserService
    {
        private IWCRepository<User> userRepo;
        private IMapper mapper;
        IGdcService gdcService;
        IEmailService emailService;
        IWCUnitOfWork uow;
        IWCRepository<RoleActivity> roleActivityRepo;
        UserManager<IdentityUser> userManager;
        ApplicationSettings applicationSettings;

        public UserService(
            IMapper mapper,
            IWCRepository<User> userRepo,
            IWCRepository<RoleActivity> roleActivityRepo,
            IGdcService gdcService,
            IEmailService emailService,
            IWCUnitOfWork uow, 
            IOptions<ApplicationSettings> appOptions,
            UserManager<IdentityUser> userManager
            )
        {
            this.mapper = mapper;
            this.userRepo = userRepo;
            this.gdcService = gdcService;
            this.uow = uow;
            this.userManager = userManager;
            this.emailService = emailService;
            applicationSettings = appOptions.Value;
            this.roleActivityRepo = roleActivityRepo;
        }

        public async Task<UserResultDto> GetUserInfo(string username)
        {
            EnsureArg.IsNotNullOrWhiteSpace(username, nameof(username));
            var spec = new UserByUsernameSpec(username);
            var user = await userRepo.GetBySpecAsync(spec);

            return mapper.Map<UserResultDto>(user);
        }

        public async Task<EmployeeInfoByADAccount> GetEmployeeInfoByADAccount(string userName)
        {
            return await gdcService.GetEmployeeInfoByADAccount(userName);
        }

        //public async Task CreateUser(string username, string email, bool? isLocal)
        //{
        //    var user = await GetUserInfo(username);
        //    if(user == null)
        //    {
        //        var data = new User(username)
        //        {
        //            Email = email,
        //            IsLocal = isLocal ?? false,
        //        };
        //        var gdc = await GetEmployeeInfoByADAccount(username);
        //        if(gdc != null)
        //        {
        //            data.EmployeeId = gdc.EmployeeId;
        //            data.EmpCode = gdc.EmpCode;
        //            data.OrganizationId = gdc.OrganizationId;
        //            data.OrganizationName = gdc.OrganizationName;
        //            data.AdAcount = gdc.AdAcount;
        //            data.T_FullName = gdc.T_FullName;
        //            data.E_FullName = gdc.E_FullName;
        //            data.NickName = gdc.NickName;
        //            data.PositionName = gdc.PositionName;
        //            data.BusinessUnit = gdc.BusinessUnit;
        //            data.CompanyCode = gdc.CompanyCode;
        //            data.CompanyName = gdc.CompanyName;
        //            data.Div_Name = gdc.Div_Name;
        //            data.Dep_Name = gdc.Dep_Name;
        //            data.SubDep_Name = gdc.SubDep_Name;
        //            data.Sec_Name = gdc.Sec_Name;
        //            data.Location = gdc.Location;
        //            data.EmployeeOrganizationRelationTypeId = gdc.EmployeeOrganizationRelationTypeId;
        //            data.EmpOrgLevel = gdc.EmpOrgLevel;
        //            data.CctR_Dept = gdc.CctR_Dept;
        //            data.CctR_Over = gdc.CctR_Over;
        //            data.ManagerEmail = gdc.ManagerEmail;
        //            data.Tel = gdc.Tel;
        //            data.MobileNo = gdc.MobileNo;
        //            data.IsLocal = false;
        //        }

        //        await userRepo.AddAsync(data); 
        //        await uow.SaveAsync();
        //    }
        //}

        public async Task<UserResultDto> GetUserInfo(int id)
        {
            var user = await userRepo.GetByIdAsync(id);
            var result = mapper.Map<UserResultDto>(user);
            return result;
        }

        public async Task<IEnumerable<UserResultDto>> GetUserData(UserFilter filter)
        {
            var spec = new UserSearchSpec(filter ?? new UserFilter());
            var list = await userRepo.ListAsync(spec);

            return mapper.Map<IEnumerable<User>, IEnumerable<UserResultDto>>(list);
        }

        public async Task CreateUserInfo(UserCreateRequest request)
        {
            Ensure.Any.IsNotNull(request, "UserCreateRequest");
            var account = new IdentityUser
            {
                UserName = request.Username,
                Email = request.Email,
                EmailConfirmed = true,
            };
            var pass = "P@ssw0rd";
            if (request.IsLocal)
                pass = SketecUtils.GenerateAccountPassword();

            var result = await userManager.CreateAsync(account, pass);
            if (result.Succeeded)
            {
                var config = new User(request.Username)
                {
                    EmployeeId = request.EmployeeId,
                    EmpCode = request.EmpCode,
                    OrganizationId = request.OrganizationId,
                    OrganizationName = request.OrganizationName,
                    AdAcount = request.AdAcount,
                    T_FullName = request.T_FullName,
                    E_FullName = request.E_FullName,
                    NickName = request.NickName,
                    PositionName = request.PositionName,
                    BusinessUnit = request.BusinessUnit,
                    CompanyCode = request.CompanyCode,
                    CompanyName = request.CompanyName,
                    Div_Name = request.Div_Name,
                    Dep_Name = request.Dep_Name,
                    SubDep_Name = request.SubDep_Name,
                    Sec_Name = request.Sec_Name,
                    Email = request.Email,
                    Location = request.Location,
                    EmployeeOrganizationRelationTypeId = request.EmployeeOrganizationRelationTypeId,
                    EmpOrgLevel = request.EmpOrgLevel,
                    CctR_Dept = request.CctR_Dept,
                    CctR_Over = request.CctR_Over,
                    ManagerEmail = request.ManagerEmail,
                    Tel = request.Tel,
                    MobileNo = request.MobileNo,
                    Team = request.Team,
                    Role = request.Role,
                    IsLocal = request.IsLocal,
                    IsForceChangePassword = request.IsLocal
                };
                await userRepo.AddAsync(config);
                await uow.SaveAsync();

                if (request.IsLocal)
                {
                    var content = $"เรียน {request.E_FullName}<br /><br />";
                    content += $"คุณสามารถเข้าใช้งาน e-Plantation ได้แล้ว<br />";
                    content += $"Username : {request.Username}<br />";
                    content += $"Your password : {pass}<br />";
                    content += $"<a href=\"{applicationSettings.BaseUrl}\">Click here to login</a><br /><br />";
                    content += $"Best regards,<br />";
                    content += $"e-Plantation Admin";
                    await emailService.SendEmailAsync(new SendEmailRequest
                    {
                        Subject = "[New User] แจ้งผู้ใช้งานใหม่",
                        EmailsTo = new string[] { request.Email },
                        Content = content
                    });
                }
            }
            else
            {
                throw new Exception("User is exists!");
            }
        }

        public async Task UpdateUserInfo(int id, Core.Specifications.UserUpdateRequest request, BindPropertyCollection httpPatchBindProperty = null)
        {
            Ensure.Any.IsNotNull(request, "MasterConfigurationUpdateRequest");

            var user = await userRepo.GetByIdAsync(id);
            if (user != null)
            {
                if (httpPatchBindProperty == null || httpPatchBindProperty.HasFlag(nameof(request.E_FullName)))
                    user.E_FullName = request.E_FullName;

                if (httpPatchBindProperty == null || httpPatchBindProperty.HasFlag(nameof(request.PositionName)))
                    user.PositionName = request.PositionName;

                if (httpPatchBindProperty == null || httpPatchBindProperty.HasFlag(nameof(request.Dep_Name)))
                    user.Dep_Name = request.Dep_Name;

                if (httpPatchBindProperty == null || httpPatchBindProperty.HasFlag(nameof(request.Sec_Name)))
                    user.Sec_Name = request.Sec_Name;

                if (httpPatchBindProperty == null || httpPatchBindProperty.HasFlag(nameof(request.Email)))
                    user.Email = request.Email;

                if (httpPatchBindProperty == null || httpPatchBindProperty.HasFlag(nameof(request.ManagerEmail)))
                    user.ManagerEmail = request.ManagerEmail;

                if (httpPatchBindProperty == null || httpPatchBindProperty.HasFlag(nameof(request.Team)))
                    user.Team = request.Team;

                if (httpPatchBindProperty == null || httpPatchBindProperty.HasFlag(nameof(request.Role)))
                    user.Role = request.Role;

                if (httpPatchBindProperty == null || httpPatchBindProperty.HasFlag(nameof(request.IsLocal)))
                    user.IsLocal = request.IsLocal;

                if (httpPatchBindProperty == null || httpPatchBindProperty.HasFlag(nameof(request.IsActive)))
                    user.IsActive = request.IsActive;

                await uow.SaveAsync();
            }
        }


        public async Task UpdateInfo()
        {
            await SyncDataFromGDC();
            await UpdateReportTo2();
            await UpdateReportTo3();
        }

        public async Task SyncDataFromGDC()
        {
            var user = await GetUserData(new UserFilter { IsLocal = false, IsActive = true });
            foreach (var item in user)
            {
                var gdc = await GetEmployeeInfoByADAccount(item.Username);
                if (gdc != null)
                {
                    var data = await userRepo.GetByIdAsync(item.Id);
                    data.EmployeeId = gdc.EmployeeId;
                    data.EmpCode = gdc.EmpCode;
                    data.OrganizationId = gdc.OrganizationId;
                    data.OrganizationName = gdc.OrganizationName;
                    data.AdAcount = gdc.AdAcount;
                    data.T_FullName = gdc.T_FullName;
                    data.E_FullName = gdc.E_FullName;
                    data.NickName = gdc.NickName;
                    data.PositionName = gdc.PositionName;
                    data.BusinessUnit = gdc.BusinessUnit;
                    data.CompanyCode = gdc.CompanyCode;
                    data.CompanyName = gdc.CompanyName;
                    data.Div_Name = gdc.Div_Name;
                    data.Dep_Name = gdc.Dep_Name;
                    data.SubDep_Name = gdc.SubDep_Name;
                    data.Sec_Name = gdc.Sec_Name;
                    data.Location = gdc.Location;
                    data.EmployeeOrganizationRelationTypeId = gdc.EmployeeOrganizationRelationTypeId;
                    data.EmpOrgLevel = gdc.EmpOrgLevel;
                    data.CctR_Dept = gdc.CctR_Dept;
                    data.CctR_Over = gdc.CctR_Over;
                    data.ManagerEmail = gdc.ManagerEmail;
                    data.Tel = gdc.Tel;
                    data.MobileNo = gdc.MobileNo;
                }
            }
            await uow.SaveAsync();
        }

        public async Task UpdateReportTo2()
        {
            var user = await GetUserData(new UserFilter { IsLocal = false, IsActive = true });
            foreach (var item in user.GroupBy(x => x.ManagerEmail))
            {
                var manager = user.FirstOrDefault(x => x.Email == item.Key);
                if(manager != null)
                {
                    foreach(var item2 in item)
                    {
                        var data = await userRepo.GetByIdAsync(item2.Id);
                        data.ReportToEmail2 = manager.ManagerEmail;
                    }
                }
            }
            await uow.SaveAsync();
        }
        public async Task UpdateReportTo3()
        {
            var user = await GetUserData(new UserFilter { IsLocal = false, IsActive = true });
            foreach (var item in user.GroupBy(x => x.ReportToEmail2))
            {
                var manager = user.FirstOrDefault(x => x.Email == item.Key);
                if (manager != null)
                {
                    foreach (var item2 in item)
                    {
                        var data = await userRepo.GetByIdAsync(item2.Id);
                        data.ReportToEmail3 = manager.ManagerEmail;
                    }
                }
            }
            await uow.SaveAsync();
        }

        public async Task<IEnumerable<RoleActivityDto>> GetRoleActivity(string role)
        {
            var spec = new RoleActivitySpec(role);
            var list = await roleActivityRepo.ListAsync(spec);

            return mapper.Map<IEnumerable<RoleActivity>, IEnumerable<RoleActivityDto>>(list);
        }
    }
}
