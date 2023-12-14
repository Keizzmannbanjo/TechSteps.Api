using TechSteps.Api.Data;
using TechSteps.Api.Repositories.Contracts;

namespace TechSteps.Api.Repositories
{
    public class IdGenerator : IIdGenerator
    {
        private readonly ApiDbContext db;

        public IdGenerator(ApiDbContext db)
        {
            this.db = db;
        }
        public string GenerateIdNumber()
        {

            // Get the current maximum serial number from the database
            string maxSerialNumber = db.Customers.Max(e => e.IdNumber);

            // Extract the numeric part of the serial number
            string numericPart = maxSerialNumber?.Substring(3) ?? "0";

            // Increment the numeric part by one and format it with leading zeros
            int nextNumber = int.Parse(numericPart) + 1;
            string formattedNumber = nextNumber.ToString("D6");

            // Combine the "SN" prefix with the formatted number to create the new serial number
            return $"IDN{formattedNumber}";
        }
    }
}
