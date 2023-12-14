using Microsoft.EntityFrameworkCore;
using TechSteps.Api.Data;
using TechSteps.Api.Entities;
using TechSteps.Api.Repositories.Contracts;
using TechSteps.Dtos.Models;

namespace TechSteps.Api.Repositories
{
    public class StaffRepository : IStaffRepository
    {
        private readonly ApiDbContext db;

        public StaffRepository(ApiDbContext db)
        {
            this.db = db;
        }
        public async Task<Staff> AddStaff(CreateStaffDto createStaffDto)
        {
            var checkIfExist = await db.Staffs.SingleOrDefaultAsync(c => c.Email == createStaffDto.Email);
            if (checkIfExist == null)
            {
                var newStaff = new Staff { Email = createStaffDto.Email, Password = createStaffDto.Password, FirstName = createStaffDto.FirstName, MiddleName = createStaffDto.MiddleName, LastName = createStaffDto.LastName, JobPosition = createStaffDto.JobPosition };
                var result = await db.Staffs.AddAsync(newStaff);
                await db.SaveChangesAsync();
                return result.Entity;
            }
            return null;
        }

        public async Task<bool> AuthenticateStaff(StaffSignInDto staffSignInDto)
        {
            var staff = await db.Staffs.SingleOrDefaultAsync(s => s.Email == staffSignInDto.Email && s.Password == staffSignInDto.Password);
            if (staff != null) { return true; }
            return false;
        }

        public async Task<Staff> GetStaffById(int Id)
        {
            var staff = await db.Staffs.SingleOrDefaultAsync(c => c.Id == Id);
            return staff;
        }

        public async Task<IEnumerable<Staff>> GetStaffs()
        {
            var staffs = await db.Staffs.ToListAsync();
            return staffs;
        }
    }
}
