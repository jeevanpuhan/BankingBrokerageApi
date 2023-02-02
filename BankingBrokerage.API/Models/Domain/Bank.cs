using System.ComponentModel.DataAnnotations;

namespace BankingBrokerage.API.Models.Domain
{
    public class Bank
    {
        [Key]
        public int Id { get; set; }

        [StringLength(9)]
        public string RoutingNumber { get; set; }
        public string BankType { get; set; }

        [MinLength(10), MaxLength(16)]
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
