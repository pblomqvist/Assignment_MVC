using Microsoft.EntityFrameworkCore.Migrations;

namespace Assignment_MVC.Migrations
{
    public partial class Updateseededdata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "CityName",
                keyValue: "Göteborg",
                column: "CountryName",
                value: "Sweden");

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "CityName",
                keyValue: "Kiruna",
                column: "CountryName",
                value: "Sweden");

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "CityName",
                keyValue: "Stockholm",
                column: "CountryName",
                value: "Sweden");

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "CityName",
                keyValue: "Västerås",
                column: "CountryName",
                value: "Sweden");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "CityName",
                keyValue: "Göteborg",
                column: "CountryName",
                value: null);

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "CityName",
                keyValue: "Kiruna",
                column: "CountryName",
                value: null);

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "CityName",
                keyValue: "Stockholm",
                column: "CountryName",
                value: null);

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "CityName",
                keyValue: "Västerås",
                column: "CountryName",
                value: null);
        }
    }
}
