using System.ComponentModel.DataAnnotations;

namespace TechSteps.Api.Entities
{
    public class Staff
    {
        [Key]
        public int Id { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string JobPosition { get; set; }
    }
}
