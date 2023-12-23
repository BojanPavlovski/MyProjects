using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LibraryManagementSystem.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class _secondMig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "RentInfo",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateOfPickUp", "DateOfReturn" },
                values: new object[] { new DateTime(2023, 10, 21, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2023, 11, 4, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "RentInfo",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateOfPickUp", "DateOfReturn" },
                values: new object[] { new DateTime(2023, 10, 21, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2023, 11, 4, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.InsertData(
                table: "RentInfo",
                columns: new[] { "Id", "BookId", "DateOfPickUp", "DateOfReturn", "Price", "UserId" },
                values: new object[] { 3, 3, new DateTime(2023, 10, 21, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2023, 11, 4, 0, 0, 0, 0, DateTimeKind.Local), 50, 5 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "RentInfo",
                keyColumn: "Id",
                keyValue: 3);

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
        }
    }
}
