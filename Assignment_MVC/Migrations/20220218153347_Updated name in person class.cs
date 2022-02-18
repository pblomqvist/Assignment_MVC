using Microsoft.EntityFrameworkCore.Migrations;

namespace Assignment_MVC.Migrations
{
    public partial class Updatednameinpersonclass : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_People_Cities_newCityCityName",
                table: "People");

            migrationBuilder.DropIndex(
                name: "IX_People_newCityCityName",
                table: "People");

            migrationBuilder.DropColumn(
                name: "newCityCityName",
                table: "People");

            migrationBuilder.AddColumn<string>(
                name: "dbCityCityName",
                table: "People",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_People_dbCityCityName",
                table: "People",
                column: "dbCityCityName");

            migrationBuilder.AddForeignKey(
                name: "FK_People_Cities_dbCityCityName",
                table: "People",
                column: "dbCityCityName",
                principalTable: "Cities",
                principalColumn: "CityName",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_People_Cities_dbCityCityName",
                table: "People");

            migrationBuilder.DropIndex(
                name: "IX_People_dbCityCityName",
                table: "People");

            migrationBuilder.DropColumn(
                name: "dbCityCityName",
                table: "People");

            migrationBuilder.AddColumn<string>(
                name: "newCityCityName",
                table: "People",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_People_newCityCityName",
                table: "People",
                column: "newCityCityName");

            migrationBuilder.AddForeignKey(
                name: "FK_People_Cities_newCityCityName",
                table: "People",
                column: "newCityCityName",
                principalTable: "Cities",
                principalColumn: "CityName",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
