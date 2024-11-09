using Moq;
using User.Application.Commands;
using User.Application.Repository;
using User.Application.Services;

namespace User.Tests
{
    [TestClass]
    public class UserServiceTests
    {
        private Mock<IUserRepository> _mockRepository;
        private UserService _userService;

        [TestInitialize]
        public void Setup()
        {
            _mockRepository = new Mock<IUserRepository>();
            _userService = new UserService(_mockRepository.Object);
        }

        [TestMethod]
        public void Handle_CreateUserCommand_ShouldCreateUserAndReturnSuccess()
        {
            // Arrange
            var command = new CreateUserCommand();
            var user = new Domain.User();
            _mockRepository.Setup(repo => repo.Add(It.IsAny<Domain.User>())).Verifiable();

            // Act
            var response = _userService.Handle(command);

            // Assert
            Assert.AreEqual(200, response.Status);
            Assert.IsNotNull(response.Data);
            _mockRepository.Verify(repo => repo.Add(It.IsAny<Domain.User>()), Times.Once);
        }

        [TestMethod]
        public void Handle_GetUserCommand_ShouldReturnUser()
        {
            // Arrange
            var userId = Guid.NewGuid();
            var command = new GetUserCommand { UserId = userId };
            var user = new Domain.User { Id = userId };
            _mockRepository.Setup(repo => repo.GetById(userId)).Returns(user);

            // Act
            var response = _userService.Handle(command);

            // Assert
            Assert.AreEqual(200, response.Status);
            Assert.AreEqual(user, response.Data);
        }
    }
}
