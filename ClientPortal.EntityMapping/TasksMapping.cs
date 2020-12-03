using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ClientPortal.Entities;

namespace ClientPortal.EntityMapping
{
    public class TasksMapping : IEntityTypeConfiguration<Task>
    {
        public void Configure(EntityTypeBuilder<Task> builder)
        {
            //Table Mapping
            builder.ToTable("Tasks");
            // Primary Key
            builder.HasKey(task => task.Id);
            // Column Mappings
            builder.Property(task => task.Subject).HasMaxLength(50).IsRequired();
            builder.Property(task => task.IsComplete).IsRequired();
            //builder.Property(task => task.AssignedMemeberId).IsRequired();
            
        }
    }
}
