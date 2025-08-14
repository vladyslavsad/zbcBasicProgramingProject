using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace zbs_gp_project.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserTimeStamp = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Labours",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TimeStamp = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Labours", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Labours_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "Name", "Password", "UserTimeStamp" },
                values: new object[,]
                {
                    { "u1abc", "user1email@gmail.com", "User1", "dummyPassword", new DateTime(2002, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "u2abc", "user2email@gmail.com", "User2", "dummyPassword", new DateTime(2002, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "u3abc", "user3email@gmail.com", "User3", "dummyPassword", new DateTime(2002, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "u4abc", "user4email@gmail.com", "User4", "dummyPassword", new DateTime(2002, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Labours",
                columns: new[] { "Id", "Description", "TimeStamp", "Title", "UserId" },
                values: new object[,]
                {
                    { "l1a001", "Description 1", new DateTime(2002, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Task 1", "u1abc" },
                    { "l1a002", "Description 2", new DateTime(2002, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Task 2", "u1abc" },
                    { "l1a003", "Description 3", new DateTime(2002, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Task 3", "u1abc" },
                    { "l1a004", "Description 4", new DateTime(2002, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Task 4", "u1abc" },
                    { "l2a001", "Description 5", new DateTime(2002, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Task 5", "u2abc" },
                    { "l2a002", "Description 6", new DateTime(2002, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Task 6", "u2abc" },
                    { "l2a003", "Description 7", new DateTime(2002, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Task 7", "u2abc" },
                    { "l2a004", "Description 8", new DateTime(2002, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Task 8", "u2abc" },
                    { "l3a001", "Description 9", new DateTime(2002, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Task 9", "u3abc" },
                    { "l3a002", "Description 10", new DateTime(2002, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Task 10", "u3abc" },
                    { "l3a003", "Description 11", new DateTime(2002, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Task 11", "u3abc" },
                    { "l3a004", "Description 12", new DateTime(2002, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Task 12", "u3abc" },
                    { "l4a001", "Description 13", new DateTime(2002, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Task 13", "u4abc" },
                    { "l4a002", "Description 14", new DateTime(2002, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Task 14", "u4abc" },
                    { "l4a003", "Description 15", new DateTime(2002, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Task 15", "u4abc" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Labours_UserId",
                table: "Labours",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Labours");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
