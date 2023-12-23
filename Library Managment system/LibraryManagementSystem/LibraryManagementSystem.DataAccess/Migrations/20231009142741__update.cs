using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LibraryManagementSystem.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class _update : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "RentInfo",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateOfPickUp", "DateOfReturn" },
                values: new object[] { new DateTime(2023, 10, 9, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2023, 10, 23, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "RentInfo",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateOfPickUp", "DateOfReturn" },
                values: new object[] { new DateTime(2023, 10, 9, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2023, 10, 23, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Firstname", "Password" },
                values: new object[] { "Bojan", "??????]?6~?\"\n?" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Firstname", "Password" },
                values: new object[] { "Mark", "??????]?6~?\"\n?" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "RentInfo",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateOfPickUp", "DateOfReturn" },
                values: new object[] { new DateTime(2023, 9, 15, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2023, 9, 29, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "RentInfo",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateOfPickUp", "DateOfReturn" },
                values: new object[] { new DateTime(2023, 9, 15, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2023, 9, 29, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Firstname", "Password" },
                values: new object[] { "Joe", "password" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Firstname", "Password" },
                values: new object[] { "Michael", "password" });
        }
    }
}
