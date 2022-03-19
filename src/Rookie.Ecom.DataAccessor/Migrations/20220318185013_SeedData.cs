using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Rookie.Ecom.DataAccessor.Migrations
{
    public partial class SeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "CreatedDate", "CreatorId", "Name", "Pubished", "Status", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("ad4e4ee0-e123-4839-b27e-2a4b79ed826a"), new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Admin", true, 1, new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("593887de-f117-44b5-a2f0-f2048d056bb9"), new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Customer", true, 1, new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("1f9f4525-99ba-4280-bbd9-d81694b1ff47"), new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Employee", true, 1, new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Birthday", "CreatedDate", "CreatorId", "Email", "Name", "Password", "Pubished", "Status", "UpdatedDate", "UserName" },
                values: new object[] { new Guid("d0ac3342-b8b2-474b-bc39-404812481411"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "admin@gmail.com", "Admin", "123456", true, 1, new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Admin" });

            migrationBuilder.InsertData(
                table: "UserRole",
                columns: new[] { "Id", "CreatedDate", "CreatorId", "Pubished", "RoleId", "Status", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("d0ac3342-b8b2-474b-bc39-404812481411"), new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, true, new Guid("ad4e4ee0-e123-4839-b27e-2a4b79ed826a"), true, new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("d0ac3342-b8b2-474b-bc39-404812481411") });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("1f9f4525-99ba-4280-bbd9-d81694b1ff47"));

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("593887de-f117-44b5-a2f0-f2048d056bb9"));

            migrationBuilder.DeleteData(
                table: "UserRole",
                keyColumn: "Id",
                keyValue: new Guid("d0ac3342-b8b2-474b-bc39-404812481411"));

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("ad4e4ee0-e123-4839-b27e-2a4b79ed826a"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("d0ac3342-b8b2-474b-bc39-404812481411"));
        }
    }
}
