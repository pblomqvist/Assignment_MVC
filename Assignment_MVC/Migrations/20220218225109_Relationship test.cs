using Microsoft.EntityFrameworkCore.Migrations;

namespace Assignment_MVC.Migrations
{
    public partial class Relationshiptest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cities_Countries_CountryName1",
                table: "Cities");

            migrationBuilder.DropIndex(
                name: "IX_Cities_CountryName1",
                table: "Cities");

            migrationBuilder.DropColumn(
                name: "CountryName1",
                table: "Cities");

            migrationBuilder.AlterColumn<string>(
                name: "CountryName",
                table: "Cities",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cities_Countries_CountryName",
                table: "Cities");

            migrationBuilder.DropIndex(
                name: "IX_Cities_CountryName",
                table: "Cities");

            migrationBuilder.AlterColumn<string>(
                name: "CountryName",
                table: "Cities",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CountryName1",
                table: "Cities",
                type: "nvarchar(450)",
                nullable: true);

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
        }
    }
}
