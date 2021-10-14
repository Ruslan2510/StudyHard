using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudyHard.Common.Dto;
using StudyHard.Common.Dto.AzureBlob;
using StudyHard.Common.Dto.File;
using StudyHard.ContentManagement.Dto.Theory;
using StudyHard.ContentManagement.Services.Theory;
using StudyHard.Web.Filters;
using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace StudyHard.Web.Controllers.ContentManagment.Theories
{
    [Route("api/[controller]")]
    [ApiController]
    public class CMTheoryController : Controller
    {
        private readonly ITheoryService _theoryService;

        public CMTheoryController(ITheoryService theoryService)
        {
            _theoryService = theoryService;
        }

        [ItlegAuthorizationFilter]
        [HttpPost("theorylist")]
        public async Task<PaginatedDto<TheoryDto>> GetPaginatedTheoriesAsync(TheoryPaginationDto theoryPaginationDto, CancellationToken cancellationToken)
        {
            return await _theoryService.GetPaginatedTheoriesByCategoryIdAsync(theoryPaginationDto, cancellationToken);
        }

        [ItlegAuthorizationFilter]
        [HttpGet("theory/{id}")]
        public async Task<TheoryDto> GetTheoryByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            return await _theoryService.GetTheoryByIdAsync(id, cancellationToken);
        }

        [ItlegAuthorizationFilter]
        [HttpPost("theory")]
        public async Task CreateTheoryAsync(TheoryDto theorySection, CancellationToken cancellationToken)
        {
            await _theoryService.CreateTheoryAsync(theorySection, cancellationToken);
        }

        [ItlegAuthorizationFilter]
        [HttpPost("theoryupdate")]
        public async Task UpdateTheoryAsync(TheoryDto theorySection, CancellationToken cancellationToken)
        {
            await _theoryService.UpdateTheoryAsync(theorySection, cancellationToken);
        }

        [ItlegAuthorizationFilter]
        [HttpPost("theorydelete")]
        public async Task DeleteCategoryAsync(TheoryDto theorySection, CancellationToken cancellationToken)
        {
            await _theoryService.DeleteTheoryAsync(theorySection, cancellationToken);
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
                fileId = await _theoryService.AddBlobAsync(stream, name, ext, cancellationToken);
            }

            string domainName = $"{this.Request.Scheme}://{this.Request.Host}";

            FileUrlDto fileUrlDto = new FileUrlDto
            {
                Url = $"{domainName}/api/cmtheory/{fileId}"
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
                fileId = await _theoryService.AddBlobAsync(stream, name, ext, cancellationToken);
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
            BlobFileDto blobItem = await _theoryService.GetBlobAsync(fileid, cancellationToken);

            return File(blobItem.File, blobItem.ContentType, blobItem.Name);
        }

        [ItlegAuthorizationFilter]
        [HttpGet("delete")]
        public async Task DeleteBlobAsync(FileDto file, CancellationToken cancellationToken)
        {
            await _theoryService.DeleteBlobAsync(file, cancellationToken);
        }
    }
}