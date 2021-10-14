using StudyHard.Data.Entity.Task.QuestionWithVariants;

namespace StudyHard.Data.DataAccesses.Tasks.QuestionWithVariants
{
    public class AnswerDataAccess : BaseDataAccess<Answers>
    {
        internal AnswerDataAccess(StudyHardApplicationContext applicationContext) : base(applicationContext)
        {
        }
    }
}
