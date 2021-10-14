using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StudyHard.Data.Entity.Theory;

namespace StudyHard.Data.Mapping.Theory
{
    public class TheoryNoteMapper : IEntityTypeConfiguration<TheoryNote>
    {
        public void Configure(EntityTypeBuilder<TheoryNote> builder)
        {
            builder
                .HasOne(x => x.User)
                .WithMany(y => y.TheoryNotes)
                .HasForeignKey(x => x.UserId);
        }
    }
}
