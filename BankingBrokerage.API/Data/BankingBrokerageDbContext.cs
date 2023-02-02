using BankingBrokerage.API.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace BankingBrokerage.API.Data
{
    public class BankingBrokerageDbContext : DbContext
    {
        public BankingBrokerageDbContext(DbContextOptions<BankingBrokerageDbContext> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Bank> Banks { get; set; }
    }
}
