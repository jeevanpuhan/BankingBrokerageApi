using System.Collections.Generic;
using System.Threading.Tasks;
using BankingBrokerage.API.Models.Domain;
using BankingBrokerage.API.Services;
using Moq;
using Xunit;

public class UserServiceTests
{
    private readonly Mock<IUserService> _userServiceMock;

    public UserServiceTests()
    {
        _userServiceMock = new Mock<IUserService>();
    }


    [Fact]
    public async Task GetUserAsync_Returns_Single_User_By_Id()
    {
        // Arrange
        var expectedUser = new User { Id = 1, FirstName = "John" };
        _userServiceMock.Setup(service => service.GetUserAsync(1)).ReturnsAsync(expectedUser);

        // Act
        var actualUser = await _userServiceMock.Object.GetUserAsync(1);

        // Assert
        Assert.NotNull(actualUser);
        Assert.Equal(expectedUser.Id, actualUser.Id);
        Assert.Equal(expectedUser.FirstName, actualUser.FirstName);
    }

    [Fact]
    public async Task AddUserAsync_Adds_New_User()
    {
        // Arrange
        var newUser = new User { FirstName = "Mary" };
        _userServiceMock.Setup(service => service.AddUserAsync(newUser)).ReturnsAsync(new User { Id = 1, FirstName = "Mary" });

        // Act
        var addedUser = await _userServiceMock.Object.AddUserAsync(newUser);

        // Assert
        Assert.NotNull(addedUser);
        Assert.Equal(newUser.FirstName, addedUser.FirstName);
    }

    [Fact]
    public async Task DeleteUserAsync_Deletes_User_By_Id()
    {
        // Arrange
        var userId = 1;
        var expectedUser = new User { Id = userId, FirstName = "John" };
        _userServiceMock.Setup(service => service.DeleteUserAsync(userId)).ReturnsAsync(expectedUser);

        // Act
        var deletedUser = await _userServiceMock.Object.DeleteUserAsync(userId);

        // Assert
        Assert.NotNull(deletedUser);
        Assert.Equal(expectedUser.Id, deletedUser.Id);
        Assert.Equal(expectedUser.FirstName, deletedUser.FirstName);
    }

    [Fact]
    public async Task UpdateUserAsync_Updates_User_By_Id()
    {
        // Arrange
        var userId = 1;
        var updatedUser = new User { Id = userId, FirstName = "Mary" };
        _userServiceMock.Setup(service => service.UpdateUserAsync(userId, updatedUser)).ReturnsAsync(updatedUser);

        // Act
        var actualUser = await _userServiceMock.Object.UpdateUserAsync(userId, updatedUser);

        // Assert
        Assert.NotNull(actualUser);
        Assert.Equal(updatedUser.Id, actualUser.Id);
        Assert.Equal(updatedUser.FirstName, actualUser.FirstName);
    }
}
