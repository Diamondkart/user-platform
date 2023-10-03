using Bogus;
using UserPlatform.ApplicationCore.Models.Response;

namespace UserPlatform.Web.Unit.Tests.Utilities
{
    public class ObjectFactory
    {
        public static Faker<GetUsersResponse> GetUserResponse { get; } =
            new Faker<GetUsersResponse>()
            .RuleFor(x => x.UserId, y => y.Random.Guid())
            .RuleFor(x => x.UserName, y => y.Random.Int().ToString())
            .RuleFor(x => x.FirstName, y => y.Random.Int().ToString())
            .RuleFor(x => x.LastName, y => y.Random.Int().ToString())
            .RuleFor(x => x.MiddleName, y => y.Random.Int().ToString())
            .RuleFor(x => x.MobileNo, y => y.Random.Int())
            .RuleFor(x => x.Email, y => y.Random.Int().ToString() + "@example.com");
    }
}