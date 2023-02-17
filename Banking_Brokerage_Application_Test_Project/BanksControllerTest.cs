using BankingBrokerage.API.Controllers;
using BankingBrokerage.API.Models.DTO;
using BankingBrokerage.API.Models.Domain;
using BankingBrokerage.API.Services;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;
using Microsoft.AspNetCore.Http;
using Microsoft.OpenApi.Any;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities.Interfaces;

namespace BankingBrokerage.API.Tests.Controllers
{
    public class BanksControllerTests
    {
        private readonly BanksController _controller;
        private readonly Mock<IBankService> _bankServiceMock; //data
        private readonly Mock<IMapper> _mapperMock; //data

        public BanksControllerTests()
        {
            _bankServiceMock = new Mock<IBankService>();
            _mapperMock = new Mock<IMapper>();
            _controller = new BanksController(_bankServiceMock.Object, _mapperMock.Object);
        }

        // For GetAllBanksAsync

        [Fact]
        public async Task GetAllBanksAsync_Should_Return_OkObjectResult()
        {
            // Arrange (initialization)
            var banks = new List<Models.Domain.Bank>
            {
                new Models.Domain.Bank { Id = 1, RoutingNumber="hello",UserId = 1 }
                
            };

            var banksDto = new List<Models.DTO.Bank>
            {
                new Models.DTO.Bank { Id = 1,UserId = 1 }
                
            };

            _bankServiceMock.Setup(service => service.GetAllBanksAsync())
                .ReturnsAsync(banks); //real data to mock data

            _mapperMock.Setup(mapper => mapper.Map<List<Models.DTO.Bank>>(banks))
                .Returns(banksDto);

            // Act
            var result = await _controller.GetAllBanksAsync(); //method calling

            // Assert (checking real and expected value)
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<List<Models.DTO.Bank>>(okResult.Value);
            Assert.Equal(banksDto, returnValue);
        }


        //For GetBankAsync


        [Fact]
        public async Task GetBankAsync_ReturnsNotFoundResult_WhenBankDoesNotExist()
        {
            // Arrange
            var bankId = 1;
            var mockBankService = new Mock<IBankService>();
            mockBankService.Setup(service => service.GetBankAsync(bankId))
                .ReturnsAsync((Models.Domain.Bank)null); // Return null to simulate the bank not existing
            var controller = new BanksController(mockBankService.Object, null);

            // Act
            var result = await controller.GetBankAsync(bankId);

            // Assert
            var notFoundResult = Assert.IsType<NotFoundResult>(result);
            mockBankService.Verify(service => service.GetBankAsync(bankId), Times.Once);
        }


        // For GetGetAllBanksByUserIdAsync



        [Fact]
        public async Task GetGetAllBanksByUserIdAsync_Returns_FoundResult()
        {
            // Arrange
            var userId = 1;
            _bankServiceMock.Setup(s => s.GetAllBanksByUserIdAsync(It.IsAny<int>())).ReturnsAsync(new List<Models.Domain.Bank>());

            // Act
            var result = await _controller.GetGetAllBanksByUserIdAsync(userId);

            // Assert
            Assert.IsType<OkObjectResult>(result);
        }

        // For DeleteUserAsync


        [Fact]
        public async Task DeleteUserAsync_ReturnsNotFound_WhenBankIsNotFound()
        {
            // Arrange
            int bankId = 1;
            var mockBankService = new Mock<IBankService>();
            mockBankService.Setup(service => service.DeleteBankAsync(bankId))
                .ReturnsAsync((Models.Domain.Bank)null); // Return null to indicate bank not found
            var mockMapper = new Mock<IMapper>();
            var controller = new BanksController(mockBankService.Object, mockMapper.Object);

            // Act
            var result = await controller.DeleteUserAsync(bankId);

            // Assert
            var notFoundResult = Assert.IsType<NotFoundResult>(result);
            mockBankService.Verify(service => service.DeleteBankAsync(bankId), Times.Once);
            mockMapper.Verify(mapper => mapper.Map<Models.DTO.Bank>(It.IsAny<Models.DTO.Bank>()), Times.Never);
        }


        //For UpdateUserAsync


        [Fact]
        public async Task UpdateUserAsync_Should_Return_NotFound_When_Bank_Does_Not_Exist()
        {
            // Arrange
            var id = 1;
            var updateBankRequest = new UpdateBankRequest { AccountOwnerName = "Updated Bank Name" };
            _mapperMock.Setup(mapper => mapper.Map<Models.DTO.Bank>(updateBankRequest))
                .Returns(new Models.DTO.Bank { AccountOwnerName = "Updated Bank Name" });

            _bankServiceMock.Setup(service => service.UpdateBankAsync(id, It.IsAny<Models.Domain.Bank>()))
                .ReturnsAsync((Models.Domain.Bank)null);

            // Act
            var result = await _controller.UpdateUserAsync(id, updateBankRequest);

            // Assert
            var notFoundResult = Assert.IsType<NotFoundResult>(result);
            Assert.Equal(StatusCodes.Status404NotFound, notFoundResult.StatusCode);
        }

      

    }
}
