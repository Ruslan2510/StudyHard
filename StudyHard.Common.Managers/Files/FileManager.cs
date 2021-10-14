using StudyHard.Common.Dto.File;
using StudyHard.Common.Managers.Mappers.File;
using StudyHard.Data.Repository;
using System;
using System.Threading;
using System.Threading.Tasks;
using FileEntity = StudyHard.Data.Entity.File;

namespace StudyHard.Common.Managers.Files
{
    public class FileManager : IFileManager
    {
        private readonly StudyHardRepository _repository;

        public FileManager(StudyHardRepository repository)
        {
            _repository = repository;
        }

        public async Task<FileEntity> CreateFileAsync(FileEntity file, CancellationToken cancellationToken)
        {
            await _repository.FileDataAccess.AddAsync(file, cancellationToken);
            return file;
        }

        public async Task<FileEntity> GetFileByIdAsync(Guid fileId, CancellationToken cancellationToken)
        {
            return await _repository.FileDataAccess.GetFileByIdAsync(fileId, cancellationToken);
        }

        public async Task DeleteFileAsync(FileDto fileDto, CancellationToken cancellationToken)
        {
            var file = fileDto.MapToEntity();
            await _repository.FileDataAccess.DeleteAsync(file, cancellationToken);
        }

        public async Task UpdateFileAsync(FileEntity file, CancellationToken cancellationToken)
        {
            await _repository.FileDataAccess.Update(file, cancellationToken);
        }
    }
}
