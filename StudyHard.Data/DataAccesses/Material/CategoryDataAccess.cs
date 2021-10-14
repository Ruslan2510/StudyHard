using Microsoft.EntityFrameworkCore;
using StudyHard.Data.Entity.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace StudyHard.Data.DataAccesses.Material
{
    public class CategoryDataAccess : BaseDataAccess<Category>
    {
        internal CategoryDataAccess(StudyHardApplicationContext applicationContext) : base(applicationContext)
        {  
        }

        public async Task<(List<Category> Elements, int Count)> GetPaginatedCategoriesBySubjectId(int page, int pageSize, 
            Guid subjectId, CancellationToken cancellationToken)
        {
            var elementsList = await _appContext.Categories
                .Include(x => x.Subject)
                .Where(x => x.SubjectId == subjectId)
                .Skip(page * pageSize)
                .Take(pageSize)
                .ToListAsync(cancellationToken);

            var count = await _appContext.Categories
                .CountAsync(x => x.SubjectId == subjectId, cancellationToken);

            return (elementsList, count);
        }

        public async Task UpdateCategoryAsync(Category category, CancellationToken cancellationToken)
        {
            _appContext.Update(category);
            await _appContext.SaveChangesAsync(cancellationToken);
        }

        public async Task<Category> GetCategoryByIdAsync(Guid categoryId, CancellationToken cancellationToken)
        {
            return await _appContext.Categories
                .Include(x => x.Subject)
                .Include(x => x.TaskLists)
                .FirstOrDefaultAsync(x => x.Id == categoryId, cancellationToken);
        }
    }
}
