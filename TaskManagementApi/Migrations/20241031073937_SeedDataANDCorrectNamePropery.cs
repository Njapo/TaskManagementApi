using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TaskManagementApi.Migrations
{
    /// <inheritdoc />
    public partial class SeedDataANDCorrectNamePropery : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "WorkStatus",
                table: "ProjectTasks");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "ProjectTasks",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<bool>(
                name: "IsCompleted",
                table: "ProjectTasks",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "ProjectTasks",
                columns: new[] { "Id", "Description", "EndDate", "IsCompleted", "Name", "StartDate" },
                values: new object[,]
                {
                    { 1, "Setting up the project structure and initial configurations.", new DateTime(2024, 10, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Initial Setup", new DateTime(2024, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, "Designing the database schema and establishing relationships.", new DateTime(2024, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Database Design", new DateTime(2024, 10, 6, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, "Developing RESTful APIs for the application backend.", new DateTime(2024, 10, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "API Development", new DateTime(2024, 10, 11, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, "Implementing frontend features and integrating with APIs.", new DateTime(2024, 10, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Frontend Implementation", new DateTime(2024, 10, 21, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, "Conducting thorough testing and quality assurance.", new DateTime(2024, 11, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Testing and QA", new DateTime(2024, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ProjectTasks",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ProjectTasks",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ProjectTasks",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ProjectTasks",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "ProjectTasks",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DropColumn(
                name: "IsCompleted",
                table: "ProjectTasks");

            migrationBuilder.AlterColumn<int>(
                name: "Name",
                table: "ProjectTasks",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "WorkStatus",
                table: "ProjectTasks",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
