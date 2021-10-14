using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using System.IO;
using StudyHard.Web.Filters;
using System;
using StudyHard.ContentManagement.Services.Blog;
using StudyHard.Common.Dto.File;
using StudyHard.Common.Dto;
using StudyHard.Common.Dto.AzureBlob;
using StudyHard.ContentManagement.Dto.Blog;

namespace StudyHard.Web.Controllers.ContentManagment.Blog
{
    [Route("api/[controller]")]
    [ApiController]
    public class CMBlogController : ControllerBase
    {
        private readonly IBlogService _blogService;

        public CMBlogController(IBlogService blogService)
        {
            _blogService = blogService;
        }

        [ItlegAuthorizationFilter]
        [HttpPost("bloglist")]
        public async Task<PaginatedDto<BlogSectionDto>> GetPaginatedBlogsAsync(PaginationDto paginationDto, CancellationToken cancellationToken)
        {
            return await _blogService.GetPaginatedBlogsAsync(paginationDto, cancellationToken);
        }

        [ItlegAuthorizationFilter]
        [HttpPost("blog")]
        public async Task CreateBlogAsync(BlogSectionDto blogSectionDto, CancellationToken cancellationToken)
        {
            await _blogService.CreateBlogAsync(blogSectionDto, cancellationToken);
        }

        [ItlegAuthorizationFilter]
        [HttpGet("blog/{id}")]
        public async Task<BlogSectionDto> GetBlogSectionByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            return await _blogService.GetBlogSectionByIdAsync(id, cancellationToken);
        }

        [ItlegAuthorizationFilter]
        [HttpPost("blogupdate")]
        public async Task UpdateBlogAsync(BlogSectionDto blogSectionDto, CancellationToken cancellationToken)
        {
           await _blogService.UpdateBlogAsync(blogSectionDto, cancellationToken);
        }

        [ItlegAuthorizationFilter]
        [HttpGet("blog/{id}/changeactive")]
        public async Task ChangeBlogPropertyActiveAsync(Guid id, CancellationToken cancellationToken)
        {
            await _blogService.ChangeBlogPropertyActiveAsync(id, cancellationToken);
        }

        [ItlegAuthorizationFilter]
        [HttpPost("blobupload")]
        public async Task<FileUrlDto> AddBlobAsync(IFormFile file, CancellationToken cancellationToken)
        {
            var name = Path.GetFileNameWithoutExtension(file.FileName);
            var ext = Path.GetExtension(file.FileName);

            Guid fileId;

            using (Stream stream = file.OpenReadStream())
            {
                fileId = await _blogService.AddBlobAsync(stream, name, ext, cancellationToken);
            }

            string domainName = $"{this.Request.Scheme}://{this.Request.Host}";

            FileUrlDto fileUrlDto = new FileUrlDto
            {
                Url = $"{domainName}/api/cmblog/{fileId}"
            };

            return fileUrlDto;
        }

        [ItlegAuthorizationFilter]
        [HttpPost("upload")]
        public async Task<FileDto> UploadBlobAsync(IFormFile file, CancellationToken cancellationToken)
        {
            var name = Path.GetFileNameWithoutExtension(file.FileName);
            var ext = Path.GetExtension(file.FileName);

            Guid fileId;

            using (Stream stream = file.OpenReadStream())
            {
                fileId = await _blogService.AddBlobAsync(stream, name, ext, cancellationToken);
            }

            FileDto fileDto = new FileDto
            {
                Id = fileId,
                Extention = ext,
                Name = name
            };

            return fileDto;
        }

        [HttpGet("{fileid}")]
        public async Task<IActionResult> GetBlobAsync(Guid fileid, CancellationToken cancellationToken)
        {
            BlobFileDto blobItem = await _blogService.GetBlobAsync(fileid, cancellationToken);

            return File(blobItem.File, blobItem.ContentType, blobItem.Name);
        }

        [ItlegAuthorizationFilter]
        [HttpPost("delete")]
        public async Task DeleteBlobAsync(FileDto file, CancellationToken cancellationToken)
        {
            await _blogService.DeleteBlobAsync(file, cancellationToken);
        }
    }
}