using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TechSteps.Api.Entities
{
    public class NextOfKin
    {
        [Key]
        public int Id { get; set; }

        public string FullName { get; set; }

        public string Telephone { get; set; }

        public string Relationship { get; set; }
        [ForeignKey("RelatedCustomer")]
        public int RelatedCustomerId { get; set; }
        public Customer RelatedCustomer { get; set; }
    }
}
