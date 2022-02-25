using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Assignment_MVC.Migrations
{
    public partial class Revertedsomechanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PersonLanguages_People_DbPersonPersonId",
                table: "PersonLanguages");

            migrationBuilder.DropForeignKey(
                name: "FK_PersonLanguages_Person_PersonId",
                table: "PersonLanguages");

            migrationBuilder.DropTable(
                name: "Person");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c5b8867f-c30f-448c-a284-848bda5148cd");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "c5b8867f-c30f-448c-a284-848bda5148cd", "4f3c3cd2-5f03-44ba-ae7a-bc64c3fe8b73" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4f3c3cd2-5f03-44ba-ae7a-bc64c3fe8b73");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c5b8867f-c30f-448c-a284-848bda5148cd");

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "People",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CityName",
                table: "People",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "DbPerson",
                columns: table => new
                {
                    PersonId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    PhoneNumber = table.Column<int>(nullable: false),
                    CityId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DbPerson", x => x.PersonId);
                    table.ForeignKey(
                        name: "FK_DbPerson_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "CityId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "76feee72-1ed2-4ebb-ba0b-cf9fbf571a97", "7f6f480d-835a-4437-90a1-52de8160df02", "Admin", "ADMIN" },
                    { "25bbde6b-1f95-4877-a880-cd0b1ae7d553", "4d438611-6900-4a1e-9394-fef833ffd7c6", "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "BirthDate", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "25bbde6b-1f95-4877-a880-cd0b1ae7d553", 0, new DateTime(1987, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "55a23e82-2798-4698-855b-3c7a3b2241ee", "admin@admin.com", false, "Admin", "Adminsson", false, null, "ADMIN@ADMIN.COM", "ADMIN@ADMIN.COM", "AQAAAAEAACcQAAAAEKkm/3NCMC5IzlLPMo4YDMqgFRtZJ9CCXzN9QlsCqVCW6rRCdzN9BSKiRu/Y/rAm6Q==", null, false, "a0179751-3196-492f-8fb0-01c59c3bffb7", false, "admin@admin.com" });

            migrationBuilder.InsertData(
                table: "People",
                columns: new[] { "PersonId", "City", "CityId", "CityName", "Name", "PhoneNumber" },
                values: new object[,]
                {
                    { 1, null, 3, null, "Maja Gräddnos", 12345 },
                    { 2, null, 4, null, "Kalle Kaviar", 123457 },
                    { 3, null, 2, null, "Pelle Svanslös", 123458 },
                    { 4, null, 1, null, "Frank Franksson", 123458 },
                    { 5, null, 1, null, "Kalle Söderström", 123458 }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "25bbde6b-1f95-4877-a880-cd0b1ae7d553", "76feee72-1ed2-4ebb-ba0b-cf9fbf571a97" });

            migrationBuilder.CreateIndex(
                name: "IX_DbPerson_CityId",
                table: "DbPerson",
                column: "CityId");

            migrationBuilder.AddForeignKey(
                name: "FK_PersonLanguages_DbPerson_DbPersonPersonId",
                table: "PersonLanguages",
                column: "DbPersonPersonId",
                principalTable: "DbPerson",
                principalColumn: "PersonId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PersonLanguages_People_PersonId",
                table: "PersonLanguages",
                column: "PersonId",
                principalTable: "People",
                principalColumn: "PersonId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PersonLanguages_DbPerson_DbPersonPersonId",
                table: "PersonLanguages");

            migrationBuilder.DropForeignKey(
                name: "FK_PersonLanguages_People_PersonId",
                table: "PersonLanguages");

            migrationBuilder.DropTable(
                name: "DbPerson");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "25bbde6b-1f95-4877-a880-cd0b1ae7d553");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "25bbde6b-1f95-4877-a880-cd0b1ae7d553", "76feee72-1ed2-4ebb-ba0b-cf9fbf571a97" });

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

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "76feee72-1ed2-4ebb-ba0b-cf9fbf571a97");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "25bbde6b-1f95-4877-a880-cd0b1ae7d553");

            migrationBuilder.DropColumn(
                name: "City",
                table: "People");

            migrationBuilder.DropColumn(
                name: "CityName",
                table: "People");

            migrationBuilder.CreateTable(
                name: "Person",
                columns: table => new
                {
                    PersonId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CityId = table.Column<int>(type: "int", nullable: false),
                    CityName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Person", x => x.PersonId);
                    table.ForeignKey(
                        name: "FK_Person_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "CityId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "4f3c3cd2-5f03-44ba-ae7a-bc64c3fe8b73", "031bff8c-771a-476d-a023-9cedd3fe2de9", "Admin", "ADMIN" },
                    { "c5b8867f-c30f-448c-a284-848bda5148cd", "2dbc32a2-362b-4cec-adb6-20ea30e5da86", "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "BirthDate", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "c5b8867f-c30f-448c-a284-848bda5148cd", 0, new DateTime(1987, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "9661fd33-092c-47df-ac0f-0bf64b06281e", "admin@admin.com", false, "Admin", "Adminsson", false, null, "ADMIN@ADMIN.COM", "ADMIN@ADMIN.COM", "AQAAAAEAACcQAAAAEDcL3F7RHh9lxV2Xlp+NFZO9crTdQI5T82kMSKIHkc6C3nLNmuRU7+QuLxvIZrVzSg==", null, false, "940c67b6-7080-47de-9e4f-868096888f95", false, "admin@admin.com" });

            migrationBuilder.InsertData(
                table: "Person",
                columns: new[] { "PersonId", "City", "CityId", "CityName", "Name", "PhoneNumber" },
                values: new object[,]
                {
                    { 1, null, 3, null, "Maja Gräddnos", 12345 },
                    { 2, null, 4, null, "Kalle Kaviar", 123457 },
                    { 3, null, 2, null, "Pelle Svanslös", 123458 },
                    { 4, null, 1, null, "Frank Franksson", 123458 },
                    { 5, null, 1, null, "Kalle Söderström", 123458 }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "c5b8867f-c30f-448c-a284-848bda5148cd", "4f3c3cd2-5f03-44ba-ae7a-bc64c3fe8b73" });

            migrationBuilder.CreateIndex(
                name: "IX_Person_CityId",
                table: "Person",
                column: "CityId");

            migrationBuilder.AddForeignKey(
                name: "FK_PersonLanguages_People_DbPersonPersonId",
                table: "PersonLanguages",
                column: "DbPersonPersonId",
                principalTable: "People",
                principalColumn: "PersonId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PersonLanguages_Person_PersonId",
                table: "PersonLanguages",
                column: "PersonId",
                principalTable: "Person",
                principalColumn: "PersonId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
