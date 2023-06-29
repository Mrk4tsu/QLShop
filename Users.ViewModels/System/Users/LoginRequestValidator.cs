using FluentValidation;
namespace Users.ViewModels.System.Users
{
    public class LoginRequestValidator : AbstractValidator<LoginRequest>
    {
        public LoginRequestValidator()
        {
            RuleFor(x => x.UserName).NotEmpty().WithMessage("Username là phải bắt buộc");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Password là phải bắt buộc").MinimumLength(6).WithMessage("Password có độ dài phải lớn hơn 6 kí tự");
        }
    }
}
