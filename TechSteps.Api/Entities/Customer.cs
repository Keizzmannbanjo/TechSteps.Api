using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TechSteps.Api.Entities
{
    [Index(nameof(IdNumber), nameof(Email), nameof(Bvn), nameof(Telephone), IsUnique = true)]
    public class Customer
    {
        [Key]
        public int Id { get; set; }

        public string IdNumber { get; set; }

        public string Title { get; set; }

        public string Bvn { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string MiddleName { get; set; }

        public string ClientType { get; set; }

        public string WorkType { get; set; }

        public string Email { get; set; }

        public string Telephone { get; set; }

        public string Gender { get; set; }

        public DateTime DOB { get; set; }

        public string State { get; set; }

        public string Nationality { get; set; }

        public string HomeAddress { get; set; }

        public string LandMarkOrBustop { get; set; }

        [ForeignKey("Account")]
        public int AccountId { get; set; }

        public Account Account { get; set; }
        public NextOfKin NextOfKin { get; set; }
    }
}
