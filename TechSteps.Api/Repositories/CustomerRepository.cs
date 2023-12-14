using Microsoft.EntityFrameworkCore;
using TechSteps.Api.Data;
using TechSteps.Api.Entities;
using TechSteps.Api.Repositories.Contracts;
using TechSteps.Dtos.Models;

namespace TechSteps.Api.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly ApiDbContext db;
        private readonly IIdGenerator idGenerator;

        public CustomerRepository(ApiDbContext db, IIdGenerator idGenerator)
        {
            this.db = db;
            this.idGenerator = idGenerator;
        }

        public async Task<Customer> AddCustomer(CreateCustomerDto createCustomerDto, int accountId)
        {
            if (await db.Customers.SingleOrDefaultAsync(s => s.Email == createCustomerDto.Email || s.Bvn == createCustomerDto.Bvn || s.Telephone == createCustomerDto.Telephone) == null)
            {
                var customer = new Customer { Telephone = createCustomerDto.Telephone, Title = createCustomerDto.Title, Bvn = createCustomerDto.Bvn, Email = createCustomerDto.Email, FirstName = createCustomerDto.FirstName, MiddleName = createCustomerDto.MiddleName, LastName = createCustomerDto.LastName, ClientType = createCustomerDto.ClientType, DOB = createCustomerDto.DOB, Gender = createCustomerDto.Gender, HomeAddress = createCustomerDto.HomeAddress, LandMarkOrBustop = createCustomerDto.LandMarkOrBustop, Nationality = createCustomerDto.Nationality, State = createCustomerDto.State, WorkType = createCustomerDto.WorkType, AccountId = accountId, IdNumber = idGenerator.GenerateIdNumber() };
                var result = await db.Customers.AddAsync(customer);
                await db.SaveChangesAsync();
                return result.Entity;
            }
            return null;
        }

        public async Task<Customer> GetCustomerById(int Id)
        {
            var customer = await db.Customers.FindAsync(Id);
            return customer;
        }

        public async Task<Customer> GetCustomerByIdNumber(string IdNumber)
        {
            var customer = await db.Customers.SingleOrDefaultAsync(c => c.IdNumber == IdNumber);
            return customer;
        }

        public async Task<IEnumerable<Customer>> GetCustomers()
        {
            var customers = await db.Customers.ToListAsync();
            return customers;
        }
    }
}
