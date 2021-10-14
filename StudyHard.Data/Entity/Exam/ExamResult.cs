using System;
using SubjectEntity = StudyHard.Data.Entity.Subject.Subject;

namespace StudyHard.Data.Entity.Exam
{
    public class ExamResult
    {
        public Guid Id { get; set; }
        public byte Result { get; set; }
        public DateTime CreatedDateUTC { get; set; }

        public Guid SubjectId { get; set; }
        public SubjectEntity Subject { get; set; }

        public Guid UserId { get; set; }
        public User User { get; set; }
    }
}