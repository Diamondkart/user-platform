using FluentValidation;
using UserPlatform.Models.Request;

namespace UserPlatform.Validators
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