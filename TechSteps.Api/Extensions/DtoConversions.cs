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

        public static StaffDto ConvertToDto(this Staff staff)
        {
            return new StaffDto { Id = staff.Id, Email = staff.Email, FirstName = staff.FirstName, MiddleName = staff.MiddleName, LastName = staff.LastName, JobPosition = staff.JobPosition };
        }
    }
}
