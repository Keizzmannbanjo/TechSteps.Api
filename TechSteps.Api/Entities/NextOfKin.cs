using System.ComponentModel.DataAnnotations;

namespace TechSteps.Api.Entities
{
    public class NextOfKin
    {
        [Key]
        public int Id { get; set; }

        public string FullName { get; set; }

        public string Telephone { get; set; }

        public string Relationship { get; set; }
    }
}
