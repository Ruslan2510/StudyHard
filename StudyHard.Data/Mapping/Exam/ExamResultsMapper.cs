using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StudyHard.Data.Entity.Exam;

namespace StudyHard.Data.Mapping.Exam
{
    public class ExamResultsMapper : IEntityTypeConfiguration<ExamResult>
    {
        public void Configure(EntityTypeBuilder<ExamResult> builder)
        {
            builder
                .HasOne(x => x.Subject)
                .WithMany(y => y.ExamResults)
                .HasForeignKey(x => x.SubjectId);

            builder
                .HasOne(x => x.User)
                .WithMany(y => y.ExamResults)
                .HasForeignKey(x => x.UserId);
        }
    }
}
