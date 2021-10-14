using StudyHard.ContentManagement.Dto.Subject;
using System;

namespace StudyHard.ContentManagement.Dto.Category
{
    public class CategoryDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedDateUTC { get; set; }
        public Guid SubjectId { get; set; }
    }
}
