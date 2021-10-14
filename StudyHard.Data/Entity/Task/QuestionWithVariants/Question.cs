using System;
using System.Collections.Generic;

namespace StudyHard.Data.Entity.Task.QuestionWithVariants
{
    public class Question
    {
        public Guid Id { get; set; }
        public string Text { get; set; }
        public List<Answers> Answers { get; set; }
    }
}
