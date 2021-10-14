using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;
using FileEntity = StudyHard.Data.Entity.File;

namespace StudyHard.Data.DataAccesses.File
{
    public class FileDataAccess : BaseDataAccess<FileEntity>
    {
        internal FileDataAccess(StudyHardApplicationContext applicationContext) 
            : base(applicationContext)
        {
        }

        public async Task<FileEntity> GetFileByIdAsync(Guid fileId, CancellationToken cancellationToken)
        {
            return await _appContext.Files.FirstOrDefaultAsync(x => x.Id == fileId, cancellationToken);
        }
    }
}
