using Azure.Storage.Blobs;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StudyHard.ContentManagement.Services;
using StudyHard.Data;
using StudyHard.Data.Repository;
using StudyHard.Services;

namespace StudyHard.Tests.Infra
{
    [TestClass]
    public static class Program
    {
        private static IConfiguration Configuration { get; set; }
        public static ServiceCollection ServiceCollection { get; private set; }

        internal static string ConnectionString
        {
            get; private set;
        }

        [AssemblyInitialize]
        public static void Initialize(TestContext context)
        {
            var configbuilder = new ConfigurationBuilder().AddJsonFile("testconfig.json");

            Configuration = configbuilder.Build();
            ServiceCollection = new ServiceCollection();
            ConfigureServices(ServiceCollection, Configuration);
        }

        private static void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddControllers();
            string connection = Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<StudyHardApplicationContext>(options => options.UseSqlServer(connection));
            services.AddSingleton(x => new BlobServiceClient(Configuration.GetConnectionString("AzureBlobStorageConnectionString")));
            services.AddScoped(c => new StudyHardRepository(connection));
            services.AddContentManagementServices();
            services.AddClientServices();
        }
    }
}