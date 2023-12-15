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

        public async Task<Bank> GetBank(string bankName)
        {
            var bank = await db.Banks.SingleOrDefaultAsync(b => b.Name == bankName);
            return bank;
        }

        public async Task<Bank> GetBank(int Id)
        {
            var bank = await db.Banks.FindAsync(Id);
            return bank;
        }

        public async Task<IEnumerable<Bank>> GetBanks()
        {
            var banks = await db.Banks.ToListAsync();
            return banks;
        }
    }
}
