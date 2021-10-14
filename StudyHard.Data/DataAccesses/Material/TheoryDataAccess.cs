using Microsoft.EntityFrameworkCore;
using StudyHard.Data.Entity.Theory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace StudyHard.Data.DataAccesses.Material
{
    public class TheoryDataAccess : BaseDataAccess<Theory>
    {
        internal TheoryDataAccess(StudyHardApplicationContext applicationContext) : base(applicationContext)
        {
        }

        public async Task<(List<Theory> Elements, int Count)> GetPaginatedTheoriesByCategoryIdAsync(int page, int pageSize,
        Guid categoryId, CancellationToken cancellationToken)
        {
            var elementsList = await _appContext.Theories
                .Include(x => x.Category)
                .Where(x => x.CategoryId == categoryId)
                .Skip(page * pageSize)
                .Take(pageSize)
                .ToListAsync(cancellationToken);

            var count = await _appContext.Theories
                .Include(x => x.Category)
                .CountAsync(x => x.CategoryId == categoryId, cancellationToken);

            return (elementsList, count);
        }

        public async Task<Theory> GetTheoryByIdAsync(Guid id, CancellationToken cacellationToken)
        {
            return await _appContext.Theories
                .Include(x => x.Category)
                .ThenInclude(x => x.Subject)
                .FirstOrDefaultAsync(x => x.Id == id, cacellationToken);
        }

        public async Task UpdateTheoryAsync(Theory theory, CancellationToken cancellationToken)
        {
            _appContext.Update(theory);
            await _appContext.SaveChangesAsync(cancellationToken);
        }
    }
}
