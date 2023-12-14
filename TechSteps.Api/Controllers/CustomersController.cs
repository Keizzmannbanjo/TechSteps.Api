using Microsoft.AspNetCore.Mvc;
using TechSteps.Api.Extensions;
using TechSteps.Api.Repositories.Contracts;
using TechSteps.Dtos.Models;

namespace TechSteps.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerRepository customerRepository;

        public CustomersController(ICustomerRepository customerRepository)
        {
            this.customerRepository = customerRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CustomerHomeDto>>> GetCustomers()
        {
            try
            {
                var customers = await customerRepository.GetCustomers();
                if (customers == null)
                {
                    return NotFound();
                }
                else
                {
                    var customerHomeDtos = customers.ConvertToHomeDto();
                    return Ok(customerHomeDtos);
                }

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error in retrieving data");
            }
        }
    }
}
