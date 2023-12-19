using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TechSteps.Api.Entities;
using TechSteps.Api.Repositories.Contracts;
using TechSteps.Dtos.Models;

namespace TechSteps.Api.Repositories
{
    public class StaffRepository : IStaffRepository
    {
        private readonly UserManager<Staff> userManager;
        private readonly SignInManager<Staff> signInManager;

        public StaffRepository(UserManager<Staff> userManager, SignInManager<Staff> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }
        public async Task<Staff> AddStaff(CreateStaffDto createStaffDto)
        {
            var checkIfExist = await userManager.FindByEmailAsync(createStaffDto.Email);
            if (checkIfExist == null)
            {
                var newStaff = new Staff { Email = createStaffDto.Email, FirstName = createStaffDto.FirstName, UserName = createStaffDto.Email, MiddleName = createStaffDto.MiddleName, LastName = createStaffDto.LastName, JobPosition = createStaffDto.JobPosition };
                var result = await userManager.CreateAsync(newStaff, createStaffDto.Password);
                if (result.Succeeded)
                {
                    newStaff = await userManager.FindByEmailAsync(newStaff.Email);
                    return newStaff;
                }
            }
            return null;
        }

        public async Task<bool> AuthenticateStaff(StaffSignInDto staffSignInDto)
        {
            var staff = await userManager.FindByEmailAsync(staffSignInDto.Email);
            if (staff != null)
            {
                var result = await signInManager.PasswordSignInAsync(staff, staffSignInDto.Password, false, true);
                if (result.Succeeded)
                {
                    return true;
                }
            }
            return false;
        }

        public async Task<Staff> GetStaffById(string Id)
        {
            var staff = await userManager.FindByIdAsync(Id);
            return staff;
        }

        public async Task<IEnumerable<Staff>> GetStaffs()
        {
            var staffs = await userManager.Users.ToListAsync();
            return staffs;
        }
    }
}
