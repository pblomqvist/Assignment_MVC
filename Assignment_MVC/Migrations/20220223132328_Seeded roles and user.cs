using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Assignment_MVC.Migrations
{
    public partial class Seededrolesanduser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "bfd8e61a-8a6c-412b-875e-0df1dabc28b1", "9453bcb7-5db8-4b33-952e-b89757192ba1", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "26c2c9f7-6776-4a41-94d4-b4d49dea44b4", "bc48ee3e-33cd-4626-8278-71307ffcae55", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "BirthDate", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "26c2c9f7-6776-4a41-94d4-b4d49dea44b4", 0, new DateTime(1987, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "8c17ba34-e7d0-49a4-a10d-2ddc82a54256", "admin@admin.com", false, "Admin", "Adminsson", false, null, "ADMIN@ADMIN.COM", "ADMIN@ADMIN.COM", "AQAAAAEAACcQAAAAEGrHC5ZE5KlyROLDWfcp38m6jQM9ePnob0M4JJwLeRTxxq6bskmgEIMjz6wyerRpNQ==", null, false, "4f2032f1-d4f8-43a9-b809-66099b33d3a5", false, "admin@admin.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "26c2c9f7-6776-4a41-94d4-b4d49dea44b4", "bfd8e61a-8a6c-412b-875e-0df1dabc28b1" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "26c2c9f7-6776-4a41-94d4-b4d49dea44b4");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "26c2c9f7-6776-4a41-94d4-b4d49dea44b4", "bfd8e61a-8a6c-412b-875e-0df1dabc28b1" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bfd8e61a-8a6c-412b-875e-0df1dabc28b1");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "26c2c9f7-6776-4a41-94d4-b4d49dea44b4");
        }
    }
}
