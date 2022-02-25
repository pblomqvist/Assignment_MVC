using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Assignment_MVC.Migrations
{
    public partial class AddCityNamecolumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "398dbbf5-fa6a-49ec-af23-173533342773");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "398dbbf5-fa6a-49ec-af23-173533342773", "aaa5c369-25c3-47c1-8fc9-9a61a6bdd2ee" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "aaa5c369-25c3-47c1-8fc9-9a61a6bdd2ee");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "398dbbf5-fa6a-49ec-af23-173533342773");

            migrationBuilder.AddColumn<string>(
                name: "CityName",
                table: "People",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "1c864a52-bc86-4431-85b3-fc9fa5054b8f", "4ae26bd0-2d14-4810-b9f8-b673a66272d2", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "ab069b11-6e4d-4c94-b0e3-54d9253f5fd2", "f98c92a5-c997-4255-b3c8-0f926c7fb2fa", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "BirthDate", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "ab069b11-6e4d-4c94-b0e3-54d9253f5fd2", 0, new DateTime(1987, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "99eaa685-879b-47ea-a0ab-5f8618cdcbc9", "admin@admin.com", false, "Admin", "Adminsson", false, null, "ADMIN@ADMIN.COM", "ADMIN@ADMIN.COM", "AQAAAAEAACcQAAAAEPV9PUHqPp/ZXRlIW8vY0K/w4lfnAU+rZUpiT0BBslORTTzta5yjBN+rs0Cd9rP2jg==", null, false, "6c1a6229-a874-42e6-977b-ccc1ef8cd597", false, "admin@admin.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "ab069b11-6e4d-4c94-b0e3-54d9253f5fd2", "1c864a52-bc86-4431-85b3-fc9fa5054b8f" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ab069b11-6e4d-4c94-b0e3-54d9253f5fd2");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "ab069b11-6e4d-4c94-b0e3-54d9253f5fd2", "1c864a52-bc86-4431-85b3-fc9fa5054b8f" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1c864a52-bc86-4431-85b3-fc9fa5054b8f");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ab069b11-6e4d-4c94-b0e3-54d9253f5fd2");

            migrationBuilder.DropColumn(
                name: "CityName",
                table: "People");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "aaa5c369-25c3-47c1-8fc9-9a61a6bdd2ee", "d0880c0d-d68b-42ca-9497-326a5e839dd4", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "398dbbf5-fa6a-49ec-af23-173533342773", "985eeea6-1a30-4bb7-af39-6cae58a7638c", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "BirthDate", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "398dbbf5-fa6a-49ec-af23-173533342773", 0, new DateTime(1987, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "d3e4ccb2-ae8a-45e1-a4c9-ecd56e59a613", "admin@admin.com", false, "Admin", "Adminsson", false, null, "ADMIN@ADMIN.COM", "ADMIN@ADMIN.COM", "AQAAAAEAACcQAAAAENGZVDGvQ7undRVUHXa9eAgIyP2G6i/72bDAqae6wkHdLQnHr4BnqttqkVG5wRT6bA==", null, false, "9ee66990-8217-46c6-86cf-a90fab0d82dd", false, "admin@admin.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "398dbbf5-fa6a-49ec-af23-173533342773", "aaa5c369-25c3-47c1-8fc9-9a61a6bdd2ee" });
        }
    }
}
