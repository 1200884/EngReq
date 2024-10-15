using System;
using System.Threading.Tasks;
using Ether.Outcomes;
using Hapibee.Backend.Application.Domain;
using Microsoft.EntityFrameworkCore;

namespace Hapibee.Backend.Application.Infra.Data
{
    internal sealed class ApiaryRepositoryInMemory : IApiaryRepository
    {
        private readonly HapibeeDbContext _dbContext;

        public ApiaryRepositoryInMemory(HapibeeDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IOutcome> Delete(Apiary apiary)
        {
            var entityEntry = _dbContext.Remove(apiary);

            IOutcome outcome = entityEntry.State == EntityState.Deleted
                ? Outcomes.Success()
                : Outcomes.Failure();

            return await Task.FromResult(outcome);
        }

        public async Task<IOutcome<Apiary>> Find(string apiaryCode)
        {
            var lookup = await _dbContext.Apiaries
                .Include(x => x.Requests)
                .Include(x => x.Hives)
                .FirstOrDefaultAsync(x => x.ApiaryCode == apiaryCode);

            return lookup is not null
                ? Outcomes.Success(lookup)
                : Outcomes.Failure<Apiary>();
        }

        public async Task<IOutcome> Add(Apiary apiary)
        {
            var entityEntry = await _dbContext.Apiaries.AddAsync(apiary);

            return entityEntry.State == EntityState.Added
                ? Outcomes.Success()
                : Outcomes.Failure();
        }
    }
}