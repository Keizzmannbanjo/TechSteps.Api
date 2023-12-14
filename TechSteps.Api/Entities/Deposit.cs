using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TechSteps.Api.Entities
{
    public class Deposit
    {
        [Key]
        public int Id { get; set; }

        public DateTime DateEffective { get; set; }
        [Required]
        public int Tenure { get; set; }
        [Required]
        [Column(TypeName = "Money")]
        public decimal Amount { get; set; }
        [Required]
        public decimal Rate { get; set; }
        [Required]
        public DateTime DateCreated { get; set; } = DateTime.Now;
        [Required]
        public DateTime MaturityDate { get; set; }
        [Required]
        [Column(TypeName = "Money")]
        public decimal MaturityAmount { get; set; }
        [Required]
        public string InterestType { get; set; }
        [Required]
        public string Comment { get; set; }
        [Required]
        public int CustomerId { get; set; }

        public Customer Customer { get; set; }

    }
}
