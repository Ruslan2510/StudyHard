using Microsoft.Extensions.DependencyInjection;
using StudyHard.Common.Managers.AzureBlob;
using StudyHard.Common.Managers.Files;

namespace StudyHard.Common.Managers
{
    public static class DependecyInjectionExtention
    {
        public static void AddCommonManagers(this IServiceCollection services)
        {
            services.AddScoped<IBlobManager, BlobManager>();
            services.AddScoped<IFileManager, FileManager>();
        }
    }
}
