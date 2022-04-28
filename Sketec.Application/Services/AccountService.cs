using FluentValidation;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Options;
using Sketec.Application.Interfaces;
using Sketec.Application.Resources.Accounts;
using Sketec.Application.Shared;
using Sketec.Core.Interfaces;
using Sketec.Core.Resources.Email;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Sketec.Application.Services
{
    public class AccountService : ApplicationService, IAccountService
    {
        IEmailService emailService;
        IUserService userService;
        ApplicationSettings applicationSettings;
        UserManager<IdentityUser> userManager;
        public AccountService(IEmailService emailService, IOptions<ApplicationSettings> appOptions, UserManager<IdentityUser> userManager, IUserService userService)
        {
            this.emailService = emailService;
            applicationSettings = appOptions.Value;
            this.userManager = userManager;
            this.userService = userService;
        }

        public async Task<IdentityResult> ChangePasswordWithTokenAsync(ChangePasswordWithTokenRequest request)
        {
            request.ValidationRules.ValidateAndThrow(request);
            var b = WebEncoders.Base64UrlDecode(request.Token);
            var data = Encoding.UTF8.GetString(b);
            var s = data.Split('|');
            if (s.Length != 2)
                throw new ApplicationException("Invalid token.");

            var user = await userManager.FindByEmailAsync(s[1]);
            if (user == null)
                throw new ApplicationException("Email not found.");

            var result = await userManager.ResetPasswordAsync(user, s[0], request.NewPassword);
            return result;
        }

        public async Task<IdentityResult> ChangePassword(ChangePassword request)
        {
            var user = await userManager.FindByNameAsync(UserName);
            if (user == null)
                throw new ApplicationException("Email not found.");

            var result = await userManager.ChangePasswordAsync(user, request.CurrentPassword, request.NewPassword);
            return result;
        }

        public async Task<IdentityResult> Register(RegisterRequest request)
        {
            var account = new IdentityUser
            {
                UserName = request.Username,
                Email = request.Email,
                EmailConfirmed = true,
            };

            var result = await userManager.CreateAsync(account, request.Password);
            if(result.Succeeded)
            {
                var user = await userManager.FindByNameAsync(account.UserName);
                //await userManager.AddToRoleAsync(user, "WH");
                //await userService.CreateUser(account.UserName, account.Email, request.IsLocal);
            }
            

            return result;
        }

        public async Task ResetPasswordAsync(string email)
        {
            var user = await userManager.FindByEmailAsync(email);
            if (user == null)
                throw new ApplicationException("This email not existing in system.");

            var token = await userManager.GeneratePasswordResetTokenAsync(user);

            var data = $"{token}|{email}";

            var base64 = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(data));

            var content = "At you request for reset your password, please use this link below to Change your password." +
                $"<br/><br/> <a href='{applicationSettings.BaseUrl}/reset-password/{base64}'>Click to Reset Password</a>";

            var emailRequest = new SendEmailRequest
            {
                EmailsTo = new List<string>() { user.Email },
                Subject = "E-Plant - Reset Password",
                Content = content
            };
            await emailService.SendEmailAsync(emailRequest);
        }
    }
}
