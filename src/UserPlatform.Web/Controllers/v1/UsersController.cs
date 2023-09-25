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
        [Route("")]
        public async Task<IActionResult> Get()
        {
            return Ok();
        }

        [HttpGet]
        [Route("{userName}", Name = "GetUserByUserName")]
        public async Task<IActionResult> GetByUserName()
        {
            // _queryDispatcher
            return Ok();
        }

        [HttpGet]
        [Route("{userId}", Name = "GetUserByUserId")]
        public async Task<IActionResult> GetyUserId([FromRoute] Guid userId)
        {
            // _queryDispatcher
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateUserRequest request, CancellationToken cancellationToken)
        {
            var result = await _commandDispatcher.SendAsync(request, cancellationToken);
            var uri = new Uri(Url.Link("GetUserByUserId", new { userId = result.UserId }));
            return Created(uri, result);
        }
    }
}