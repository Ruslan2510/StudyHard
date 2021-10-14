using System;

namespace StudyHard.Data.Entity.Task
{
    public class TaskList
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedDateUTC { get; set; }

        public Guid CategoryId { get; set; }
        public Category.Category Category { get; set; }

        public Guid TaskId { get; set; }

        public TaskTypes TaskType { get; set; }
    }

    public enum TaskTypes
    {
        QuestionWithAnswers,
        DragAndDrop,
        SelectedValuesInText
    }
}
