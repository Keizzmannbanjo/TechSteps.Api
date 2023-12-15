using TechSteps.Api.Entities;
using TechSteps.Dtos.Models;

namespace TechSteps.Api.Extensions
{
    public static class DtoConversions
    {
        public static IEnumerable<CustomerHomeDto> ConvertToHomeDto(this IEnumerable<Customer> customers)
        {
            return (from customer in customers select new CustomerHomeDto { Id = customer.Id, IdNumber = customer.IdNumber, ClientType = customer.ClientType, Email = customer.Email, FirstName = customer.FirstName, Gender = customer.Gender, LastName = customer.LastName, MiddleName = customer.MiddleName, Telephone = customer.Telephone, Title = customer.Title, WorkType = customer.WorkType });
        }

        public static CustomerDto ConvertToDto(this Customer customer, Bank bank, Account account, NextOfKin nextOfKin)
        {
            return new CustomerDto { Id = customer.Id, IdNumber = customer.IdNumber, FirstName = customer.FirstName, MiddleName = customer.MiddleName, LastName = customer.LastName, Gender = customer.Gender, Email = customer.Email, ClientType = customer.ClientType, DOB = customer.DOB, HomeAddress = customer.HomeAddress, LandMarkOrBustop = customer.LandMarkOrBustop, Nationality = customer.Nationality, State = customer.State, Title = customer.Title, WorkType = customer.WorkType, Telephone = customer.Telephone, AccountName = account.Name, AccountNumber = account.AccountNumber, BankName = bank.Name, NextOfKinFullName = nextOfKin.FullName, NextOfKinRelationship = nextOfKin.Relationship, NextOfKinTelephone = nextOfKin.Telephone };
        }


        public static StaffDto ConvertToDto(this Staff staff)
        {
            return new StaffDto { Id = staff.Id, Email = staff.Email, FirstName = staff.FirstName, MiddleName = staff.MiddleName, LastName = staff.LastName, JobPosition = staff.JobPosition };
        }

        public static IEnumerable<StaffDto> ConvertToDto(this IEnumerable<Staff> staffs)
        {
            return (from staff in staffs
                    select new StaffDto
                    {
                        Id = staff.Id,
                        Email = staff.Email,
                        FirstName = staff.FirstName,
                        JobPosition = staff.JobPosition,
                        LastName = staff.LastName,
                        MiddleName = staff.MiddleName
                    });
        }

        public static DepositDto ConvertToDto(this Deposit deposit, Customer customer, Account account, Bank bank)
        {
            return new DepositDto { Id = deposit.Id, DateCreated = deposit.DateCreated, DateEffective = deposit.DateEffective, MaturityDate = deposit.MaturityDate, Amount = deposit.Amount, MaturityAmount = deposit.MaturityAmount, Rate = deposit.Rate, Tenure = deposit.Tenure, InterestType = deposit.InterestType, Comment = deposit.Comment, ClientFullName = customer.FirstName + " " + customer.MiddleName + " " + customer.LastName, ClientType = customer.ClientType, ClientBankName = bank.Name, AccountName = account.Name, AccountNumber = account.AccountNumber, AccountBalance = account.Balance };
        }

        public static IEnumerable<DepositDto> ConvertToDto(this IEnumerable<Deposit> deposits, IEnumerable<Customer> customers, IEnumerable<Account> accounts, IEnumerable<Bank> banks)
        {
            return (from deposit in deposits join customer in customers on deposit.CustomerId equals customer.Id join account in accounts on customer.AccountId equals account.Id join bank in banks on account.BankId equals bank.Id select new DepositDto { Id = deposit.Id, DateCreated = deposit.DateCreated, DateEffective = deposit.DateEffective, MaturityDate = deposit.MaturityDate, Amount = deposit.Amount, MaturityAmount = deposit.MaturityAmount, Rate = deposit.Rate, Tenure = deposit.Tenure, InterestType = deposit.InterestType, Comment = deposit.Comment, ClientFullName = customer.FirstName + " " + customer.MiddleName + " " + customer.LastName, ClientType = customer.ClientType, ClientBankName = bank.Name, AccountName = account.Name, AccountNumber = account.AccountNumber, AccountBalance = account.Balance });
        }
    }
}
