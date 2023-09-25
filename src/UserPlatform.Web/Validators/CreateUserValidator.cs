using FluentValidation;
using UserPlatform.ApplicationCore.Models.Request;

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
                .NotEmpty()
                .Must(x =>x?.Trim().Length>3)
                .WithMessage("UserName must have at least 3 characters.");
            
        }
    }
}