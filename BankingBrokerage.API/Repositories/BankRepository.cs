using BankingBrokerage.API.Data;
using BankingBrokerage.API.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace BankingBrokerage.API.Repositories
{
    public class BankRepository : IBankRepository
    {
        private readonly BankingBrokerageDbContext _dbContext;

        public BankRepository(BankingBrokerageDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public async Task<Bank> AddBankAsync(Bank bank)
        {
            await _dbContext.Banks.AddAsync(bank);
            await _dbContext.SaveChangesAsync();

            return bank;
        }

        public async Task<Bank> DeleteBankAsync(int id)
        {
            var bank = await _dbContext.Banks.FindAsync(id);

            if (bank == null)
            {
                return null;
            }

            // Delete the existing bank
            _dbContext.Banks.Remove(bank);
            await _dbContext.SaveChangesAsync();

            return bank;
        }

        public async Task<IEnumerable<Bank>> GetAllBanksAsync()
        {
            return await _dbContext.Banks.ToListAsync();
        }

        public async Task<IEnumerable<Bank>> GetAllBanksByUserIdAsync(int userId)
        {
            var banks = await _dbContext.Banks.ToListAsync();

            return banks.FindAll(x => x.UserId == userId).ToList();
        }

        public async Task<Bank> GetBankAsync(int id)
        {
            return await _dbContext.Banks.FindAsync(id);
        }

        public async Task<Bank> UpdateBankAsync(int id, Bank bank)
        {
            var existingBank = await _dbContext.Banks.FindAsync(id);
            
            if (existingBank == null)
            {
                return null;
            }

            existingBank.AccountOwnerName = bank.AccountOwnerName;
            existingBank.NickName = bank.NickName;

            _dbContext.Banks.Update(existingBank);
            await _dbContext.SaveChangesAsync();

            return existingBank;
        }
    }
}
