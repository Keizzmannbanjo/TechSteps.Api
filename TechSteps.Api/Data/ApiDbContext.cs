using Microsoft.EntityFrameworkCore;
using TechSteps.Api.Entities;

namespace TechSteps.Api.Data
{
    public class ApiDbContext : DbContext
    {
        public ApiDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Account> Accounts { get; set; }

        public DbSet<Deposit> Deposits { get; set; }

        public DbSet<NextOfKin> NextOfKins { get; set; }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Bank> Banks { get; set; }

        public DbSet<Staff> Staffs { get; set; }
    }
}
