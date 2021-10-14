using System;

namespace StudyHard.ContentManagement.Dto.Theory
{
    public class TheoryNoteDto
    {
        public short Id { get; set; }
        public string Content { get; set; }
        public DateTime CreatedDateUTC { get; set; }
        public short TheoryId { get; set; }
        public Guid UserId { get; set; }
    }
}
