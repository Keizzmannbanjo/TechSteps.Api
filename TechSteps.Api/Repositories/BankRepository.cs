using Microsoft.EntityFrameworkCore;
using TechSteps.Api.Data;
using TechSteps.Api.Entities;
using TechSteps.Api.Repositories.Contracts;

namespace TechSteps.Api.Repositories
{
    public class BankRepository : IBankRepository
    {
        private readonly ApiDbContext db;

        public BankRepository(ApiDbContext db)
        {
            this.db = db;
        }
        public async Task<Bank> AddBank(string bankName)
        {
            if (await db.Banks.SingleOrDefaultAsync(b => b.Name == bankName) == null)
            {
                var bank = new Bank { Name = bankName };
                var result = await db.Banks.AddAsync(bank);
                await db.SaveChangesAsync();
                return result.Entity;
            }
            else
            {
                return await db.Banks.SingleOrDefaultAsync(b => b.Name == bankName);
            }
            return null;
        }
    }
}
