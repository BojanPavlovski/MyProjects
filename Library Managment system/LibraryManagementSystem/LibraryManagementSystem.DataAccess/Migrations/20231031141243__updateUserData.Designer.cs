﻿// <auto-generated />
using System;
using LibraryManagementSystem.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace LibraryManagementSystem.DataAccess.Migrations
{
    [DbContext(typeof(LibraryManagementSystemDbContext))]
    [Migration("20231031141243__updateUserData")]
    partial class _updateUserData
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("LibraryManagementSystem.Domain.Domain.Admin", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Firstname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Lastname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Admins");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "scott123@gmail.com",
                            Firstname = "Michael",
                            Lastname = "Scott",
                            Password = "??????]?6~?\"\n?",
                            Username = "scott123"
                        });
                });

            modelBuilder.Entity("LibraryManagementSystem.Domain.Domain.Book", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Author")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<bool>("Availability")
                        .HasColumnType("bit");

                    b.Property<int>("Genre")
                        .HasMaxLength(30)
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("Year")
                        .HasMaxLength(4)
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Books");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Author = "Michel Bussi",
                            Availability = true,
                            Genre = 8,
                            Title = "Black Water Lillies",
                            Year = 2011
                        },
                        new
                        {
                            Id = 2,
                            Author = "Edgar Allan Poe",
                            Availability = true,
                            Genre = 11,
                            Title = "The Raven",
                            Year = 1845
                        },
                        new
                        {
                            Id = 3,
                            Author = "F. Scott Fitzgerald",
                            Availability = true,
                            Genre = 12,
                            Title = "The Great Gatsby",
                            Year = 1925
                        },
                        new
                        {
                            Id = 4,
                            Author = "Toni Morrison",
                            Availability = true,
                            Genre = 12,
                            Title = "Beloved",
                            Year = 1987
                        });
                });

            modelBuilder.Entity("LibraryManagementSystem.Domain.Domain.RentInfo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("BookId")
                        .HasColumnType("int");

                    b.Property<string>("BookTitle")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateOfPickUp")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateOfReturn")
                        .HasColumnType("datetime2");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BookId");

                    b.HasIndex("UserId");

                    b.ToTable("RentInfo");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            BookId = 1,
                            BookTitle = "Black Water Lillies",
                            DateOfPickUp = new DateTime(2023, 10, 31, 0, 0, 0, 0, DateTimeKind.Local),
                            DateOfReturn = new DateTime(2023, 11, 14, 0, 0, 0, 0, DateTimeKind.Local),
                            Price = 50,
                            UserId = 1
                        },
                        new
                        {
                            Id = 2,
                            BookId = 2,
                            BookTitle = "The Raven",
                            DateOfPickUp = new DateTime(2023, 10, 31, 0, 0, 0, 0, DateTimeKind.Local),
                            DateOfReturn = new DateTime(2023, 11, 14, 0, 0, 0, 0, DateTimeKind.Local),
                            Price = 50,
                            UserId = 2
                        },
                        new
                        {
                            Id = 3,
                            BookId = 3,
                            BookTitle = "The Great Gatsby",
                            DateOfPickUp = new DateTime(2023, 10, 31, 0, 0, 0, 0, DateTimeKind.Local),
                            DateOfReturn = new DateTime(2023, 11, 14, 0, 0, 0, 0, DateTimeKind.Local),
                            Price = 50,
                            UserId = 5
                        });
                });

            modelBuilder.Entity("LibraryManagementSystem.Domain.Domain.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.Property<string>("Firstname")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Lastname")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Phonenumber")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Address = "Kensignton street 58b",
                            Email = "joe_doe@gmail.com",
                            Firstname = "Bojan",
                            Lastname = "Doe",
                            Phonenumber = "123456789",
                            UserName = "joe123"
                        },
                        new
                        {
                            Id = 2,
                            Address = "Myrtle bay 546",
                            Email = "mrichardson@gmail.com",
                            Firstname = "Mark",
                            Lastname = "Richardson",
                            Phonenumber = "123456789",
                            UserName = "mich123"
                        });
                });

            modelBuilder.Entity("LibraryManagementSystem.Domain.Domain.RentInfo", b =>
                {
                    b.HasOne("LibraryManagementSystem.Domain.Domain.Book", "Book")
                        .WithMany("RentInfo")
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LibraryManagementSystem.Domain.Domain.User", "User")
                        .WithMany("RentInfo")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Book");

                    b.Navigation("User");
                });

            modelBuilder.Entity("LibraryManagementSystem.Domain.Domain.Book", b =>
                {
                    b.Navigation("RentInfo");
                });

            modelBuilder.Entity("LibraryManagementSystem.Domain.Domain.User", b =>
                {
                    b.Navigation("RentInfo");
                });
#pragma warning restore 612, 618
        }
    }
}
