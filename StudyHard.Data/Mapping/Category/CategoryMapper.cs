using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StudyHard.Data.Entity.Category;

namespace StudyHard.Data.Mapping.Tests
{
    public class CategoryMapper : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder
                .HasOne(x => x.Subject)
                .WithMany(y => y.Categories)
                .HasForeignKey(x => x.SubjectId);

            builder
                .HasMany(x => x.Theories)
                .WithOne(y => y.Category)
                .HasForeignKey(x => x.CategoryId);
        }
    }
}
