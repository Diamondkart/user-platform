using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using UserPlatform.ApplicationCore.Commands;
using UserPlatform.ApplicationCore.Models.Request;
using UserPlatform.ApplicationCore.Queries;
using UserPlatform.Web.Controllers.v1;
using UserPlatform.Web.Unit.Tests.Utilities;
using Xunit;

namespace UserPlatform.Web.Unit.Tests.Controller
{
    public class UsersControllerTests
    {
        private Mock<IQueryDispatcher> _queryDispatcherMock;
        private Mock<ICommandDispatcher> _commandDispatcherMock;
        private UsersController _userController;

        public UsersControllerTests()
        {
            _queryDispatcherMock = new Mock<IQueryDispatcher>(MockBehavior.Strict);
            _commandDispatcherMock = new Mock<ICommandDispatcher>(MockBehavior.Strict);
            _userController = new UsersController(_commandDispatcherMock.Object, _queryDispatcherMock.Object);
        }

        [Fact]
        public async Task GetUsers_HappyPath()
        {
            var userList = ObjectFactory.GetUserResponse.Generate(4);
            CancellationToken cancellationToken = new CancellationToken();
            _queryDispatcherMock
                .Setup(x => x.QueryAsync(It.IsAny<GetUsersRequest>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(userList);

            var response = await _userController.GetUsers(cancellationToken) as ObjectResult;
            Assert.NotNull(response);
            Assert.Equal(StatusCodes.Status200OK, response.StatusCode);
            Assert.Equal(userList, response.Value);
        }
    }
}