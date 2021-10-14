using StudyHard.Data.Repository;
using System.Threading;
using System.Threading.Tasks;

namespace StudyHard.Services.Admin
{
    public class AdminService : IAdminService
    {
        private readonly StudyHardRepository _repository;

        public AdminService(StudyHardRepository repository)
        {
            _repository = repository;
        }

        public async Task MigrateDatabase(CancellationToken cancellationToken)
        {
            await Task.Run(() => _repository.Migrate(), cancellationToken);
        }
    }
}
