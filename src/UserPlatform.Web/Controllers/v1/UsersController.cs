using Microsoft.AspNetCore.Mvc;
using UserPlatform.ApplicationCore.Commands;
using UserPlatform.ApplicationCore.Models.Request;
using UserPlatform.ApplicationCore.Queries;
using UserPlatform.Domain.Constant;

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
        [Route("")]
        public async Task<IActionResult> GetUsers(CancellationToken cancellationToken)
        {
            // Retrieve the list of all users using your data access logic (e.g., a service or repository)
            var users = await _queryDispatcher.QueryAsync(new GetUsersRequest(), cancellationToken);
            return Ok(users);
        }

        [HttpGet]
        [Route("{UserName}", Name = "GetByUserName")]
        public async Task<IActionResult> GetByUserName([FromRoute] GetByUserNameRequest request, CancellationToken cancellationToken)
        {
            var users = await _queryDispatcher.QueryAsync(request, cancellationToken);
            return Ok(users);
        }

        [HttpGet]
        [Route("{userId:guid}", Name = "GetByUserId")]
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

            var uri = new Uri(Url.Link("GetByUserId", new { userId = result.UserId }));
            return Created(uri, result);
        }

        [HttpPut]
        [Route("{userId:guid}")]
        public async Task<IActionResult> Update([FromBody] UpdateUserRequest updateUserRequest, [FromRoute] Guid userId, CancellationToken cancellationToken)
        {
            updateUserRequest.UserId = userId;
            var result = await _commandDispatcher.SendAsync(updateUserRequest, cancellationToken);

            return NoContent();
        }

        [HttpPatch]
        [Route("{userId:guid}/PhoneNumber")]
        public async Task<IActionResult> UpdatePhoneNumber([FromBody] UpdatePhoneNumberRequest updatePhoneNumberRequest, [FromRoute] Guid userId, CancellationToken cancellationToken)
        {
            updatePhoneNumberRequest.UserId = userId;
            var isPhoneNumberUpdated = await _commandDispatcher.SendAsync<bool>(updatePhoneNumberRequest, cancellationToken);
            if (!isPhoneNumberUpdated)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, Constant.UnableToUpdateNumber);
            }
            return NoContent();
        }

        [HttpPatch]
        [Route("{userId:guid}/Name")]
        public async Task<IActionResult> UpdateName([FromBody] UpdateNameRequest updateNameRequest, [FromRoute] Guid userId, CancellationToken cancellationToken)
        {
            updateNameRequest.UserId = userId;
            var isUserNameUpdated = await _commandDispatcher.SendAsync(updateNameRequest, cancellationToken);
            if (!isUserNameUpdated)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, Constant.UnableToUpdateName);
            }
            return NoContent();
        }
    }
}