using Microsoft.AspNetCore.StaticFiles;
using StudyHard.Common.Dto;
using StudyHard.Common.Dto.AzureBlob;
using StudyHard.Common.Managers.AzureBlob;
using StudyHard.Common.Managers.Files;
using StudyHard.Data.Repository;
using StudyHard.Dto.Blog;
using StudyHard.Dto.Containers;
using StudyHard.Services.Mappers.Blog;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace StudyHard.Services.Blog
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

        public async Task<PaginatedDto<BlogSectionDto>> GetActivePaginatedBlogsAsync(PaginationDto paginationDto, CancellationToken cancellationToken)
        {
            var result = await _repository.BlogDataAccess.GetActivePaginatedBlogsAsync(paginationDto.Page, paginationDto.PageSize, cancellationToken);
            return new PaginatedDto<BlogSectionDto>
            {
                Count = result.Count,
                PaginatedList = result.Elements.MapToDto(),
                Page = paginationDto.Page,
                PageSize = paginationDto.PageSize
            };
        }

        public async Task<BlogSectionDto> GetBlogSectionByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            var blogSection = await _repository.BlogDataAccess.GetByIdAsync(id, cancellationToken);

            return blogSection.MapToDto();
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
    }
}
