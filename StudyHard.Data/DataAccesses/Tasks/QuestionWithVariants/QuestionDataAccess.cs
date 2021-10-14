using SubjectEntity = StudyHard.Data.Entity.Subject.Subject;

namespace StudyHard.Data.DataAccesses.Tasks.QuestionWithVariants
{
    public class QuestionDataAccess : BaseDataAccess<SubjectEntity>
    {
        internal QuestionDataAccess(StudyHardApplicationContext applicationContext) : base(applicationContext)
        {
        }
    }
}
