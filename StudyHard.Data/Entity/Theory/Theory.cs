using System;
using System.Collections.Generic;
using CategoryEntity = StudyHard.Data.Entity.Category.Category;

namespace StudyHard.Data.Entity.Theory
{
    public class Theory
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Content { get; set; }
        public DateTime CreatedDateUTC { get; set; }

        public Guid CategoryId { get; set; }
        public CategoryEntity Category { get; set; }
        public List<TheoryNote> TheoryNotes { get; set; }
    }
}