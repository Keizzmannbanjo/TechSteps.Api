using Microsoft.AspNetCore.Mvc;
using TechSteps.Api.Entities;
using TechSteps.Api.Extensions;
using TechSteps.Api.Repositories.Contracts;
using TechSteps.Dtos.Models;

namespace TechSteps.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StaffsController : ControllerBase
    {
        private readonly IStaffRepository staffRepository;
        private readonly IBankRepository bankRepository;

        public StaffsController(IStaffRepository staffRepository, IBankRepository bankRepository)
        {
            this.staffRepository = staffRepository;
            this.bankRepository = bankRepository;
        }

        [HttpGet("{Id}")]
        public async Task<ActionResult<Staff>> GetStaff(int Id)
        {
            try
            {
                var staff = await staffRepository.GetStaffById(Id);
                if (staff == null)
                {
                    return NotFound();
                }
                var staffDto = staff.ConvertToDto();
                return Ok(staffDto);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error in retrieving data");
            }
        }

        [HttpPost]
        public async Task<ActionResult<Staff>> PostStaff([FromBody] CreateStaffDto createStaffDto)
        {
            try
            {

                var newStaff = await staffRepository.AddStaff(createStaffDto);
                if (newStaff == null)
                {
                    return NoContent();
                }
                var staffDto = newStaff.ConvertToDto();
                return CreatedAtAction(nameof(GetStaff), new { Id = newStaff.Id }, staffDto);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);

            }
        }

        [HttpPost]
        [Route("SignIn")]
        public async Task<ActionResult> SignInStaff([FromBody] StaffSignInDto staffSignInDto)
        {
            try
            {
                var authenticate = await staffRepository.AuthenticateStaff(staffSignInDto);
                if (authenticate)
                {
                    return Ok(new { Message = "Welcome to the application", isSignedIn = authenticate });
                }
                else
                {
                    return BadRequest(new { Message = "Email or Password is incorrect, please try again", isSignedIn = false });
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error reaching database");
            }
        }
    }
}
