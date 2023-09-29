using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using UserPlatform.ApplicationCore.Models.Request;
using UserPlatform.Persistence.DBStorage;

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
                .WithMessage("UserName must have at least 3 characters.");
            RuleFor(x => x.FirstName)
               .NotEmpty()
               .WithMessage("FirstName can not be empty.");

            RuleFor(x => x.MobileNo.ToString())
                .NotEmpty()
                .WithMessage("MobileNo can not be empty.")
                .Matches(@"^\d{10}$")
                .WithMessage("Mobile number should be 10 digits.");


            RuleFor(x => x.Email)
                .NotEmpty()
                .WithMessage("Email can not be empty.")
                .Matches(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,4}$")
                .WithMessage("Invalid email address.");

            RuleFor(x => x.Password)
                .NotEmpty()
                .WithMessage("Password can not be empty.");          

        }       
    }
}