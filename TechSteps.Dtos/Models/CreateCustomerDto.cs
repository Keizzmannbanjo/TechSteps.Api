namespace TechSteps.Dtos.Models
{
    public class CreateCustomerDto
    {
        public string Title { get; set; }
        public string Bvn { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }

        public string ClientType { get; set; }

        public string Email { get; set; }

        public string Telephone { get; set; }

        public string Gender { get; set; }

        public DateTime DOB { get; set; }

        public string State { get; set; }

        public string Nationality { get; set; }

        public string HomeAddress { get; set; }

        public string LandMarkOrBustop { get; set; }

        public string AccountNumber { get; set; }

        public string AccountName { get; set; }

        public string BankName { get; set; }

        public string NextOfKinFullName { get; set; }

        public string NextOfKinTelephone { get; set; }

        public string NextOfKinRelationship { get; set; }
        public string WorkType { get; set; }
    }
}
