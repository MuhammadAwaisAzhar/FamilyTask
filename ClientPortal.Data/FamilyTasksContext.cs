using ClientPortal.Entities;
using ClientPortal.EntityMapping;
using Microsoft.EntityFrameworkCore;
using System;

namespace ClientPortal.Data
{
    public class FamilyTasksContext : DbContext
    {
        public FamilyTasksContext(DbContextOptions<FamilyTasksContext> options)
           : base(options)
        {
        }
        public DbSet<Member> Members { get; set; }
        public DbSet<Task> Tasks { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new MembersMapping());
            modelBuilder.ApplyConfiguration(new TasksMapping());
            var memberRecord = new Member()
            {
                Id = Guid.NewGuid(),
                FirstName = "Azhar",
                LastName = "Riaz",
                EmailAddress = "azhar@test.com",
                Avatar = "",
                Roles = "test roles",
                Tasks = null
            };
            modelBuilder.Entity<Member>().HasData(memberRecord);
            modelBuilder.Entity<Task>().HasData(
                new Task
                {
                    Id = Guid.NewGuid(),
                    IsComplete = false,
                    Subject = "Subject A",
                },
                 new Task
                 {
                     Id =Guid.NewGuid(),
                     IsComplete = true,
                     Subject = "Subject A"
                     //AssignedMember=memberRecord,
                     //AssignedMemeberId=memberRecord.Id
                     
                 }
            );
        }
    }
}
