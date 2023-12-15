using Microsoft.AspNetCore.Mvc;
using TechSteps.Api.Extensions;
using TechSteps.Api.Repositories.Contracts;
using TechSteps.Dtos.Models;

namespace TechSteps.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepositsController : ControllerBase
    {
        private readonly IDepositRepository depositRepository;
        private readonly IAccountRepository accountRepository;
        private readonly ICustomerRepository customerRepository;
        private readonly IBankRepository bankRepository;

        public DepositsController(IDepositRepository depositRepository, IAccountRepository accountRepository, ICustomerRepository customerRepository, IBankRepository bankRepository)
        {
            this.depositRepository = depositRepository;
            this.accountRepository = accountRepository;
            this.customerRepository = customerRepository;
            this.bankRepository = bankRepository;
        }

        [HttpGet("{Id}")]
        public async Task<ActionResult<DepositDto>> GetDeposit(int Id)
        {
            try
            {
                var deposit = await depositRepository.GetDeposit(Id);
                if (deposit != null)
                {
                    var customer = await customerRepository.GetCustomerById(deposit.CustomerId);
                    if (customer != null)
                    {
                        var account = await accountRepository.GetAccountById(customer.AccountId);
                        if (account != null)
                        {
                            var bank = await bankRepository.GetBank(account.BankId);
                            if (bank != null)
                            {
                                var depositDto = deposit.ConvertToDto(customer, account, bank);
                                return Ok(depositDto);
                            }
                        }
                    }
                }
                return NotFound("Error in finding record");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error in retrieving record from database");
            }
        }

        [HttpPost]
        public async Task<ActionResult<DepositDto>> PostDeposit([FromBody] CreateDepositDto createDepositDto)
        {
            try
            {
                var customer = await customerRepository.GetCustomerByIdNumber(createDepositDto.CustomerIdNumber);
                if (customer != null)
                {
                    var deposit = await depositRepository.CreateDeposit(createDepositDto, customer.Id);
                    if (deposit != null)
                    {
                        var account = await accountRepository.GetAccountById(customer.AccountId);
                        if (account != null)
                        {
                            account.Balance += deposit.Amount;
                            var accountUpdated = await accountRepository.UpdateAccount(account);
                            if (accountUpdated)
                            {
                                var bank = await bankRepository.GetBank(account.BankId);
                                if (bank != null)
                                {
                                    var depositDto = deposit.ConvertToDto(customer, account, bank);
                                    return CreatedAtAction(nameof(GetDeposit), new { Id = deposit.Id }, depositDto);
                                }
                            }
                        }
                    }
                }
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
