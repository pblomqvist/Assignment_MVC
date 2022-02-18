using Microsoft.EntityFrameworkCore.Migrations;

namespace Assignment_MVC.Migrations
{
    public partial class AddedCountryandCity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CityName",
                table: "People",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    CountryName = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.CountryName);
                });

            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    CityName = table.Column<string>(nullable: false),
                    CountryName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.CityName);
                    table.ForeignKey(
                        name: "FK_Cities_Countries_CountryName",
                        column: x => x.CountryName,
                        principalTable: "Countries",
                        principalColumn: "CountryName",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "CityName", "CountryName" },
                values: new object[] { "Göteborg", null });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "CityName", "CountryName" },
                values: new object[] { "Stockholm", null });

            migrationBuilder.InsertData(
                table: "Countries",
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
                name: "FK_People_Cities_CityName",
                table: "People",
                column: "CityName",
                principalTable: "Cities",
                principalColumn: "CityName",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_People_Cities_CityName",
                table: "People");

            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropTable(
                name: "Countries");

            migrationBuilder.DropIndex(
                name: "IX_People_CityName",
                table: "People");

            migrationBuilder.DropColumn(
                name: "CityName",
                table: "People");
        }
    }
}
