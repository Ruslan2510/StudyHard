using System;

namespace StudyHard.Data.Entity.Task.QuestionWithVariants
{
    public class Answers
    {
        public Guid Id { get; set; }

        public string Answer { get; set; }

        public bool IsCorrect { get; set; }

        public Guid QuestionId { get; set; }

        public Question Question { get; set; }
    }
}
