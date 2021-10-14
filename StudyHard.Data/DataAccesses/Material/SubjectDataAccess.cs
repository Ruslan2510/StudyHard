using Microsoft.EntityFrameworkCore;
using StudyHard.Data.Entity.Subject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace StudyHard.Data.DataAccesses.Material
{
    public class SubjectDataAccess : BaseDataAccess<Subject>
    {
        internal SubjectDataAccess(StudyHardApplicationContext applicationContext) :
            base(applicationContext) { }

        public async Task<(List<Subject> Elements, int Count)> GetPagainatedSubjectsAsync(int page, int pageSize, CancellationToken cancellationToken)
        {
            var elementsList = await _appContext.Subjects
                                                    .Skip(page * pageSize)
                                                    .Take(pageSize)
                                                    .OrderBy(x => x.Name)
                                                    .ToListAsync(cancellationToken);

            var count = await _appContext.Subjects.CountAsync(cancellationToken);

            return (elementsList, count);
        }

        public async Task<Subject> GetSubjectByIdAsync(Guid subjectId, CancellationToken cancellationToken)
        {
            return await _appContext.Subjects
                .Include(x => x.Categories)
                .FirstOrDefaultAsync(x => x.Id == subjectId, cancellationToken);
        }

        public async Task UpdateSubjectAsync(Subject subject, CancellationToken cancellationToken)
        {
            _appContext.Update(subject);
            await _appContext.SaveChangesAsync(cancellationToken);
        }

        public async Task ChangeSubjectPropertyActiveAsync(Subject subject, CancellationToken cancellationToken)
        {
            _appContext.Entry(subject).Property(nameof(Subject.IsActive)).IsModified = true;
            await _appContext.SaveChangesAsync(cancellationToken);
        }
    }
}
