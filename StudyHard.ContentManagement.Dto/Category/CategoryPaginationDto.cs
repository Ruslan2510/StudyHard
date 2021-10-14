using StudyHard.Common.Dto;
using System;

namespace StudyHard.ContentManagement.Dto.Category
{
    public class CategoryPaginationDto : PaginationDto
    {
        public Guid SubjectId { get; set; }
    }
}
