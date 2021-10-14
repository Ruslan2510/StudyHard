using System;

namespace StudyHard.ContentManagement.Dto.Subject
{
    public class SubjectDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedDateUTC { get; set; }
    }
}
