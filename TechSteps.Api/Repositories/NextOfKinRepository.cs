using Microsoft.EntityFrameworkCore;
using TechSteps.Api.Data;
using TechSteps.Api.Entities;
using TechSteps.Api.Repositories.Contracts;

namespace TechSteps.Api.Repositories
{
    public class NextOfKinRepository : INextOfKinRepository
    {
        private readonly ApiDbContext db;

        public NextOfKinRepository(ApiDbContext db)
        {
            this.db = db;
        }
        public async Task<NextOfKin> AddNextOfKin(NextOfKin nextOfKin)
        {
            var result = await db.NextOfKins.AddAsync(nextOfKin);
            await db.SaveChangesAsync();
            return result.Entity;

        }

        public async Task<IEnumerable<NextOfKin>> GetAll()
        {
            var nextOfKins = await db.NextOfKins.ToListAsync();
            return nextOfKins;
        }

        public async Task<NextOfKin> GetNextOfKin(int Id)
        {
            var nextOfKin = await db.NextOfKins.FindAsync(Id);
            return nextOfKin;
        }

        public async Task<NextOfKin> GetNextOfKinByCustomerId(int CustomerId)
        {
            var nextOfKin = await db.NextOfKins.SingleOrDefaultAsync(n => n.RelatedCustomerId == CustomerId);
            return nextOfKin;
        }
    }
}
