using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Assignment_MVC.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cities_Countries_CountryName",
                table: "Cities");

            migrationBuilder.DropForeignKey(
                name: "FK_People_Cities_dbCityCityName",
                table: "People");

            migrationBuilder.DropForeignKey(
                name: "FK_PersonLanguages_Languages_LanguageName",
                table: "PersonLanguages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PersonLanguages",
                table: "PersonLanguages");

            migrationBuilder.DropIndex(
                name: "IX_PersonLanguages_LanguageName",
                table: "PersonLanguages");

            migrationBuilder.DropIndex(
                name: "IX_People_dbCityCityName",
                table: "People");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Languages",
                table: "Languages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Countries",
                table: "Countries");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Cities",
                table: "Cities");

            migrationBuilder.DropIndex(
                name: "IX_Cities_CountryName",
                table: "Cities");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7a189cc1-75d4-4361-948d-d6c98c864f21");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "7a189cc1-75d4-4361-948d-d6c98c864f21", "f321e5a1-4cb5-44ca-aede-0b756f9620cf" });

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "CityName",
                keyValue: "Göteborg");

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "CityName",
                keyValue: "Kiruna");

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "CityName",
                keyValue: "Stockholm");

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "CityName",
                keyValue: "Västerås");

            migrationBuilder.DeleteData(
                table: "PersonLanguages",
                keyColumns: new[] { "PersonId", "LanguageName" },
                keyValues: new object[] { 1, "Norwegian" });

            migrationBuilder.DeleteData(
                table: "PersonLanguages",
                keyColumns: new[] { "PersonId", "LanguageName" },
                keyValues: new object[] { 1, "Swedish" });

            migrationBuilder.DeleteData(
                table: "PersonLanguages",
                keyColumns: new[] { "PersonId", "LanguageName" },
                keyValues: new object[] { 2, "Norwegian" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f321e5a1-4cb5-44ca-aede-0b756f9620cf");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7a189cc1-75d4-4361-948d-d6c98c864f21");

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "CountryName",
                keyValue: "Sweden");

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageName",
                keyValue: "Norwegian");

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageName",
                keyValue: "Swedish");

            migrationBuilder.DropColumn(
                name: "LanguageName",
                table: "PersonLanguages");

            migrationBuilder.DropColumn(
                name: "CityName",
                table: "People");

            migrationBuilder.DropColumn(
                name: "dbCityCityName",
                table: "People");

            migrationBuilder.DropColumn(
                name: "CountryName",
                table: "Cities");

            migrationBuilder.AddColumn<int>(
                name: "LanguageId",
                table: "PersonLanguages",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CityId",
                table: "People",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "LanguageName",
                table: "Languages",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<int>(
                name: "LanguageId",
                table: "Languages",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<string>(
                name: "CountryName",
                table: "Countries",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<int>(
                name: "CountryId",
                table: "Countries",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<string>(
                name: "CityName",
                table: "Cities",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<int>(
                name: "CityId",
                table: "Cities",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "CountryId",
                table: "Cities",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_PersonLanguages",
                table: "PersonLanguages",
                columns: new[] { "PersonId", "LanguageId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Languages",
                table: "Languages",
                column: "LanguageId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Countries",
                table: "Countries",
                column: "CountryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cities",
                table: "Cities",
                column: "CityId");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "aaa5c369-25c3-47c1-8fc9-9a61a6bdd2ee", "d0880c0d-d68b-42ca-9497-326a5e839dd4", "Admin", "ADMIN" },
                    { "398dbbf5-fa6a-49ec-af23-173533342773", "985eeea6-1a30-4bb7-af39-6cae58a7638c", "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "BirthDate", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "398dbbf5-fa6a-49ec-af23-173533342773", 0, new DateTime(1987, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "d3e4ccb2-ae8a-45e1-a4c9-ecd56e59a613", "admin@admin.com", false, "Admin", "Adminsson", false, null, "ADMIN@ADMIN.COM", "ADMIN@ADMIN.COM", "AQAAAAEAACcQAAAAENGZVDGvQ7undRVUHXa9eAgIyP2G6i/72bDAqae6wkHdLQnHr4BnqttqkVG5wRT6bA==", null, false, "9ee66990-8217-46c6-86cf-a90fab0d82dd", false, "admin@admin.com" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "CountryId", "CountryName" },
                values: new object[] { 1, "Sweden" });

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "LanguageId", "LanguageName" },
                values: new object[,]
                {
                    { 1, "Swedish" },
                    { 2, "Norwegian" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "398dbbf5-fa6a-49ec-af23-173533342773", "aaa5c369-25c3-47c1-8fc9-9a61a6bdd2ee" });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "CityId", "CityName", "CountryId" },
                values: new object[,]
                {
                    { 1, "Göteborg", 1 },
                    { 2, "Stockholm", 1 },
                    { 3, "Kiruna", 1 },
                    { 4, "Västerås", 1 }
                });

            migrationBuilder.InsertData(
                table: "PersonLanguages",
                columns: new[] { "PersonId", "LanguageId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 2 },
                    { 2, 2 }
                });

            migrationBuilder.UpdateData(
                table: "People",
                keyColumn: "PersonId",
                keyValue: 1,
                column: "CityId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "People",
                keyColumn: "PersonId",
                keyValue: 2,
                column: "CityId",
                value: 4);

            migrationBuilder.UpdateData(
                table: "People",
                keyColumn: "PersonId",
                keyValue: 3,
                column: "CityId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "People",
                keyColumn: "PersonId",
                keyValue: 4,
                column: "CityId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "People",
                keyColumn: "PersonId",
                keyValue: 5,
                column: "CityId",
                value: 1);

            migrationBuilder.CreateIndex(
                name: "IX_PersonLanguages_LanguageId",
                table: "PersonLanguages",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_People_CityId",
                table: "People",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Cities_CountryId",
                table: "Cities",
                column: "CountryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cities_Countries_CountryId",
                table: "Cities",
                column: "CountryId",
                principalTable: "Countries",
                principalColumn: "CountryId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_People_Cities_CityId",
                table: "People",
                column: "CityId",
                principalTable: "Cities",
                principalColumn: "CityId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PersonLanguages_Languages_LanguageId",
                table: "PersonLanguages",
                column: "LanguageId",
                principalTable: "Languages",
                principalColumn: "LanguageId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cities_Countries_CountryId",
                table: "Cities");

            migrationBuilder.DropForeignKey(
                name: "FK_People_Cities_CityId",
                table: "People");

            migrationBuilder.DropForeignKey(
                name: "FK_PersonLanguages_Languages_LanguageId",
                table: "PersonLanguages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PersonLanguages",
                table: "PersonLanguages");

            migrationBuilder.DropIndex(
                name: "IX_PersonLanguages_LanguageId",
                table: "PersonLanguages");

            migrationBuilder.DropIndex(
                name: "IX_People_CityId",
                table: "People");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Languages",
                table: "Languages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Countries",
                table: "Countries");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Cities",
                table: "Cities");

            migrationBuilder.DropIndex(
                name: "IX_Cities_CountryId",
                table: "Cities");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "398dbbf5-fa6a-49ec-af23-173533342773");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "398dbbf5-fa6a-49ec-af23-173533342773", "aaa5c369-25c3-47c1-8fc9-9a61a6bdd2ee" });

            migrationBuilder.DeleteData(
                table: "PersonLanguages",
                keyColumns: new[] { "PersonId", "LanguageId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "PersonLanguages",
                keyColumns: new[] { "PersonId", "LanguageId" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "PersonLanguages",
                keyColumns: new[] { "PersonId", "LanguageId" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "aaa5c369-25c3-47c1-8fc9-9a61a6bdd2ee");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "398dbbf5-fa6a-49ec-af23-173533342773");

            migrationBuilder.DropColumn(
                name: "LanguageId",
                table: "PersonLanguages");

            migrationBuilder.DropColumn(
                name: "CityId",
                table: "People");

            migrationBuilder.DropColumn(
                name: "LanguageId",
                table: "Languages");

            migrationBuilder.DropColumn(
                name: "CountryId",
                table: "Countries");

            migrationBuilder.DropColumn(
                name: "CityId",
                table: "Cities");

            migrationBuilder.DropColumn(
                name: "CountryId",
                table: "Cities");

            migrationBuilder.AddColumn<string>(
                name: "LanguageName",
                table: "PersonLanguages",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CityName",
                table: "People",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "dbCityCityName",
                table: "People",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LanguageName",
                table: "Languages",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "CountryName",
                table: "Countries",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "CityName",
                table: "Cities",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<string>(
                name: "CountryName",
                table: "Cities",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_PersonLanguages",
                table: "PersonLanguages",
                columns: new[] { "PersonId", "LanguageName" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Languages",
                table: "Languages",
                column: "LanguageName");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Countries",
                table: "Countries",
                column: "CountryName");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cities",
                table: "Cities",
                column: "CityName");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "f321e5a1-4cb5-44ca-aede-0b756f9620cf", "86dc4d6b-a7f9-414e-8cef-1b4df6257750", "Admin", "ADMIN" },
                    { "7a189cc1-75d4-4361-948d-d6c98c864f21", "6053e4fd-7ccc-4a3d-a428-2d811b0b45a7", "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "BirthDate", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "7a189cc1-75d4-4361-948d-d6c98c864f21", 0, new DateTime(1987, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "6a17afb9-1eed-497b-a815-1b2a39cfab74", "admin@admin.com", false, "Admin", "Adminsson", false, null, "ADMIN@ADMIN.COM", "ADMIN@ADMIN.COM", "AQAAAAEAACcQAAAAEJmeEAKASdZJMJ47pyq4AwknI75GC0P/yAKHf0hpIotlyGFtWsOLIJA5azIW2J3Tkg==", null, false, "20d57e8a-68c4-4bc1-aed9-ace79fd9cb9b", false, "admin@admin.com" });

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

            migrationBuilder.UpdateData(
                table: "People",
                keyColumn: "PersonId",
                keyValue: 1,
                column: "CityName",
                value: "Kiruna");

            migrationBuilder.UpdateData(
                table: "People",
                keyColumn: "PersonId",
                keyValue: 2,
                column: "CityName",
                value: "Västerås");

            migrationBuilder.UpdateData(
                table: "People",
                keyColumn: "PersonId",
                keyValue: 3,
                column: "CityName",
                value: "Stockholm");

            migrationBuilder.UpdateData(
                table: "People",
                keyColumn: "PersonId",
                keyValue: 4,
                column: "CityName",
                value: "Göteborg");

            migrationBuilder.UpdateData(
                table: "People",
                keyColumn: "PersonId",
                keyValue: 5,
                column: "CityName",
                value: "Göteborg");

            migrationBuilder.InsertData(
                table: "PersonLanguages",
                columns: new[] { "PersonId", "LanguageName" },
                values: new object[,]
                {
                    { 1, "Swedish" },
                    { 1, "Norwegian" },
                    { 2, "Norwegian" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "7a189cc1-75d4-4361-948d-d6c98c864f21", "f321e5a1-4cb5-44ca-aede-0b756f9620cf" });

            migrationBuilder.CreateIndex(
                name: "IX_PersonLanguages_LanguageName",
                table: "PersonLanguages",
                column: "LanguageName");

            migrationBuilder.CreateIndex(
                name: "IX_People_dbCityCityName",
                table: "People",
                column: "dbCityCityName");

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
                name: "FK_People_Cities_dbCityCityName",
                table: "People",
                column: "dbCityCityName",
                principalTable: "Cities",
                principalColumn: "CityName",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PersonLanguages_Languages_LanguageName",
                table: "PersonLanguages",
                column: "LanguageName",
                principalTable: "Languages",
                principalColumn: "LanguageName",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
