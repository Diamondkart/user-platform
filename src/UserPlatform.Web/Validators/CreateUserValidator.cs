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
                .WithName(x => nameof(x.UserName))
                .WithMessage(Constant.EmptyUserNameErrorMessage);

            RuleFor(x => x.FirstName)
               .NotEmpty()
               .WithName(x => nameof(x.FirstName))
               .WithMessage(Constant.EmptyFirstNameErrorMessage);

            RuleFor(x => x.MobileNo.ToString())
                .NotEmpty()
                .WithName(x => nameof(x.MobileNo))
                .WithMessage(Constant.EmptyMobileErrorMessage)
                .Matches(Constant.MobileNumberPattern)
                .WithName(x => nameof(x.MobileNo))
                .WithMessage(Constant.InvalidMobileErrorMessage);

            RuleFor(x => x.Email)
                .NotEmpty()
                .WithName(x=>nameof(x.Email))
                .WithMessage(Constant.EmptyEmailErrorMessage)
                .Matches(Constant.EmailPattern)
                .WithName(x => nameof(x.Email))
                .WithMessage(Constant.InvalidEmailErrorMessage);

            RuleFor(x => x.Password)
                .NotEmpty()
                .WithName(x => nameof(x.Password))
                .WithMessage(Constant.EmptyPasswordErrorMessage);
        }
    }
}