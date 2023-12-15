using TechSteps.Api.Entities;

namespace TechSteps.Api.Repositories.Contracts
{
    public interface IBankRepository
    {
        Task<Bank> AddBank(string bankName);
        Task<Bank> GetBank(string bankName);
        Task<Bank> GetBank(int Id);
        Task<IEnumerable<Bank>> GetBanks();
    }
}
