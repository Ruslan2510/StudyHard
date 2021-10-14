using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StudyHard.Data.Entity;

namespace StudyHard.Data.Mapping.User
{
    public class UniversityMapper : IEntityTypeConfiguration<University>
    {
        public void Configure(EntityTypeBuilder<University> builder)
        {
            builder
                .HasMany(x => x.User)
                .WithOne(y => y.University)
                .HasForeignKey(x => x.UniversityId);
        }
    }
}