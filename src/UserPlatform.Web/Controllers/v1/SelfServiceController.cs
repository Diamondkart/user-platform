using Microsoft.AspNetCore.Mvc;
using UserPlatform.ApplicationCore.Commands;
using UserPlatform.ApplicationCore.Models.Request;
using UserPlatform.ApplicationCore.Queries;

namespace UserPlatform.Web.Controllers.v1
{
    [Route("v1/api/[controller]")]
    [ApiController]
    public class SelfServiceController : ControllerBase
    {
        private readonly ICommandDispatcher _commandDispatcher;
        private readonly IQueryDispatcher _queryDispatcher;

        public SelfServiceController(ICommandDispatcher commandDispatcher, IQueryDispatcher queryDispatcher)
        {
            _commandDispatcher = commandDispatcher;
            _queryDispatcher = queryDispatcher;
        }

        [HttpPost]
        [Route("GeneratePassword/{Token}", Name = "GeneratePassword")]
        public async Task<IActionResult> GeneratePassword([FromBody] GeneratePasswordRequest generatePasswordRequest, [FromRoute] string Token, CancellationToken cancellationToken)
        {
            generatePasswordRequest.Token = Token;
            var response = await _commandDispatcher.SendAsync(generatePasswordRequest, cancellationToken);
            return Ok(response);
        }

        [HttpPost]
        [Route("ChangePassword", Name = "RequestChangePassword")]
        public async Task<IActionResult> RequestChangePassword([FromBody] ChangePasswordRequest changePasswordRequest, CancellationToken cancellationToken)
        {
            var response = await _commandDispatcher.SendAsync(changePasswordRequest, cancellationToken);
            var createdResourceUri = new Uri(Url.Link("GeneratePassword", new { Token = response.Token }));
            return Created(createdResourceUri, response);
        }

        [HttpPost]
        [Route("VerifyUserCred", Name = "VerifyUserCredAsync")]
        public async Task<IActionResult> VerifyUserCredAsync([FromBody] VerifyUserCredRequest verifyUserCredRequest, CancellationToken cancellationToken)
        {
            var response = await _commandDispatcher.SendAsync(verifyUserCredRequest, cancellationToken);
            return Ok(response);
        }
    }
}