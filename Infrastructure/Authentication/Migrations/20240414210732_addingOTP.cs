using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Authentication.Migrations
{
    /// <inheritdoc />
    public partial class addingOTP : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1d244655-00c8-49be-9f59-6ef42875ee37");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4900926c-4fc3-4434-9a08-534367bc087d");

            migrationBuilder.AddColumn<DateTime>(
                name: "Expire",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Otp",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0c6be587-9f93-43c7-9000-1af27f6cd78c", null, "Admin", "ADMIN" },
                    { "a9616627-4380-4bed-96eb-e89fd9fdfe0e", null, "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0c6be587-9f93-43c7-9000-1af27f6cd78c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a9616627-4380-4bed-96eb-e89fd9fdfe0e");

            migrationBuilder.DropColumn(
                name: "Expire",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Otp",
                table: "AspNetUsers");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1d244655-00c8-49be-9f59-6ef42875ee37", null, "Admin", "ADMIN" },
                    { "4900926c-4fc3-4434-9a08-534367bc087d", null, "User", "USER" }
                });
        }
    }
}
