using StudyHard.ContentManagement.Dto.Subject;
using System.Collections.Generic;
using System.Linq;
using SubjectEntity = StudyHard.Data.Entity.Subject.Subject;

namespace StudyHard.ContentManagement.Services.Mappers.Subject
{
    public static class SubjectMapper
    {
        public static SubjectEntity MapToEntity(this SubjectDto subjectDto)
        {
            return new SubjectEntity
            {
                Id = subjectDto.Id,
                CreatedDateUTC = subjectDto.CreatedDateUTC,
                IsActive = subjectDto.IsActive,
                Name = subjectDto.Name
            };
        }

        public static SubjectDto MapToDto(this SubjectEntity subject)
        {
            return new SubjectDto
            {
                Id = subject.Id,
                Name = subject.Name,
                CreatedDateUTC = subject.CreatedDateUTC,
                IsActive = subject.IsActive
            };
        }
        
        public static List<SubjectEntity> MapToEntities(this List<SubjectDto> subjectDtos)
        {
            if (subjectDtos == null)
            {
                return new List<SubjectEntity>();
            }

            return subjectDtos.Select(x => x.MapToEntity()).ToList();
        }

        public static List<SubjectDto> MapToDtos(this List<SubjectEntity> subjects)
        {
            if (subjects == null)
            {
                return new List<SubjectDto>();
            }

            return subjects.Select(x => x.MapToDto()).ToList();
        }
    }
}
