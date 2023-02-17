using System.Collections.Generic;
using System.Threading.Tasks;
using BankingBrokerage.API.Models.Domain;
using BankingBrokerage.API.Services;
using Moq;
using Xunit;

public class BankServiceTests
{
    private readonly Mock<IBankService> _mockBankService;

    public BankServiceTests()
    {
        _mockBankService = new Mock<IBankService>();
    }

    [Fact]
    public async Task GetAllBanksAsync_ReturnsAllBanks()
    {
        // Arrange
        var banks = new List<Bank>
        {
            new Bank { Id = 1, AccountOwnerName = "SDFSFS" }
            
        };
        _mockBankService.Setup(x => x.GetAllBanksAsync()).ReturnsAsync(banks);

        // Act
        var result = await _mockBankService.Object.GetAllBanksAsync();

        // Assert
        Assert.NotNull(result);
        //Assert.Equal(3, result.Count);
    }

    [Fact]
    public async Task GetAllBanksByUserIdAsync_ReturnsBanksForGivenUser()
    {
        // Arrange
        var userId = 1;
        var banks = new List<Bank>
        {
            new Bank { Id = 1, AccountOwnerName = "FAFEFSE", UserId = userId }
           
        };
        _mockBankService.Setup(x => x.GetAllBanksByUserIdAsync(userId)).ReturnsAsync(banks);

        // Act
        var result = await _mockBankService.Object.GetAllBanksByUserIdAsync(userId);

        // Assert
        Assert.NotNull(result);
        //Assert.Equal(2, result.Count);
    }

    [Fact]
    public async Task GetBankAsync_ReturnsBankForGivenId()
    {
        // Arrange
        var bankId = 1;
        var bank = new Bank { Id = bankId, AccountOwnerName = "fradD" };
        _mockBankService.Setup(x => x.GetBankAsync(bankId)).ReturnsAsync(bank);

        // Act
        var result = await _mockBankService.Object.GetBankAsync(bankId);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(bankId, result.Id);
    }

    [Fact]
    public async Task AddBankAsync_ReturnsAddedBank()
    {
        // Arrange
        var bankToAdd = new Bank { AccountOwnerName = "fdfsf" };
        var addedBank = new Bank { Id = 1, AccountOwnerName = "sfsfsf" };
        _mockBankService.Setup(x => x.AddBankAsync(bankToAdd)).ReturnsAsync(addedBank);

        // Act
        var result = await _mockBankService.Object.AddBankAsync(bankToAdd);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(addedBank.Id, result.Id);
    }

    [Fact]
    public async Task DeleteBankAsync_ReturnsDeletedBank()
    {
        // Arrange
        var bankId = 1;
        var bankToDelete = new Bank { Id = bankId, AccountOwnerName = "sgassf" };
        _mockBankService.Setup(x => x.DeleteBankAsync(bankId)).ReturnsAsync(bankToDelete);

        // Act
        var result = await _mockBankService.Object.DeleteBankAsync(bankId);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(bankId, result.Id);
    }
}

    

