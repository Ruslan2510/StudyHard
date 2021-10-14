using Microsoft.EntityFrameworkCore;
using StudyHard.Data.Entity;
using StudyHard.Data.Entity.Blog;
using StudyHard.Data.Entity.Category;
using StudyHard.Data.Entity.Exam;
using StudyHard.Data.Entity.Package;
using StudyHard.Data.Entity.Payment;
using StudyHard.Data.Entity.Subject;
using StudyHard.Data.Entity.Task;
using StudyHard.Data.Entity.Task.QuestionWithVariants;
using StudyHard.Data.Entity.Theory;
using StudyHard.Data.Mapping;

namespace StudyHard.Data
{
    public class StudyHardApplicationContext : DbContext
    {
        private string _connection { get; set; }

        public DbSet<BlogSection> BlogSections { get; set; }
        public DbSet<ExamResult> ExamResults { get; set; }
        public DbSet<Package> Packages { get; set; }
        public DbSet<PackageConfiguration> PackageConfigurations { get; set; }
        public DbSet<UserPackage> UserPackages { get; set; }
        public DbSet<LiqpayTransaction> LiqpayTransactions { get; set; }
        public DbSet<TaskList> TaskLists { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Answers> Answers { get; set; }
        public DbSet<Theory> Theories { get; set; }
        public DbSet<TheoryNote> TheoryNotes { get; set; }
        public DbSet<File> Files { get; set; }
        public DbSet<University> Universities { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserSession> UserSessions { get; set; }

        public StudyHardApplicationContext(DbContextOptions<StudyHardApplicationContext> options) : base(options)
        { }

        public StudyHardApplicationContext(string connectionString)
        {
            _connection = connectionString;
            //mac users
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(_connection);
            }

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.AddMappers();
            base.OnModelCreating(modelBuilder);
        }
    }
}
