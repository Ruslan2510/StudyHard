using Microsoft.Extensions.DependencyInjection;
using StudyHard.Services.Admin;
using StudyHard.Services.Auth;
using StudyHard.Services.Blog;
using StudyHard.Services.Package;

namespace StudyHard.Services
{
    public static class DependecyInjectionExtention
    {
        public static void AddClientServices(this IServiceCollection services)
        {
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IAdminService, AdminService>();
            services.AddScoped<IBlogService, BlogService>();
            services.AddScoped<IPackageService, PackageService>();
        }
    }
}
