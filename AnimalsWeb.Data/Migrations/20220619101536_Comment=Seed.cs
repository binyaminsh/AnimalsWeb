using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AnimalsWeb.Data.Migrations
{
    public partial class CommentSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Animals",
                keyColumn: "AnimalId",
                keyValue: 1,
                column: "Age",
                value: new DateTime(2022, 6, 19, 13, 15, 36, 204, DateTimeKind.Local).AddTicks(1155));

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "CommentId", "AnimalId", "Content" },
                values: new object[] { 1, 1, "hello" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: 1);

            migrationBuilder.UpdateData(
                table: "Animals",
                keyColumn: "AnimalId",
                keyValue: 1,
                column: "Age",
                value: new DateTime(2022, 6, 19, 13, 13, 5, 249, DateTimeKind.Local).AddTicks(4883));
        }
    }
}
