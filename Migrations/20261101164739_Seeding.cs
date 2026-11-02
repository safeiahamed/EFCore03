using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EFAssignment03.Migrations
{
    /// <inheritdoc />
    public partial class Seeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description", "Name", "PCategoryId" },
                values: new object[] { 1, "Programming Courses", "Programming", null });

            migrationBuilder.InsertData(
                table: "Instructors",
                columns: new[] { "Id", "Bio", "Email", "FullName", "JoinDate" },
                values: new object[,]
                {
                    { 1, "Backend .Net Developer", "safeia@gmail.com", "Safeia Hamed", new DateTime(2026, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, "FrontEnd Developer", "khaled@gmail.com", "Khaled Ahmed", new DateTime(2026, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, "Backend .Net Developer", "mai@gmail.com", "Mai Omar", new DateTime(2026, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description", "Name", "PCategoryId" },
                values: new object[,]
                {
                    { 2, "Server-side development", "Backend", 1 },
                    { 3, null, "Frontend", 1 }
                });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "CategoryId", "Description", "InstructorId", "IsPublished", "Level", "Price", "PublishedAt", "Title" },
                values: new object[] { 1, 1, "Learn C# from scratch", 1, true, 0, 499.99m, new DateTime(2026, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "C# Fundamentals" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description", "Name", "PCategoryId" },
                values: new object[,]
                {
                    { 4, "ASP.NET Core framework", "ASP.NET", 2 },
                    { 5, "React library", "React", 3 }
                });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "CategoryId", "Description", "InstructorId", "IsPublished", "Level", "Price", "PublishedAt", "Title" },
                values: new object[,]
                {
                    { 3, 2, null, 2, false, 2, 129.99m, new DateTime(2026, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Advanced EF Core" },
                    { 5, 3, "Scalable UI design", 3, false, 2, 149.99m, null, "Modern Frontend Architecture" },
                    { 6, 2, "Clean architecture", 3, true, 1, 89.99m, new DateTime(2026, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Backend Design Patterns" },
                    { 2, 4, "Build REST APIs", 1, true, 1, 999.99m, new DateTime(2026, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ASP.NET Core Web API" },
                    { 4, 5, "Components and hooks", 2, true, 0, 59.99m, new DateTime(2026, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "React for Beginners" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Instructors",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Instructors",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Instructors",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
