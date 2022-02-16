using Microsoft.EntityFrameworkCore.Migrations;

namespace Assignment_MVC.Migrations
{
    public partial class UpdatedEFCversions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "People",
                columns: new[] { "PersonId", "City", "Name", "PhoneNumber" },
                values: new object[,]
                {
                    { 1, "Kiruna", "Maja Gräddnos", 12345 },
                    { 2, "Västerås", "Kalle Kaviar", 123457 },
                    { 3, "Stockholm", "Pelle Svanslös", 123458 },
                    { 4, "Göteborg", "Frank Franksson", 123458 },
                    { 5, "Göteborg", "Kalle Söderström", 123458 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "PersonId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "PersonId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "PersonId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "PersonId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "PersonId",
                keyValue: 5);
        }
    }
}
