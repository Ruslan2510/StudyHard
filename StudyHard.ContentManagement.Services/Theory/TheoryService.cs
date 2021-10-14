using Microsoft.AspNetCore.StaticFiles;
using StudyHard.Common.Dto;
using StudyHard.Common.Dto.AzureBlob;
using StudyHard.Common.Dto.File;
using StudyHard.Common.Managers.AzureBlob;
using StudyHard.Common.Managers.Files;
using StudyHard.ContentManagement.Dto.Theory;
using StudyHard.ContentManagement.Services.Mappers.Theory;
using StudyHard.Data.Entity;
using StudyHard.Data.Repository;
using StudyHard.Dto.Containers;
using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using FileEntity = StudyHard.Data.Entity.File;

namespace StudyHard.ContentManagement.Services.Theory
{
    public class TheoryService : ITheoryService
    {
        private readonly StudyHardRepository _repository;
        private readonly IBlobManager _blobService;
        private readonly IFileManager _fileService;

        public TheoryService(StudyHardRepository repository, IBlobManager blobService, IFileManager fileService)
        {
            _repository = repository;
            _blobService = blobService;
            _fileService = fileService;
        }

        public async Task<PaginatedDto<TheoryDto>> GetPaginatedTheoriesByCategoryIdAsync(TheoryPaginationDto theoryPaginationDto, CancellationToken cancellationToken)
        {
            var result = await _repository.TheoryDataAccess
                .GetPaginatedTheoriesByCategoryIdAsync(theoryPaginationDto.Page, theoryPaginationDto.PageSize,
                                                       theoryPaginationDto.CategoryId, cancellationToken);
            return new PaginatedDto<TheoryDto>
            {
                Count = result.Count,
                PaginatedList = result.Elements.MapToDtos(),
                Page = theoryPaginationDto.Page,
                PageSize = theoryPaginationDto.PageSize
            };
        }

        public async Task<TheoryDto> GetTheoryByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            var theory = await _repository.TheoryDataAccess.GetTheoryByIdAsync(id, cancellationToken);
            return theory.MapToDto();
        }

        public async Task CreateTheoryAsync(TheoryDto theoryDto, CancellationToken cancellationToken)
        {
            theoryDto.CreatedDateUTC = DateTime.UtcNow;
            var theorySection = theoryDto.MapToEntity();
            await _repository.TheoryDataAccess.AddAsync(theorySection, cancellationToken);
        }

        public async Task UpdateTheoryAsync(TheoryDto theoryDto, CancellationToken cancellationToken)
        {
            var theory = theoryDto.MapToEntity();
            await _repository.TheoryDataAccess.UpdateTheoryAsync(theory, cancellationToken);
        }

        public async Task DeleteTheoryAsync(TheoryDto theoryDto, CancellationToken cancellationToken)
        {
            try
            {
                var theory = theoryDto.MapToEntity();
                await _repository.TheoryDataAccess.DeleteAsync(theory, cancellationToken);
            }
            catch (Exception)
            {
                throw new Exception("Идентификатор теории не найден");
            }
        }

        public async Task<BlobFileDto> GetBlobAsync(Guid fileId, CancellationToken cancellationToken)
        {
            var file = await _fileService.GetFileByIdAsync(fileId, cancellationToken);

            var provider = new FileExtensionContentTypeProvider();

            var fileName = $"{file.Id}{file.Extention}";

            if (!provider.TryGetContentType(fileName, out var contentType))
            {
                contentType = "application/octet-stream";
            }

            var result = new BlobFileDto
            {
                File = await _blobService.GetAsync(fileName, BlobContainers.Blog, cancellationToken),
                ContentType = contentType,
                Name = fileName,
                Id = fileId
            };

            return result;
        }

        public async Task<Guid> AddBlobAsync(Stream stream, string name, string ext, CancellationToken cancellationToken)
        {
            string containerName = BlobContainers.Blog;
            stream.Position = 0;

            FileEntity file = new FileEntity
            {
                Name = name,
                Extention = ext,
                State = State.InProcess
            };

            await _fileService.CreateFileAsync(file, cancellationToken);

            string blobName = file.Id.ToString() + file.Extention;

            try
            {
                await _blobService.UploadAsync(stream, blobName, containerName, cancellationToken);
                file.State = State.Done;
            }
            catch (Exception ex)
            {
                file.State = State.Error;
                file.ErrorMessage = ex.Message;
            }

            await _fileService.UpdateFileAsync(file, cancellationToken);

            return file.Id;
        }

        public async Task DeleteBlobAsync(FileDto file, CancellationToken cancellationToken)
        {
            var fileName = file.Id.ToString() + file.Extention;
            await _blobService.DeleteAsync(fileName, BlobContainers.Blog, cancellationToken);
            await _fileService.DeleteFileAsync(file, cancellationToken);
        }
    }
}
