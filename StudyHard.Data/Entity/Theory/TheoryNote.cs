using System;

namespace StudyHard.Data.Entity.Theory
{
    public class TheoryNote
    {
        public Guid Id { get; set; }
        public string Content { get; set; }
        public DateTime CreatedDateUTC { get; set; }

        public Guid TheoryId { get; set; }
        public Theory Theory { get; set; }
        
        public Guid UserId { get; set; }
        public User User { get; set; }
        
    }
}
