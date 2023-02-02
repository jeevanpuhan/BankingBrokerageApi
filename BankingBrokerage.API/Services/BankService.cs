using BankingBrokerage.API.Models.Domain;
using BankingBrokerage.API.Repositories;

namespace BankingBrokerage.API.Services
{
    public class BankService : IBankService
    {
        private readonly IBankRepository _bankRepository;

        public BankService(IBankRepository bankRepository)
        {
            this._bankRepository = bankRepository;
        }

        public async Task<Bank> AddBankAsync(Bank bank)
        {
            return await _bankRepository.AddBankAsync(bank);
        }

        public async Task<Bank> DeleteBankAsync(int id)
        {
            return await _bankRepository.DeleteBankAsync(id);
        }

        public async Task<IEnumerable<Bank>> GetAllBanksAsync()
        {
           return await _bankRepository.GetAllBanksAsync();
        }

        public async Task<IEnumerable<Bank>> GetAllBanksByUserIdAsync(int userId)
        {
            return await _bankRepository.GetAllBanksByUserIdAsync(userId);
        }

        public async Task<Bank> GetBankAsync(int id)
        {
            return await _bankRepository.GetBankAsync(id);
        }

        public async Task<Bank> UpdateBankAsync(int id, Bank bank)
        {
            return await _bankRepository.UpdateBankAsync(id, bank);
        }
    }
}
