using TechSteps.Api.Entities;
using TechSteps.Dtos.Models;

namespace TechSteps.Api.Repositories.Contracts
{
    public interface IDepositRepository
    {
        Task<Deposit> CreateDeposit(CreateDepositDto createDepositDto, int customerId);
        Task<Deposit> GetDeposit(int Id);
        Task<Deposit> GetDepositByCustomerId(int CustomerId);
        Task<IEnumerable<Deposit>> GetAllDeposits();
        Task<IEnumerable<Deposit>> GetDepositsByCustomerId(int CustomerId);
    }
}
