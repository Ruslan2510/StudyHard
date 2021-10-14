using System.Threading;
using System.Threading.Tasks;

namespace StudyHard.Services.Admin
{
    public interface IAdminService
    {
        Task MigrateDatabase(CancellationToken cancellationToken);
    }
}
