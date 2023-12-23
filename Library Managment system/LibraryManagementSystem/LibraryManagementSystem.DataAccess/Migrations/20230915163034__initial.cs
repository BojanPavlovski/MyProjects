using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LibraryManagementSystem.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class _initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Admins",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Firstname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Lastname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admins", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Author = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Year = table.Column<int>(type: "int", maxLength: 4, nullable: false),
                    Genre = table.Column<int>(type: "int", maxLength: 30, nullable: false),
                    Availability = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Firstname = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Lastname = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Phonenumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TypeOfUser = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RentInfo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    BookId = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false),
                    DateOfPickUp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateOfReturn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RentInfo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RentInfo_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RentInfo_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Author", "Availability", "Genre", "Title", "Year" },
                values: new object[,]
                {
                    { 1, "Michel Bussi", true, 8, "Black Water Lillies", 2011 },
                    { 2, "Edgar Allan Poe", true, 11, "The Raven", 1845 },
                    { 3, "F. Scott Fitzgerald", true, 12, "The Great Gatsby", 1925 },
                    { 4, "Toni Morrison", true, 12, "Beloved", 1987 }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Address", "Email", "Firstname", "Lastname", "Password", "Phonenumber", "TypeOfUser", "UserName" },
                values: new object[,]
                {
                    { 1, "Kensignton street 58b", "joe_doe@gmail.com", "Joe", "Doe", "password", "123456789", 1, "joe123" },
                    { 2, "Myrtle bay 546", "mrichardson@gmail.com", "Michael", "Richardson", "password", "123456789", 1, "mich123" }
                });

            migrationBuilder.InsertData(
                table: "RentInfo",
                columns: new[] { "Id", "BookId", "DateOfPickUp", "DateOfReturn", "Price", "UserId" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2023, 9, 15, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2023, 9, 29, 0, 0, 0, 0, DateTimeKind.Local), 50, 1 },
                    { 2, 2, new DateTime(2023, 9, 15, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2023, 9, 29, 0, 0, 0, 0, DateTimeKind.Local), 50, 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_RentInfo_BookId",
                table: "RentInfo",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_RentInfo_UserId",
                table: "RentInfo",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Admins");

            migrationBuilder.DropTable(
                name: "RentInfo");

            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
