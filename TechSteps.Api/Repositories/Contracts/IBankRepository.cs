using TechSteps.Api.Entities;

namespace TechSteps.Api.Repositories.Contracts
{
    public interface IBankRepository
    {
        Task<Bank> AddBank(string bankName);
    }
}
