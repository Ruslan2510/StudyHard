using StudyHard.Data.Repository;
using System.Threading;
using System.Threading.Tasks;

namespace StudyHard.Services.ContentManagment.Tasks.QuestionWithAnswers
{
    public class CMQuestionWithAnswersService : ICMQuestionWithAnswersService
    {
        private readonly StudyHardRepository _studyHardRepository;
        public CMQuestionWithAnswersService(StudyHardRepository studyHardRepository)
        {
            _studyHardRepository = studyHardRepository;
        }

        public async Task CreateOrUpdateTaskAsync(CancellationToken cancellationToken)
        {
        }
    }
}
