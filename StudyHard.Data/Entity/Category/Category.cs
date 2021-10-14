using StudyHard.Data.Entity.Task;
using System;
using System.Collections.Generic;

namespace StudyHard.Data.Entity.Category
{
    public class Category
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedDateUTC { get; set; }

        public List<Theory.Theory> Theories { get; set; }
        public List<TaskList> TaskLists { get; set; }

        public Guid SubjectId { get; set; }
        public Subject.Subject Subject { get; set; }
    }
}