using StudyHard.Common.Dto;
using StudyHard.Common.Dto.AzureBlob;
using StudyHard.Common.Dto.File;
using StudyHard.ContentManagement.Dto.Blog;
using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace StudyHard.ContentManagement.Services.Blog
{
    public interface IBlogService
    {
        Task<PaginatedDto<BlogSectionDto>> GetPaginatedBlogsAsync(PaginationDto paginationDto, CancellationToken cancellationToken);
        Task CreateBlogAsync(BlogSectionDto blogSectionDto, CancellationToken cancellationToken);
        Task<BlogSectionDto> GetBlogSectionByIdAsync(Guid id, CancellationToken cancellationToken);
        Task UpdateBlogAsync(BlogSectionDto blogSectionDto, CancellationToken cancellationToken);
        Task ChangeBlogPropertyActiveAsync(Guid id, CancellationToken cancellationToken);
        Task<Guid> AddBlobAsync(Stream stream, string name, string ext, CancellationToken cancellationToken);
        Task<BlobFileDto> GetBlobAsync(Guid fileId, CancellationToken cancellationToken);
        Task DeleteBlobAsync(FileDto file, CancellationToken cancellationToken);
    }
}
