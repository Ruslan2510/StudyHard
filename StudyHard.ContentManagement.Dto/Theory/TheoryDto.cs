using System;

namespace StudyHard.ContentManagement.Dto.Theory
{
    public class TheoryDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Content { get; set; }
        public DateTime CreatedDateUTC { get; set; }

        public Guid CategoryId { get; set; }
    }
}
