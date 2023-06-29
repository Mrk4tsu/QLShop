using FluentValidation;
using System;

namespace Users.ViewModels.System.Users
{
    public class RegisterRequestValidator : AbstractValidator<RegisterRequest>
    {
        public RegisterRequestValidator() 
        {
            RuleFor(x => x.FirstName).NotEmpty().WithMessage("First Name là trường bắt buộc")
                .MaximumLength(200).WithMessage("First Name tối đa chỉ 200 kí tự");
            
            RuleFor(x => x.LastName).NotEmpty().WithMessage("Last Name là trường bắt buộc")
                .MaximumLength(200).WithMessage("Last Name tối đa chỉ 200 kí tự");

            RuleFor(x => x.DoB).GreaterThan(DateTime.Now.AddYears(-100)).WithMessage("Năm sinh không thể cách quá 100 năm");

            RuleFor(x => x.Email).NotEmpty().WithMessage("Vui lòng nhập vào phần Email")
                .Matches(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$").WithMessage("Kiểm tra lại Email nhập vào");

            RuleFor(x => x.PhoneNumber).NotEmpty().WithMessage("Phone là trường bắt buộc");

            RuleFor(x => x.UserName).NotEmpty().WithMessage("Username là phải bắt buộc");

            RuleFor(x => x.Password).NotEmpty().WithMessage("Password là phải bắt buộc")
                .MinimumLength(6).WithMessage("Password có độ dài phải lớn hơn 6 kí tự");

            RuleFor(x => x.Adress).NotEmpty().WithMessage("Adress là trường phải bắt buộc");

            RuleFor(x => x).Custom((request, context) =>
            {
                if (request.Password != request.ConfirmPassword)
                {
                    context.AddFailure("Mật khẩu không khớp");
                }
            });
        }
    }
}
