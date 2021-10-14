using Microsoft.Extensions.DependencyInjection;
using StudyHard.Common.Managers;
using StudyHard.ContentManagement.Services.Blog;
using StudyHard.ContentManagement.Services.Category;
using StudyHard.ContentManagement.Services.Package;
using StudyHard.ContentManagement.Services.Theory;
using StudyHard.Services.ContentManagment.Subject;

namespace StudyHard.ContentManagement.Services
{
    public static class DependecyInjectionExtention
    {
        public static void AddContentManagementServices(this IServiceCollection services)
        {
            services.AddCommonManagers();
            services.AddScoped<IBlogService, BlogService>();
            services.AddScoped<ITheoryService, TheoryService>();
            services.AddScoped<ISubjectService, SubjectService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IPackageService, PackageService>();
        }
    }
}
