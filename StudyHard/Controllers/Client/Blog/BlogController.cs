using Microsoft.AspNetCore.Mvc;
using StudyHard.Common.Dto;
using StudyHard.Common.Dto.AzureBlob;
using StudyHard.Dto.Blog;
using StudyHard.Services.Blog;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace StudyHard.Web.Controllers.Blog
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        private readonly IBlogService _blogService;

        public BlogController(IBlogService blogService)
        {
            _blogService = blogService;
        }

        [HttpGet("{id}")]
        public async Task<BlogSectionDto> GetBlogById(Guid id, CancellationToken cancellationToken)
        {
            return await _blogService.GetBlogSectionByIdAsync(id, cancellationToken);
        }

        [HttpPost("bloglist")]
        public async Task<PaginatedDto<BlogSectionDto>> GetPaginatedBlogsAsync(PaginationDto paginationDto, CancellationToken cancellationToken)
        {
            return await _blogService.GetActivePaginatedBlogsAsync(paginationDto, cancellationToken);
        }

        [HttpGet("image/{fileid}")]
        public async Task<IActionResult> GetBlobAsync(Guid fileid, CancellationToken cancellationToken)
        {
            BlobFileDto blobItem = await _blogService.GetBlobAsync(fileid, cancellationToken);

            return File(blobItem.File, blobItem.ContentType, blobItem.Name);
        }
    }
}