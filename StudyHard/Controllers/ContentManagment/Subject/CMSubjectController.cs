using Microsoft.AspNetCore.Mvc;
using StudyHard.Common.Dto;
using StudyHard.ContentManagement.Dto.Subject;
using StudyHard.Services.ContentManagment.Subject;
using StudyHard.Web.Filters;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace StudyHard.Web.Controllers.ContentManagment.Subject
{
    [Route("api/[controller]")]
    [ApiController]
    [ItlegAuthorizationFilter]
    public class CMSubjectController : Controller
    {
        private readonly ISubjectService _subjectService;
        public CMSubjectController(ISubjectService subjectService)
        {
            _subjectService = subjectService;
        }

        [HttpPost("subjectlist")]
        public async Task<PaginatedDto<SubjectDto>> GetPaginatedTheoriesAsync(PaginationDto paginationDto, CancellationToken cancellationToken)
        {
            return await _subjectService.GetPaginatedSubjectsAsync(paginationDto, cancellationToken);
        }

        [HttpPost("subject")]
        public async Task CreateSubjectAsync(SubjectDto subjectDto, CancellationToken cancellationToken)
        {
            await _subjectService.CreateSubjectAsync(subjectDto, cancellationToken);
        }

        [HttpGet("subject/{id}/changeactive")]
        public async Task ChangePropertyActiveSubjectAsync(Guid id, CancellationToken cancellationToken)
        {
            await _subjectService.ChangePropertyActiveSubjectAsync(id, cancellationToken);
        }
    }
}
