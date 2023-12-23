using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LibraryManagementSystem.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class _insertAdmin : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Admins",
                columns: new[] { "Id", "Email", "Firstname", "Lastname", "Password", "Username" },
                values: new object[] { 1, "scott123@gmail.com", "Michael", "Scott", "??????]?6~?\"\n?", "scott123" });

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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Admins",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.UpdateData(
                table: "RentInfo",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateOfPickUp", "DateOfReturn" },
                values: new object[] { new DateTime(2023, 10, 27, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2023, 11, 10, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "RentInfo",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateOfPickUp", "DateOfReturn" },
                values: new object[] { new DateTime(2023, 10, 27, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2023, 11, 10, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "RentInfo",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateOfPickUp", "DateOfReturn" },
                values: new object[] { new DateTime(2023, 10, 27, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2023, 11, 10, 0, 0, 0, 0, DateTimeKind.Local) });
        }
    }
}
