using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AnimalsWeb.Data.Migrations
{
    public partial class FixingSeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Animals",
                keyColumn: "AnimalId",
                keyValue: 1,
                column: "PhotoUrl",
                value: "Bombay.webp");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Animals",
                keyColumn: "AnimalId",
                keyValue: 1,
                column: "PhotoUrl",
                value: "8d38064c-5f08-44bc-aa3e-0c9c3da8ca14coffee.png");
        }
    }
}
