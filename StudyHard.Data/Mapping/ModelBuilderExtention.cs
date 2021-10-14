using Microsoft.EntityFrameworkCore;
using StudyHard.Data.Mapping.Blog;
using StudyHard.Data.Mapping.Exam;
using StudyHard.Data.Mapping.Packages;
using StudyHard.Data.Mapping.Subject;
using StudyHard.Data.Mapping.Tasks;
using StudyHard.Data.Mapping.Tests;
using StudyHard.Data.Mapping.Theory;
using StudyHard.Data.Mapping.User;
using System;

namespace StudyHard.Data.Mapping
{
    public static class ModelBuilderExtention
    {
        public static void AddMappers(this ModelBuilder modelBuilder)
        {
            if (modelBuilder == null)
            {
                throw new ArgumentNullException(nameof(modelBuilder));
            }

            modelBuilder.ApplyConfiguration(new BlogSectionMapper());
            modelBuilder.ApplyConfiguration(new ExamResultsMapper());
            modelBuilder.ApplyConfiguration(new PackageConfigurationMapper());
            modelBuilder.ApplyConfiguration(new UserPackagesMapper());
            modelBuilder.ApplyConfiguration(new TaskListMapper());
            modelBuilder.ApplyConfiguration(new CategoryMapper());
            modelBuilder.ApplyConfiguration(new QuestionWithAnswerMapper());
            modelBuilder.ApplyConfiguration(new TheoryNoteMapper());
            modelBuilder.ApplyConfiguration(new UserSessionMapper());
            modelBuilder.ApplyConfiguration(new SubjectMapper());
        }
    }
}
