namespace BankingBrokerage.API.Models.DTO
{
    public class AddBankRequest
    {
        public string RoutingNumber { get; set; }
        public string BankType { get; set; }
        public string AccountNumber { get; set; }
        public string AccountType { get; set; }
        public int UserId { get; set; }
        public string AccountOwnerName { get; set; }
        public string Status { get; set; }
        public bool PrimaryBank { get; set; } = false;
        public string NickName { get; set; }
        public string? AuthenticationMethod { get; set; }
        public string? TransactionType { get; set; }
        public string CommunicationChannel { get; set; }
    }
}
