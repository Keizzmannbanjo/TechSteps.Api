using TechSteps.Api.Entities;

namespace TechSteps.Api.Repositories.Contracts
{
    public interface INextOfKinRepository
    {
        Task<NextOfKin> AddNextOfKin(NextOfKin nextOfKin);
        Task<NextOfKin> GetNextOfKin(int Id);
        Task<NextOfKin> GetNextOfKinByCustomerId(int CustomerId);
        Task<IEnumerable<NextOfKin>> GetAll();
    }
}
