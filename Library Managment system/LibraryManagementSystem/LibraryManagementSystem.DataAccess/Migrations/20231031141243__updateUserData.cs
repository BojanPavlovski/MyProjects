using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LibraryManagementSystem.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class _updateUserData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Password",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "TypeOfUser",
                table: "Users");

            migrationBuilder.UpdateData(
                table: "RentInfo",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateOfPickUp", "DateOfReturn" },
                values: new object[] { new DateTime(2023, 10, 31, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2023, 11, 14, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "RentInfo",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateOfPickUp", "DateOfReturn" },
                values: new object[] { new DateTime(2023, 10, 31, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2023, 11, 14, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "RentInfo",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateOfPickUp", "DateOfReturn" },
                values: new object[] { new DateTime(2023, 10, 31, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2023, 11, 14, 0, 0, 0, 0, DateTimeKind.Local) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Users",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "TypeOfUser",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "RentInfo",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateOfPickUp", "DateOfReturn" },
                values: new object[] { new DateTime(2023, 10, 29, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2023, 11, 12, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "RentInfo",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateOfPickUp", "DateOfReturn" },
                values: new object[] { new DateTime(2023, 10, 29, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2023, 11, 12, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "RentInfo",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateOfPickUp", "DateOfReturn" },
                values: new object[] { new DateTime(2023, 10, 29, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2023, 11, 12, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Password", "TypeOfUser" },
                values: new object[] { "??????]?6~?\"\n?", 1 });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Password", "TypeOfUser" },
                values: new object[] { "??????]?6~?\"\n?", 1 });
        }
    }
}
