﻿// <auto-generated />
using System;
using ClientPortal.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ClientPortal.Data.Migrations
{
    [DbContext(typeof(FamilyTasksContext))]
    [Migration("20201127055140_initialmigration")]
    partial class initialmigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ClientPortal.Entities.Member", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Avatar")
                        .HasColumnName("Avatar")
                        .HasColumnType("nvarchar(150)")
                        .HasMaxLength(150);

                    b.Property<string>("EmailAddress")
                        .IsRequired()
                        .HasColumnName("EmailAddress")
                        .HasColumnType("nvarchar(150)")
                        .HasMaxLength(150);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnName("FirstName")
                        .HasColumnType("nvarchar(70)")
                        .HasMaxLength(70);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnName("LastName")
                        .HasColumnType("nvarchar(70)")
                        .HasMaxLength(70);

                    b.Property<string>("Roles")
                        .IsRequired()
                        .HasColumnName("Roles")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("Members");

                    b.HasData(
                        new
                        {
                            Id = new Guid("a29a1a8d-31c9-4b8b-81c8-e0c9a8791bd3"),
                            Avatar = "",
                            EmailAddress = "azhar@test.com",
                            FirstName = "Azhar",
                            LastName = "Riaz",
                            Roles = "test roles"
                        });
                });

            modelBuilder.Entity("ClientPortal.Entities.Task", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("AssignedMemeberId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsComplete")
                        .HasColumnType("bit");

                    b.Property<string>("Subject")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.HasIndex("AssignedMemeberId");

                    b.ToTable("Tasks");

                    b.HasData(
                        new
                        {
                            Id = new Guid("68f0f271-324e-448e-afcc-a620756face1"),
                            IsComplete = false,
                            Subject = "Subject A"
                        },
                        new
                        {
                            Id = new Guid("32d4a69d-33a2-4457-9505-2f1282503b63"),
                            IsComplete = true,
                            Subject = "Subject A"
                        });
                });

            modelBuilder.Entity("ClientPortal.Entities.Task", b =>
                {
                    b.HasOne("ClientPortal.Entities.Member", "AssignedMember")
                        .WithMany("Tasks")
                        .HasForeignKey("AssignedMemeberId");
                });
#pragma warning restore 612, 618
        }
    }
}
