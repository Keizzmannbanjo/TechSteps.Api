using Microsoft.AspNetCore.Identity;

namespace TechSteps.Api.Entities
{
    public class Staff : IdentityUser
    {
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string JobPosition { get; set; }
    }
}
