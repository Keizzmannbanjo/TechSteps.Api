using TechSteps.Api.Entities;
using TechSteps.Dtos.Models;

namespace TechSteps.Api.Repositories.Contracts
{
    public interface IStaffRepository
    {
        Task<IEnumerable<Staff>> GetStaffs();
        Task<Staff> AddStaff(CreateStaffDto createStaffDto);
        Task<Staff> GetStaffById(string Id);
        Task<bool> AuthenticateStaff(StaffSignInDto staffSignInDto);
    }
}
