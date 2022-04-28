using FluentValidation;

namespace Sketec.Application.Resources.Accounts
{
    public class ChangePasswordWithTokenRequest
    {
        public string Token { get; set; }
        public string NewPassword { get; set; }

        public Validator ValidationRules => new Validator();

        public class Validator : AbstractValidator<ChangePasswordWithTokenRequest>
        {
            public Validator()
            {
                RuleFor(m => m.Token).NotEmpty();
                RuleFor(m => m.NewPassword).NotEmpty();
            }
        }
    }

    public class ChangePassword
    {
        public string CurrentPassword { get; set; }
        public string NewPassword { get; set; }
    }

}
