using TechSteps.Api.Entities;
using TechSteps.Api.Repositories.Contracts;

namespace TechSteps.Api.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        public Task<Account> CreateAccount(Account account)
        {
            throw new NotImplementedException();
        }

        public Task<Account> GetAccountById(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<Account> GetAccountByNumber(string AccountNumber)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Account>> GetAccounts()
        {
            throw new NotImplementedException();
        }
    }
}
