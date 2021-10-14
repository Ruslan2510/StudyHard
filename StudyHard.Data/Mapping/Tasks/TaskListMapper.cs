using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StudyHard.Data.Entity.Task;

namespace StudyHard.Data.Mapping.Tasks
{
    public class TaskListMapper : IEntityTypeConfiguration<TaskList>
    {
        public void Configure(EntityTypeBuilder<TaskList> builder)
        {
            builder
                .HasOne(x => x.Category)
                .WithMany(y => y.TaskLists)
                .HasForeignKey(x => x.CategoryId);
        }
    }
}
