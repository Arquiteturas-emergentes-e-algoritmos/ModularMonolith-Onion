using User.Application.Commands;

namespace User.Tests.Commands;

[TestClass]
public class GetUserCommandTests
{
    [TestMethod]
    public void Validate_ShouldReturnFalse_WhenUserIdIsEmpty()
    {
        var command = new GetUserCommand { UserId = Guid.Empty };
        var result = command.Validate();
        Assert.IsFalse(result);
    }

    [TestMethod]
    public void Validate_ShouldReturnTrue_WhenUserIdIsValid()
    {
        // Arrange
        var command = new GetUserCommand { UserId = Guid.NewGuid() };

        // Act
        var result = command.Validate();

        // Assert
        Assert.IsTrue(result);
    }
}
