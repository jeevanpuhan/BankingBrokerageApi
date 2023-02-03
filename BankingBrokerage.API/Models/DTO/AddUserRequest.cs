namespace BankingBrokerage.API.Models.DTO
{
    public class AddUserRequest
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PrimaryLocation { get; set; }
        public string Address { get; set; }
        public string PermanentAddress { get; set; }
        public decimal GrossSalary { get; set; }
        public string Job { get; set; }
        public string JobLocation { get; set; }
    }
}
