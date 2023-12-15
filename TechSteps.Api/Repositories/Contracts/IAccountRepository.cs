using TechSteps.Api.Entities;

namespace TechSteps.Api.Repositories.Contracts
{
    public interface IAccountRepository
    {
        Task<IEnumerable<Account>> GetAccounts();
        Task<Account> GetAccountById(int Id);
        Task<Account> GetAccountByNumber(string AccountNumber);
        Task<Account> CreateAccount(Account account);
        Task<bool> UpdateAccount(Account account);
    }
}
