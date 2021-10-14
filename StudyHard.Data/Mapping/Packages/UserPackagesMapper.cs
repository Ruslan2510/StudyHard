using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StudyHard.Data.Entity.Package;

namespace StudyHard.Data.Mapping.Packages
{
    public class UserPackagesMapper : IEntityTypeConfiguration<UserPackage>
    {
        public void Configure(EntityTypeBuilder<UserPackage> builder)
        {
            builder
                .HasOne(x => x.User)
                .WithMany(y => y.UserPackages)
                .HasForeignKey(x => x.UserId);

            builder
                .HasOne(x => x.Package)
                .WithMany(y => y.UserPackages)
                .HasForeignKey(x => x.PackageId);

            builder
                .HasOne(x => x.LiqpayTransaction) 
                .WithOne(y => y.UserPackage)
                .HasForeignKey<UserPackage>(x => x.TransactionId);
        }
    }
}
