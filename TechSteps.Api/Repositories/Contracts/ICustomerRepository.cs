using TechSteps.Api.Entities;
using TechSteps.Dtos.Models;

namespace TechSteps.Api.Repositories.Contracts
{
    public interface ICustomerRepository
    {
        Task<IEnumerable<Customer>> GetCustomers();

        Task<Customer> GetCustomerById(int Id);
        Task<Customer> GetCustomerByIdNumber(string IdNumber);

        Task<Customer> AddCustomer(CreateCustomerDto createCustomerDto, int accountId);
    }
}
