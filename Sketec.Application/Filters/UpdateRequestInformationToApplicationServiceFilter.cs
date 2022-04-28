using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;
using Sketec.Application.Interfaces;
using Sketec.Core.Interfaces;
using Sketec.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Sketec.Application.Filters
{
    public class UpdateRequestInformationToApplicationServiceFilter : IActionFilter
    {
        private IServiceProvider service;
        public UpdateRequestInformationToApplicationServiceFilter(IServiceProvider service)
        {
            this.service = service;
        }
        public void OnActionExecuted(ActionExecutedContext context)
        {

        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            var user = (ClaimsIdentity)context.HttpContext.User.Identity;
            string username = "admin";
            if (service != null && user.IsAuthenticated)
            {
                username = user.Name;
            }
            var fields = context.Controller.GetType().GetFields();
            foreach (var field in fields)
            {
                var info = field.FieldType.GetInterface("IApplicationService");
                if (info != null)
                {
                    var role = user.FindFirst(user.RoleClaimType);
                    var email = user.FindFirst(ClaimTypes.Email);
                    var service = (IApplicationService)field.GetValue(context.Controller);
                    service.UserName = username;

                    var name = user.FindFirst("name");
                    service.Name = name?.Value;
                    service.Role = role?.Value;
                    service.Team = user.Claims.FirstOrDefault(m => m.Type == "team")?.Value;
                    service.Email = email?.Value;
                    service.Section = user.Claims.FirstOrDefault(m => m.Type == "section")?.Value;
                    service.Department = user.Claims.FirstOrDefault(m => m.Type == "department")?.Value;
                }
            }

            var uows = service.GetServices<IWCUnitOfWork>();
            foreach (var uow in uows)
            {
                uow.Username = username;
            }
        }
    }
}
