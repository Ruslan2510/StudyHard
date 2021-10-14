using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StudyHard.Data.Entity.Blog;

namespace StudyHard.Data.Mapping.Blog
{
    public class BlogSectionMapper : IEntityTypeConfiguration<BlogSection>
    {
        public void Configure(EntityTypeBuilder<BlogSection> builder)
        {
            builder
                .HasOne(x => x.File)
                .WithMany(y => y.BlogSections)
                .HasForeignKey(x => x.ImageId);
        }
    }
}
