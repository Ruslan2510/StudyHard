using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StudyHard.Data.Entity.Task.QuestionWithVariants;

namespace StudyHard.Data.Mapping.Tests
{
    public class QuestionWithAnswerMapper : IEntityTypeConfiguration<Question>
    {
        public void Configure(EntityTypeBuilder<Question> builder)
        {
            builder
                .HasMany(x => x.Answers)
                .WithOne(y => y.Question)
                .HasForeignKey(x => x.QuestionId);
        }
    }
}
