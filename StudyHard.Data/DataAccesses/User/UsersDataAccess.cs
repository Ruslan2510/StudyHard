using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using UserEntity = StudyHard.Data.Entity.User;

namespace StudyHard.Data.DataAccesses.User
{
    public class UserDataAccess: BaseDataAccess<UserEntity>
    {        
        internal UserDataAccess(StudyHardApplicationContext applicationContext) : base(applicationContext)
        {
        }
        
        public async Task<UserEntity> GetUserByFieldAsync(Expression<Func<UserEntity, bool>> predicate, CancellationToken cancellationToken)
        {
            return await _appContext.Set<UserEntity>().Where(predicate).AsNoTracking().FirstOrDefaultAsync(cancellationToken);
        }
    }
}