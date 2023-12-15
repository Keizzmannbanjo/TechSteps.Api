using Microsoft.AspNetCore.Mvc;
using TechSteps.Api.Entities;
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
        private readonly IBankRepository bankRepository;
        private readonly IAccountRepository accountRepository;
        private readonly INextOfKinRepository nextOfKinRepository;

        public CustomersController(ICustomerRepository customerRepository, IBankRepository bankRepository, IAccountRepository accountRepository, INextOfKinRepository nextOfKinRepository)
        {
            this.customerRepository = customerRepository;
            this.bankRepository = bankRepository;
            this.accountRepository = accountRepository;
            this.nextOfKinRepository = nextOfKinRepository;
        }

        [HttpGet("{Id}")]
        public async Task<ActionResult<CustomerDto>> GetCustomer(int Id)
        {
            try
            {
                var customer = await customerRepository.GetCustomerById(Id);

                if (customer != null)
                {
                    var nextOfKin = await nextOfKinRepository.GetNextOfKinByCustomerId(Id);
                    if (nextOfKin != null)
                    {
                        var account = await accountRepository.GetAccountById(customer.AccountId);
                        if (account != null)
                        {
                            var bank = await bankRepository.GetBank(account.BankId);
                            if (bank != null)
                            {
                                var customerDto = customer.ConvertToDto(bank, account, nextOfKin);
                                return Ok(customerDto);
                            }
                        }
                    }
                }
                return NotFound("Unable to find customer full data");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error in retrieving data from database");
            }
        }

        [HttpGet]
        [Route("GetByIdNumber")]
        public async Task<ActionResult<CustomerDto>> FindCustomerByIdNumber(string IdNumber)
        {
            try
            {
                var customer = await customerRepository.GetCustomerByIdNumber(IdNumber);

                if (customer != null)
                {
                    var nextOfKin = await nextOfKinRepository.GetNextOfKinByCustomerId(customer.Id);
                    if (nextOfKin != null)
                    {
                        var account = await accountRepository.GetAccountById(customer.AccountId);
                        if (account != null)
                        {
                            var bank = await bankRepository.GetBank(account.BankId);
                            if (bank != null)
                            {
                                var customerDto = customer.ConvertToDto(bank, account, nextOfKin);
                                return Ok(customerDto);
                            }
                        }
                    }
                }
                return NotFound("Unable to find customer full data");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error in retrieving data from database");
            }
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

        [HttpPost]
        public async Task<ActionResult<CustomerDto>> PostCustomer(CreateCustomerDto createCustomerDto)
        {
            try
            {
                var bank = await bankRepository.AddBank(createCustomerDto.BankName);
                if (bank != null)
                {
                    var account = await accountRepository.CreateAccount(new Account { AccountNumber = createCustomerDto.AccountNumber, Name = createCustomerDto.BankName, BankId = bank.Id });
                    if (account != null)
                    {
                        var customer = await customerRepository.AddCustomer(createCustomerDto, account.Id);
                        if (customer != null)
                        {
                            var nextOfKin = await nextOfKinRepository.AddNextOfKin(new NextOfKin { FullName = createCustomerDto.NextOfKinFullName, Telephone = createCustomerDto.NextOfKinTelephone, Relationship = createCustomerDto.NextOfKinRelationship, RelatedCustomerId = customer.Id });
                            if (nextOfKin != null)
                            {
                                var customerDto = customer.ConvertToDto(bank, account, nextOfKin);
                                return CreatedAtAction(nameof(GetCustomer), new { Id = customer.Id }, customerDto);
                            }

                        }
                    }
                }
                return NotFound("Unable to complete operation");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error in completing post request");
            }
        }
    }
}
