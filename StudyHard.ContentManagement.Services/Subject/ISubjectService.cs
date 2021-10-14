using StudyHard.Common.Dto;
using StudyHard.ContentManagement.Dto.Subject;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace StudyHard.Services.ContentManagment.Subject
{
    public interface ISubjectService
    {
        Task<PaginatedDto<SubjectDto>> GetPaginatedSubjectsAsync(PaginationDto paginationDto, CancellationToken cancellationToken);
        Task<SubjectDto> GetSubjectByIdAsync(Guid id, CancellationToken cancellationToken);
        Task ChangePropertyActiveSubjectAsync(Guid id, CancellationToken cancellationToken);
        Task CreateSubjectAsync(SubjectDto subjectDto, CancellationToken cancellationToken);
        Task UpdateSubjectAsync(SubjectDto subjectDto, CancellationToken cancellationToken);
        Task DeleteSubjectAsync(SubjectDto subjectDto, CancellationToken cancellationToken);
    }
}
