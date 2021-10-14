using Microsoft.EntityFrameworkCore;
using StudyHard.Data.DataAccesses.Blog;
using StudyHard.Data.DataAccesses.File;
using StudyHard.Data.DataAccesses.Package;
using System;
using StudyHard.Data.DataAccesses.User;
using StudyHard.Data.DataAccesses.Tasks.QuestionWithVariants;
using StudyHard.Data.DataAccesses.Material;

namespace StudyHard.Data.Repository
{
    public class StudyHardRepository
    {
        private readonly StudyHardApplicationContext _appContext;

        public StudyHardRepository(string connectionString)
        {
            _appContext = new StudyHardApplicationContext(connectionString);

            BlogDataAccess = new BlogDataAccess(_appContext);
            PackageDataAccess = new PackageDataAccess(_appContext);
            FileDataAccess = new FileDataAccess(_appContext);
            UsersDataAccess = new UserDataAccess(_appContext);
            TheoryDataAccess = new TheoryDataAccess(_appContext);
            CategoryDataAccess = new CategoryDataAccess(_appContext);
            SubjectDataAccess = new SubjectDataAccess(_appContext);
            QuestionDataAccess = new QuestionDataAccess(_appContext);
            UserPackageDataAccess = new UserPackageDataAccess(_appContext);
        }

        public BlogDataAccess BlogDataAccess { get; }
        public PackageDataAccess PackageDataAccess { get; }
        public FileDataAccess FileDataAccess { get; }
        public UserDataAccess UsersDataAccess { get; }
        public TheoryDataAccess TheoryDataAccess { get; }
        public CategoryDataAccess CategoryDataAccess { get; }
        public SubjectDataAccess SubjectDataAccess { get; }
        public QuestionDataAccess QuestionDataAccess { get; }
        public UserPackageDataAccess UserPackageDataAccess { get; set; }
        public void Migrate()
        {
            _appContext.Database.SetCommandTimeout(TimeSpan.FromMinutes(120));
            _appContext.Database.Migrate();
        }
    }
}
