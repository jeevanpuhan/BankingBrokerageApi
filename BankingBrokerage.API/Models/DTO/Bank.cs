using System.ComponentModel.DataAnnotations;

namespace BankingBrokerage.API.Models.DTO
{
    public class Bank
    {
        public int Id { get; set; }
        public string RoutingNumber { get; set; }
        public string BankType { get; set; }
        public string AccountNumber { get; set; }
        public string AccountType { get; set; }
        public int UserId { get; set; }
        public string AccountOwnerName { get; set; }
        public string Status { get; set; }
        public bool PrimaryBank { get; set; }
        public string NickName { get; set; }
        public string? AuthenticationMethod { get; set; }
        public string? TransactionType { get; set; }
        public string CommunicationChannel { get; set; }

        // Navigation Properties
        public User User { get; set; }
    }
}
