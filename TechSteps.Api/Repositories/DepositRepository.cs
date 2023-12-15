using Microsoft.EntityFrameworkCore;
using TechSteps.Api.Data;
using TechSteps.Api.Entities;
using TechSteps.Api.Repositories.Contracts;
using TechSteps.Dtos.Models;

namespace TechSteps.Api.Repositories
{
    public class DepositRepository : IDepositRepository
    {
        private readonly ApiDbContext db;

        public DepositRepository(ApiDbContext db)
        {
            this.db = db;
        }
        public async Task<Deposit> CreateDeposit(CreateDepositDto createDepositDto, int customerId)
        {
            var result = await db.Deposits.AddAsync(new Deposit { Amount = createDepositDto.Amount, Comment = createDepositDto.Comment, CustomerId = customerId, DateEffective = createDepositDto.DateEffective, InterestType = createDepositDto.InterestType, MaturityAmount = createDepositDto.MaturityAmount, MaturityDate = createDepositDto.MaturityDate, Tenure = createDepositDto.Tenure, Rate = createDepositDto.Rate });
            await db.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<IEnumerable<Deposit>> GetAllDeposits()
        {
            var deposits = await db.Deposits.ToListAsync();
            return deposits;
        }

        public async Task<Deposit> GetDeposit(int Id)
        {
            var deposit = await db.Deposits.FindAsync(Id);
            return deposit;
        }

        public async Task<Deposit> GetDepositByCustomerId(int CustomerId)
        {
            var deposit = await db.Deposits.SingleOrDefaultAsync(d => d.CustomerId == CustomerId);
            return deposit;
        }

        public async Task<IEnumerable<Deposit>> GetDepositsByCustomerId(int CustomerId)
        {
            var deposits = await db.Deposits.Where(d => d.CustomerId == CustomerId).ToListAsync();
            return deposits;
        }
    }
}
