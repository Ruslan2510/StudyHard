using StudyHard.Common.Dto;
using StudyHard.ContentManagement.Dto.Subject;
using StudyHard.ContentManagement.Services.Mappers.Subject;
using StudyHard.Data.Repository;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace StudyHard.Services.ContentManagment.Subject
{
    public class SubjectService : ISubjectService
    {
        private readonly StudyHardRepository _repository;

        public SubjectService(StudyHardRepository repository)
        {
            _repository = repository;
        }

        public async Task<PaginatedDto<SubjectDto>> GetPaginatedSubjectsAsync(PaginationDto paginationDto, CancellationToken cancellationToken)
        {
            var result = await _repository.SubjectDataAccess.GetPagainatedSubjectsAsync(paginationDto.Page, paginationDto.PageSize, cancellationToken);

            return new PaginatedDto<SubjectDto>
            {
                Count = result.Count,
                PaginatedList = result.Elements.MapToDtos(),
                Page = paginationDto.Page,
                PageSize = paginationDto.PageSize
            };
        }

        public async Task ChangePropertyActiveSubjectAsync(Guid id, CancellationToken cancellationToken)
        {
            var subject = await _repository.SubjectDataAccess.GetSubjectByIdAsync(id, cancellationToken);

            subject.IsActive = !subject.IsActive;

            await _repository.SubjectDataAccess.ChangeSubjectPropertyActiveAsync(subject, cancellationToken);
        }

        public async Task<SubjectDto> GetSubjectByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            var subject = await _repository.SubjectDataAccess.GetSubjectByIdAsync(id, cancellationToken);
            return subject.MapToDto();
        }

        public async Task CreateSubjectAsync(SubjectDto subjectDto, CancellationToken cancellationToken)
        {
            subjectDto.CreatedDateUTC = DateTime.UtcNow;
            var subject = subjectDto.MapToEntity();
            await _repository.SubjectDataAccess.AddAsync(subject, cancellationToken);
        }

        public async Task UpdateSubjectAsync(SubjectDto subjectDto, CancellationToken cancellationToken)
        {
            var subject = subjectDto.MapToEntity();
            await _repository.SubjectDataAccess.UpdateSubjectAsync(subject, cancellationToken);
        }

        public async Task DeleteSubjectAsync(SubjectDto subjectDto, CancellationToken cancellationToken)
        {
            var subject = subjectDto.MapToEntity();
            await _repository.SubjectDataAccess.DeleteAsync(subject, cancellationToken);
        }
    }
}