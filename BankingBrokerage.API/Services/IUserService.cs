using BankingBrokerage.API.Models.Domain;

namespace BankingBrokerage.API.Services
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetAllUsersAsync();

        Task<User> GetUserAsync(int id);

        Task<User> AddUserAsync(User user);

        Task<User> DeleteUserAsync(int id);

        Task<User> UpdateUserAsync(int id, User user);
    }
}
