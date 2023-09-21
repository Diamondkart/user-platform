using FluentValidation;
using UserPlatform.Core.Models.Request;

namespace UserPlatform.Web.Validators
{
    /// <summary>
    /// It validates incoming api request.
    /// </summary>
    public class CreateUserValidator : AbstractValidator<CreateUserBody>
    {
        public CreateUserValidator()
        {
        }
    }
}