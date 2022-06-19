using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AnimalsWeb.Data.Migrations
{
    public partial class SeedDataExtension : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Animals",
                keyColumn: "AnimalId",
                keyValue: 1,
                columns: new[] { "Age", "Description", "Name", "PhotoUrl" },
                values: new object[] { new DateTime(2021, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Bombay is an easy-going, yet energetic cat.", "Bombay Cat", "8d38064c-5f08-44bc-aa3e-0c9c3da8ca14coffee.png" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 1,
                column: "Name",
                value: "Cats");

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "Name" },
                values: new object[,]
                {
                    { 2, "Dogs" },
                    { 3, "Reptiles" }
                });

            migrationBuilder.InsertData(
                table: "Animals",
                columns: new[] { "AnimalId", "Age", "CategoryId", "Description", "Name", "PhotoUrl" },
                values: new object[] { 2, new DateTime(2020, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "One of the oldest Arctic sled dogs, the Alaskan Malamute was first bred in Alaska to carry large loads over long distances.", "Alaskan Malamute", "Alaskan-Malamute-dog.webp" });

            migrationBuilder.InsertData(
                table: "Animals",
                columns: new[] { "AnimalId", "Age", "CategoryId", "Description", "Name", "PhotoUrl" },
                values: new object[] { 3, new DateTime(2022, 1, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Once used as a hunting companion by English gentlemen in the 1500s, the Beagle is a friendly and cheerful family companion", "Beagle", "Beagle-dog.jpg" });

            migrationBuilder.InsertData(
                table: "Animals",
                columns: new[] { "AnimalId", "Age", "CategoryId", "Description", "Name", "PhotoUrl" },
                values: new object[] { 4, new DateTime(2021, 4, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, " A solitary creature, the bush viper is arboreal and terrestrial. Their colors make for exceptional camouflage.", "Bush Viper", "Bush-Viper.jpeg" });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "CommentId", "AnimalId", "Content" },
                values: new object[] { 2, 2, "test comment" });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "CommentId", "AnimalId", "Content" },
                values: new object[] { 3, 3, "wow" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Animals",
                keyColumn: "AnimalId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Animals",
                keyColumn: "AnimalId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Animals",
                keyColumn: "AnimalId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 2);

            migrationBuilder.UpdateData(
                table: "Animals",
                keyColumn: "AnimalId",
                keyValue: 1,
                columns: new[] { "Age", "Description", "Name", "PhotoUrl" },
                values: new object[] { new DateTime(2022, 6, 19, 13, 15, 36, 204, DateTimeKind.Local).AddTicks(1155), "asdsads", "bob", "" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 1,
                column: "Name",
                value: "fish");
        }
    }
}
