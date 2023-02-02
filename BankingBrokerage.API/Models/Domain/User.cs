using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BankingBrokerage.API.Models.Domain
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PrimaryLocation { get; set; }
        public string Address { get; set; }
        public string PermanentAddress { get; set; }

        [Column(TypeName = "money")]
        public decimal GrossSalary { get; set; }
        public string Job { get; set; }
        public string JobLocation { get; set; }

        // Navigation Properties
        public IEnumerable<Bank> Banks { get; set; }
    }
}
