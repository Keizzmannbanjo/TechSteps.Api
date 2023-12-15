using Microsoft.EntityFrameworkCore;
using TechSteps.Api.Data;
using TechSteps.Api.Entities;
using TechSteps.Api.Repositories.Contracts;

namespace TechSteps.Api.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly ApiDbContext db;

        public AccountRepository(ApiDbContext db)
        {
            this.db = db;
        }
        public async Task<Account> CreateAccount(Account account)
        {
            if (await db.Accounts.SingleOrDefaultAsync(a => a.Name == account.Name && a.AccountNumber == account.AccountNumber) == null)
            {
                var result = await db.Accounts.AddAsync(account);
                await db.SaveChangesAsync();
                return result.Entity;
            }
            return null;
        }

        public async Task<Account> GetAccountById(int Id)
        {
            var account = await db.Accounts.FindAsync(Id);
            return account;
        }

        public async Task<Account> GetAccountByNumber(string AccountNumber)
        {
            var account = await db.Accounts.SingleOrDefaultAsync(a => a.AccountNumber == AccountNumber);
            return account;
        }

        public async Task<IEnumerable<Account>> GetAccounts()
        {
            var accounts = await db.Accounts.ToListAsync();
            return accounts;
        }

        public async Task<bool> UpdateAccount(Account account)
        {
            if (await db.Accounts.SingleOrDefaultAsync(a => a.Id == account.Id) != null)
            {
                db.Accounts.Update(account);
                await db.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}
