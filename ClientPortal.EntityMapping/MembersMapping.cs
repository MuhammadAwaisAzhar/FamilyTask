using ClientPortal.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClientPortal.EntityMapping
{
    public class MembersMapping : IEntityTypeConfiguration<Member>
    {
        public void Configure(EntityTypeBuilder<Member> builder)
        {
            //Table Mapping
            builder.ToTable("Members");
            // Primary Key
            builder.HasKey(member => member.Id);
            // Column Mappings
            builder.Property(member => member.FirstName).HasColumnName("FirstName").HasMaxLength(70).IsRequired();
            builder.Property(member => member.LastName).HasColumnName("LastName").HasMaxLength(70).IsRequired();
            builder.Property(member => member.EmailAddress).HasColumnName("EmailAddress").HasMaxLength(150).IsRequired();
            builder.Property(member => member.Roles).HasColumnName("Roles").HasMaxLength(50).IsRequired();
            builder.Property(member => member.Avatar).HasColumnName("Avatar").HasMaxLength(150);

            builder.HasMany(member => member.Tasks)
               .WithOne(task => task.AssignedMember)
               .HasForeignKey(task => task.AssignedMemeberId)
               .IsRequired(false);
        }
    }
}
