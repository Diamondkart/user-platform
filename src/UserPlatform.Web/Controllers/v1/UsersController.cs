using Microsoft.AspNetCore.Mvc;
using UserPlatform.ApplicationCore.Commands;
using UserPlatform.ApplicationCore.Models.Request;
using UserPlatform.ApplicationCore.Queries;

namespace UserPlatform.Web.Controllers.v1
{
    [Route("v1/api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly ICommandDispatcher _commandDispatcher;
        private readonly IQueryDispatcher _queryDispatcher;

        public UsersController(ICommandDispatcher commandDispatcher, IQueryDispatcher queryDispatcher)
        {
            _commandDispatcher = commandDispatcher;
            _queryDispatcher = queryDispatcher;
        }

        [HttpGet]
        [Route("GetUsers")]
        public async Task<IActionResult> GetUsers(CancellationToken cancellationToken)
        {
            // Retrieve the list of all users using your data access logic (e.g., a service or repository)
            throw new UnauthorizedAccessException();
            var users = _queryDispatcher.QueryAsync(new GetUsersRequest(), cancellationToken);
            return Ok(users);
        }

        [HttpGet]
        [Route("{userName}", Name = "GetByUserName")]
        public async Task<IActionResult> GetByUserName([FromRoute] string userName, CancellationToken cancellationToken)
        {
            var userRequest = new GetByUserNameRequest { UserName = userName };
            var users = _queryDispatcher.QueryAsync(userRequest, cancellationToken);
            return Ok(users);
        }

        [HttpGet]
        [Route("{userId}", Name = "GetByUserId")]
        public async Task<IActionResult> GetByUserId([FromRoute] Guid userId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
            var request = new GetByUserIdRequest { UserId = userId };
            var users = _queryDispatcher.QueryAsync(request, cancellationToken);
            return Ok(users);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateUserRequest request, CancellationToken cancellationToken)
        {
            var result = await _commandDispatcher.SendAsync(request, cancellationToken);
            var uri = new Uri(Url.Link("GetUserByUserId", new { userId = result.UserId }));
            return Created(uri, result);
        }
    }

    public class UserRequest
    {
        public string userName { get; set; }
    }
}