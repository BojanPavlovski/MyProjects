using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LibraryManagementSystem.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class _updateRentInfo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BookTitle",
                table: "RentInfo",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "RentInfo",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "BookTitle", "DateOfPickUp", "DateOfReturn" },
                values: new object[] { "Black Water Lillies", new DateTime(2023, 10, 27, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2023, 11, 10, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "RentInfo",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "BookTitle", "DateOfPickUp", "DateOfReturn" },
                values: new object[] { "The Raven", new DateTime(2023, 10, 27, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2023, 11, 10, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "RentInfo",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "BookTitle", "DateOfPickUp", "DateOfReturn" },
                values: new object[] { "The Great Gatsby", new DateTime(2023, 10, 27, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2023, 11, 10, 0, 0, 0, 0, DateTimeKind.Local) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BookTitle",
                table: "RentInfo");

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

            migrationBuilder.UpdateData(
                table: "RentInfo",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateOfPickUp", "DateOfReturn" },
                values: new object[] { new DateTime(2023, 10, 21, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2023, 11, 4, 0, 0, 0, 0, DateTimeKind.Local) });
        }
    }
}
