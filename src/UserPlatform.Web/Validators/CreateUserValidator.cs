using FluentValidation;
using UserPlatform.ApplicationCore.Models.Request;
using UserPlatform.Domain.Constant;

namespace UserPlatform.Web.Validators
{
    /// <summary>
    /// It validates incoming api request.
    /// </summary>
    public class CreateUserValidator : AbstractValidator<CreateUserRequest>
    {
        public CreateUserValidator()
        {
            RuleFor(x => x.UserName)
                .Must(x => x?.Trim().Length > 3)
                .WithMessage(Constant.EmptyUserNameErrorMessage);
            RuleFor(x => x.FirstName)
               .NotEmpty()
               .WithMessage(Constant.EmptyFirstNameErrorMessage);

            RuleFor(x => x.MobileNo.ToString())
                .NotEmpty()
                .WithMessage(Constant.EmptyMobileErrorMessage)
                .Matches(Constant.MobileNumberPattern)
                .WithMessage(Constant.InvalidMobileErrorMessage);

            RuleFor(x => x.Email)
                .NotEmpty()
                .WithMessage(Constant.EmptyEmailErrorMessage)
                .Matches(Constant.EmailPattern)
                .WithMessage(Constant.InvalidEmailErrorMessage);

            RuleFor(x => x.Password)
                .NotEmpty()
                .WithMessage(Constant.EmptyPasswordErrorMessage);
        }
    }
}