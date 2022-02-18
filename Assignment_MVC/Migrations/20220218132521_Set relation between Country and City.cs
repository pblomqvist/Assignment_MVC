using Microsoft.EntityFrameworkCore.Migrations;

namespace Assignment_MVC.Migrations
{
    public partial class SetrelationbetweenCountryandCity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cities_Countries_CountryName",
                table: "Cities");

            migrationBuilder.DropForeignKey(
                name: "FK_People_Cities_CityName",
                table: "People");

            migrationBuilder.DropIndex(
                name: "IX_People_CityName",
                table: "People");

            migrationBuilder.DropIndex(
                name: "IX_Cities_CountryName",
                table: "Cities");

            migrationBuilder.AlterColumn<string>(
                name: "CityName",
                table: "People",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "newCityCityName",
                table: "People",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CountryName",
                table: "Cities",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CountryName1",
                table: "Cities",
                nullable: true);

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

            migrationBuilder.CreateIndex(
                name: "IX_People_newCityCityName",
                table: "People",
                column: "newCityCityName");

            migrationBuilder.CreateIndex(
                name: "IX_Cities_CountryName1",
                table: "Cities",
                column: "CountryName1");

            migrationBuilder.AddForeignKey(
                name: "FK_Cities_Countries_CountryName1",
                table: "Cities",
                column: "CountryName1",
                principalTable: "Countries",
                principalColumn: "CountryName",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_People_Cities_newCityCityName",
                table: "People",
                column: "newCityCityName",
                principalTable: "Cities",
                principalColumn: "CityName",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cities_Countries_CountryName1",
                table: "Cities");

            migrationBuilder.DropForeignKey(
                name: "FK_People_Cities_newCityCityName",
                table: "People");

            migrationBuilder.DropIndex(
                name: "IX_People_newCityCityName",
                table: "People");

            migrationBuilder.DropIndex(
                name: "IX_Cities_CountryName1",
                table: "Cities");

            migrationBuilder.DropColumn(
                name: "newCityCityName",
                table: "People");

            migrationBuilder.DropColumn(
                name: "CountryName1",
                table: "Cities");

            migrationBuilder.AlterColumn<string>(
                name: "CityName",
                table: "People",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CountryName",
                table: "Cities",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

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

            migrationBuilder.CreateIndex(
                name: "IX_People_CityName",
                table: "People",
                column: "CityName");

            migrationBuilder.CreateIndex(
                name: "IX_Cities_CountryName",
                table: "Cities",
                column: "CountryName");

            migrationBuilder.AddForeignKey(
                name: "FK_Cities_Countries_CountryName",
                table: "Cities",
                column: "CountryName",
                principalTable: "Countries",
                principalColumn: "CountryName",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_People_Cities_CityName",
                table: "People",
                column: "CityName",
                principalTable: "Cities",
                principalColumn: "CityName",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
