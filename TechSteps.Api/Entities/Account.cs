using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TechSteps.Api.Entities
{
    [Index(nameof(AccountNumber), IsUnique = true)]
    public class Account
    {
        [Key]
        public int Id { get; set; }

        public string AccountNumber { get; set; }

        [Column(TypeName = "Money")]
        public decimal Balance { get; set; }

        public string Name { get; set; }

        [ForeignKey("Bank")]
        public int BankId { get; set; }

        public Bank Bank { get; set; }

        public Customer Customer { get; set; }
    }
}
