using StudyHard.Common.Dto;
using StudyHard.Common.Dto.AzureBlob;
using StudyHard.Dto.Blog;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace StudyHard.Services.Blog
{
    public interface IBlogService
    {
        Task<PaginatedDto<BlogSectionDto>> GetActivePaginatedBlogsAsync(PaginationDto paginationDto, CancellationToken cancellationToken);
        Task<BlogSectionDto> GetBlogSectionByIdAsync(Guid id, CancellationToken cancellationToken);
        Task<BlobFileDto> GetBlobAsync(Guid fileId, CancellationToken cancellationToken);
    }
}
