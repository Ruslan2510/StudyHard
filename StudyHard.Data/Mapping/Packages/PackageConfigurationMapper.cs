using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StudyHard.Data.Entity.Package;

namespace StudyHard.Data.Mapping.Packages
{
    public class PackageConfigurationMapper : IEntityTypeConfiguration<PackageConfiguration>
    {
        public void Configure(EntityTypeBuilder<PackageConfiguration> builder)
        {
            builder
                .HasOne(x => x.Package)
                .WithMany(y => y.PackageConfigurations)
                .HasForeignKey(x => x.PackageId);
        }
    }
}
