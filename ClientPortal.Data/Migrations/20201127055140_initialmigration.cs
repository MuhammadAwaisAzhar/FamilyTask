using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ClientPortal.Data.Migrations
{
    public partial class initialmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Members",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    FirstName = table.Column<string>(maxLength: 70, nullable: false),
                    LastName = table.Column<string>(maxLength: 70, nullable: false),
                    EmailAddress = table.Column<string>(maxLength: 150, nullable: false),
                    Roles = table.Column<string>(maxLength: 50, nullable: false),
                    Avatar = table.Column<string>(maxLength: 150, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Members", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tasks",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Subject = table.Column<string>(maxLength: 50, nullable: false),
                    IsComplete = table.Column<bool>(nullable: false),
                    AssignedMemeberId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tasks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tasks_Members_AssignedMemeberId",
                        column: x => x.AssignedMemeberId,
                        principalTable: "Members",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Members",
                columns: new[] { "Id", "Avatar", "EmailAddress", "FirstName", "LastName", "Roles" },
                values: new object[] { new Guid("a29a1a8d-31c9-4b8b-81c8-e0c9a8791bd3"), "", "azhar@test.com", "Azhar", "Riaz", "test roles" });

            migrationBuilder.InsertData(
                table: "Tasks",
                columns: new[] { "Id", "AssignedMemeberId", "IsComplete", "Subject" },
                values: new object[] { new Guid("68f0f271-324e-448e-afcc-a620756face1"), null, false, "Subject A" });

            migrationBuilder.InsertData(
                table: "Tasks",
                columns: new[] { "Id", "AssignedMemeberId", "IsComplete", "Subject" },
                values: new object[] { new Guid("32d4a69d-33a2-4457-9505-2f1282503b63"), null, true, "Subject A" });

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_AssignedMemeberId",
                table: "Tasks",
                column: "AssignedMemeberId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tasks");

            migrationBuilder.DropTable(
                name: "Members");
        }
    }
}
