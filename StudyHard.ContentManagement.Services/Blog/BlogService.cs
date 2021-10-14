using StudyHard.Common.Dto.File;
using StudyHard.Data.Entity;
using StudyHard.Data.Repository;
using StudyHard.Dto.Containers;
using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using StudyHard.Common.Managers.AzureBlob;
using StudyHard.Common.Managers.Files;
using StudyHard.Common.Dto;
using StudyHard.Common.Dto.AzureBlob;
using FileEntity = StudyHard.Data.Entity.File;
using Microsoft.AspNetCore.StaticFiles;
using StudyHard.ContentManagement.Dto.Blog;
using StudyHard.ContentManagement.Services.Mappers.Blog;

namespace StudyHard.ContentManagement.Services.Blog
{
    public class BlogService : IBlogService
    {
        private readonly StudyHardRepository _repository;
        private readonly IBlobManager _blobService;
        private readonly IFileManager _fileService;

        public BlogService(StudyHardRepository repository, IBlobManager blobService, IFileManager fileService)
        {
            _repository = repository;
            _blobService = blobService;
            _fileService = fileService;
        }

        public async Task<PaginatedDto<BlogSectionDto>> GetPaginatedBlogsAsync(PaginationDto paginationDto, CancellationToken cancellationToken)
        {
            var result = await _repository.BlogDataAccess.GetPaginatedBlogsAsync(paginationDto.Page, paginationDto.PageSize, cancellationToken);
            return new PaginatedDto<BlogSectionDto>
            {
                Count = result.Count,
                PaginatedList = result.Elements.MapToDto(),
                Page = paginationDto.Page,
                PageSize = paginationDto.PageSize
            };
        }

        public async Task CreateBlogAsync(BlogSectionDto blogSectionDto, CancellationToken cancellationToken)
        {
            var blogSection = blogSectionDto.MapToEntity();
            blogSection.CreatedDateUTC = DateTime.UtcNow;

            await _repository.BlogDataAccess.AddAsync(blogSection, cancellationToken);
        }

        public async Task UpdateBlogAsync(BlogSectionDto blogSectionDto, CancellationToken cancellationToken)
        {
            var blogSection = blogSectionDto.MapToEntity();
            await _repository.BlogDataAccess.UpdateBlogSectionAsync(blogSection, cancellationToken);
        }

        public async Task<BlogSectionDto> GetBlogSectionByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            var blogSection = await _repository.BlogDataAccess.GetByIdAsync(id, cancellationToken);

            return blogSection.MapToDto();
        }

        public async Task ChangeBlogPropertyActiveAsync(Guid id, CancellationToken cancellationToken)
        {
            var blogSection = await _repository.BlogDataAccess.GetByIdAsync(id, cancellationToken);
            blogSection.IsActive = !blogSection.IsActive;

            await _repository.BlogDataAccess.ChangeBlogPropertyActiveAsync(blogSection, cancellationToken);
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
            catch(Exception ex)
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