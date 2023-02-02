using BankingBrokerage.API.Models.Domain;

namespace BankingBrokerage.API.Repositories
{
    public interface IBankRepository
    {
        Task<IEnumerable<Bank>> GetAllBanksAsync();

        Task<IEnumerable<Bank>> GetAllBanksByUserIdAsync(int userId);

        Task<Bank> GetBankAsync(int id);

        Task<Bank> AddBankAsync(Bank bank);

        Task<Bank> DeleteBankAsync(int id);

        Task<Bank> UpdateBankAsync(int id, Bank bank);

    }
}
