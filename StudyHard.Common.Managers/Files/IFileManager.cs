using StudyHard.Common.Dto.File;
using System;
using System.Threading;
using System.Threading.Tasks;
using FileEntity = StudyHard.Data.Entity.File;

namespace StudyHard.Common.Managers.Files
{
    public interface IFileManager
    {
        Task<FileEntity> CreateFileAsync(FileEntity file, CancellationToken cancellationToken);
        Task<FileEntity> GetFileByIdAsync(Guid fileId, CancellationToken cancellationToken);
        Task DeleteFileAsync(FileDto fileDto, CancellationToken cancellationToken);
        Task UpdateFileAsync(FileEntity file, CancellationToken cancellationToken);
    }
}
