using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AnimalsWeb.Data.Migrations
{
    public partial class AnimalandCategorySeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "Name" },
                values: new object[] { 1, "fish" });

            migrationBuilder.InsertData(
                table: "Animals",
                columns: new[] { "AnimalId", "Age", "CategoryId", "Description", "Name", "PhotoUrl" },
                values: new object[] { 1, new DateTime(2022, 6, 19, 13, 13, 5, 249, DateTimeKind.Local).AddTicks(4883), 1, "asdsads", "bob", "" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Animals",
                keyColumn: "AnimalId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 1);
        }
    }
}
