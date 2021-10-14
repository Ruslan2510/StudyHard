using Microsoft.EntityFrameworkCore;
using StudyHard.Data.Entity.Blog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace StudyHard.Data.DataAccesses.Blog
{
    public class BlogDataAccess : BaseDataAccess<BlogSection>
    {
        internal BlogDataAccess(StudyHardApplicationContext applicationContext)
            : base(applicationContext)
        {
        }

        public async Task<(List<BlogSection> Elements, int Count)> GetActivePaginatedBlogsAsync(int page, int pageSize, CancellationToken cancellationToken)
        {
            var elementsList = await _appContext.BlogSections
                                                    .Where(x => x.IsActive && x.DatePublicationUTC <= DateTime.UtcNow)
                                                    .Skip(page * pageSize)
                                                    .Take(pageSize)
                                                    .OrderByDescending(x => x.DatePublicationUTC)
                                                    .ToListAsync(cancellationToken);

            var count = await _appContext.BlogSections.CountAsync(x => x.IsActive && x.DatePublicationUTC <= DateTime.UtcNow, cancellationToken);

            return (elementsList, count);
        }

        public async Task<(List<BlogSection> Elements, int Count)> GetPaginatedBlogsAsync(int page, int pageSize, CancellationToken cancellationToken)
        {
            var elementsList = await _appContext.BlogSections
                                                    .Skip(page * pageSize)
                                                    .Take(pageSize)
                                                    .OrderByDescending(x => x.DatePublicationUTC)
                                                    .ToListAsync(cancellationToken);

            var count = await _appContext.BlogSections.CountAsync(cancellationToken);

            return (elementsList, count);
        }

        public async Task UpdateBlogSectionAsync(BlogSection blogSection, CancellationToken cancellationToken)
        {
            _appContext.Update(blogSection);
            await _appContext.SaveChangesAsync(cancellationToken);
        }

        public async Task<BlogSection> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            return await _appContext.BlogSections
                .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        }

        public async Task ChangeBlogPropertyActiveAsync(BlogSection blogSection, CancellationToken cancellationToken)
        {
            _appContext.Entry(blogSection).Property(nameof(BlogSection.IsActive)).IsModified = true;
            await _appContext.SaveChangesAsync(cancellationToken);
        }
    }
}