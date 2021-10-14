using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StudyHard.Data.Entity;

namespace StudyHard.Data.Mapping.User
{
    public class UserSessionMapper : IEntityTypeConfiguration<UserSession>
    {
        public void Configure(EntityTypeBuilder<UserSession> builder)
        {
            builder
                .HasOne(x => x.User)
                .WithOne(y => y.UserSession)
                .HasForeignKey<UserSession>(x => x.Id);
        }
    }
}
