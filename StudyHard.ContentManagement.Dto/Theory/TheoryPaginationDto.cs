using StudyHard.Common.Dto;
using System;

namespace StudyHard.ContentManagement.Dto.Theory
{
    public class TheoryPaginationDto : PaginationDto
    {
        public Guid CategoryId { get; set; }
    }
}
