using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace StudyHard.Data.DataAccesses
{
    public class BaseDataAccess<T> where T : class
    {
        protected readonly StudyHardApplicationContext _appContext;

        internal BaseDataAccess(StudyHardApplicationContext applicationContext)
        {
            _appContext = applicationContext;
        }

        public async Task AddAsync(T entity, CancellationToken cancellationToken)
        {
            await _appContext.Set<T>().AddAsync(entity);
            await _appContext.SaveChangesAsync(cancellationToken);
        }

        public async Task AddRangeAsync(IEnumerable<T> entity, CancellationToken cancellationToken)
        {
            await _appContext.Set<T>().AddRangeAsync(entity);
            await _appContext.SaveChangesAsync(cancellationToken);
        }

        public async Task DeleteAsync(T entity, CancellationToken cancellationToken)
        {
            _appContext.Set<T>().Remove(entity);
            await _appContext.SaveChangesAsync(cancellationToken);
        }
        
        public async Task Update(T entity, CancellationToken cancellationToken)
        {
            _appContext.Entry(entity).State = EntityState.Modified;
            _appContext.Set<T>().Attach(entity);
            await _appContext.SaveChangesAsync(cancellationToken);
        }
    }
}
