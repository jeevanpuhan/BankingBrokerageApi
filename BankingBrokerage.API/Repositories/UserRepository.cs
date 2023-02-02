using BankingBrokerage.API.Data;
using BankingBrokerage.API.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace BankingBrokerage.API.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly BankingBrokerageDbContext _dbContext;

        public UserRepository(BankingBrokerageDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public async Task<User> AddUserAsync(User user)
        {
            await _dbContext.Users.AddAsync(user);
            await _dbContext.SaveChangesAsync();

            return user;
        }

        public async Task<User> DeleteUserAsync(int id)
        {
            var user = await _dbContext.Users.FindAsync(id);

            if (user == null)
            {
                return null;
            }

            // Delete the existing user
            _dbContext.Users.Remove(user);
            await _dbContext.SaveChangesAsync();

            return user;
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await _dbContext.Users.ToListAsync();
        }

        public async Task<User> GetUserAsync(int id)
        {
            return await _dbContext.Users.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<User> UpdateUserAsync(int id, User user)
        {
            var existingUser = await _dbContext.Users.FindAsync(id);

            if (existingUser == null)
            {
                return null;
            }

            existingUser.FirstName= user.FirstName;
            existingUser.LastName= user.LastName;
            existingUser.PrimaryLocation = user.PrimaryLocation;
            existingUser.Address = user.Address;
            existingUser.PermanentAddress = user.PermanentAddress;
            existingUser.GrossSalary = user.GrossSalary;
            existingUser.Job = user.Job;
            existingUser.JobLocation = user.JobLocation;

            _dbContext.Users.Update(existingUser);
            await _dbContext.SaveChangesAsync();

            return existingUser;
        }
    }
}
