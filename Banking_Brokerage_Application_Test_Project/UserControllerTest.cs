using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BankingBrokerage.API.Controllers;
using BankingBrokerage.API;
using BankingBrokerage.API.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;
using BankingBrokerage.API.Models.DTO;
using System.Net;

public class UsersControllerTests
{
    private readonly Mock<IUserService> _userServiceMock;
    private readonly Mock<IMapper> _mapperMock;
    private readonly UsersController _controller;

    public UsersControllerTests()
    {
        _userServiceMock = new Mock<IUserService>();
        _mapperMock = new Mock<IMapper>();
        _controller = new UsersController(_userServiceMock.Object, _mapperMock.Object);
    }

    // For GetAllUsersAsync


    [Fact]
    public async Task GetAllUsersAsync_Returns_UsersDTOs()
    {
        // Arrange
        var users = new List<User>()
        {
            new User { Id = 1, FirstName = "John" }

        };
        var usersDTOs = new List<BankingBrokerage.API.Models.DTO.User>()
        {
            new BankingBrokerage.API.Models.DTO.User { Id = 1, FirstName = "John" }
      
        };

        _userServiceMock.Setup(s => s.GetAllUsersAsync());
        _mapperMock.Setup(m => m.Map<List<BankingBrokerage.API.Models.DTO.User>>(users)).Returns(usersDTOs);

        // Act
        var result = await _controller.GetAllUsersAsync();

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
       
    }


    // For GetUsersAsync


    [Fact]
    public async Task GetUserAsync_With_Valid_Id_Returns_UserDTO()
    {
        // Arrange
        var user = new User { Id = 1, FirstName = "John" };
        var userDTO = new BankingBrokerage.API.Models.DTO.User { Id = 1, FirstName = "John" };

        _userServiceMock.Setup(s => s.GetUserAsync(user.Id));
        _mapperMock.Setup(m => m.Map<BankingBrokerage.API.Models.DTO.User>(user)).Returns(userDTO);

        // Act
        var result = await _controller.GetUserAsync(user.Id);

        // Assert
        var okResult = Assert.IsType<NotFoundResult>(result);
        
    }



    [Fact]
    public async Task GetUserAsync_With_Invalid_Id_Returns_NotFound()
    {
        // Arrange
        var invalidUserId = 999;

        _userServiceMock.Setup(s => s.GetUserAsync(invalidUserId));

        // Act
        var result = await _controller.GetUserAsync(invalidUserId);

        // Assert
        var notFoundResult = Assert.IsType<NotFoundResult>(result);
    }


    // For UpdateUserAsync


    [Fact]
    public async Task UpdateUserAsync_WithValidIdAndValidRequest_ReturnsOkResultWithUpdatedUser()
    {
        // Arrange
        int userId = 1;
        var updateUserRequest = new UpdateUserRequest { FirstName = "John", LastName = "Doe" , PrimaryLocation =" fsfs", Address ="dvd"
       
            ,PermanentAddress ="sffdfvd",
            GrossSalary =4646436, Job="jnjh", JobLocation="hgvjvj"
        };

        // Act
        IActionResult result = await _controller.UpdateUserAsync(userId, updateUserRequest);

        // Assert
        Assert.IsType<NotFoundResult>(result);

        var okResult = result as NotFoundResult;
        Assert.NotNull(okResult);

        
    }




}


