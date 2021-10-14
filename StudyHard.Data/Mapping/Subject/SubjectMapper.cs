using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StudyHard.Data.Entity.Package;
using SubjectEntity = StudyHard.Data.Entity.Subject.Subject;

namespace StudyHard.Data.Mapping.Subject
{
    public class SubjectMapper : IEntityTypeConfiguration<SubjectEntity>
    {
        public void Configure(EntityTypeBuilder<SubjectEntity> builder)
        {
            builder
               .HasOne(x => x.PackageConfiguration)
               .WithOne(y => y.Subject)
               .HasForeignKey<PackageConfiguration>(x => x.SubjectId);
        }
    }
}
