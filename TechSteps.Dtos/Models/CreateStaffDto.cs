namespace TechSteps.Dtos.Models
{
    public class CreateStaffDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string JobPosition { get; set; }
    }
}
