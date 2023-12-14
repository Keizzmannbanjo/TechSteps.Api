using System.ComponentModel.DataAnnotations;

namespace TechSteps.Api.Entities
{
    public class Bank
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<Account>? Accounts { get; set; }
    }
}
