using LibraryManagementSystem.Domain.Domain;
using LibraryManagementSystem.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using System.Text;
using XSystem.Security.Cryptography;

namespace LibraryManagementSystem.DataAccess
{
    public class LibraryManagementSystemDbContext : DbContext
    {
        public LibraryManagementSystemDbContext(DbContextOptions options) : base(options) { }
        //Entities stored in Database
        public DbSet<Book> Books { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<RentInfo> RentInfo { get; set; }

        //modeling entities and their relations
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Book
            modelBuilder.Entity<Book>()
                .Property(x => x.Title)
                .HasMaxLength(100)
                .IsRequired();

            modelBuilder.Entity<Book>()
              .Property(x => x.Author)
              .HasMaxLength(50)
              .IsRequired();

            modelBuilder.Entity<Book>()
              .Property(x => x.Year)
              .HasMaxLength(4);

            modelBuilder.Entity<Book>()
              .Property(x => x.Genre)
              .HasMaxLength(30)
              .IsRequired();

            modelBuilder.Entity<Book>()
              .Property(x => x.Availability)
              .IsRequired();

            //Relations

            modelBuilder.Entity<Book>()
                .HasMany(x => x.RentInfo)
                .WithOne(x => x.Book)
                .HasForeignKey(x => x.BookId);

            //User
            modelBuilder.Entity<User>()
                .Property(x => x.Firstname)
                .HasMaxLength(100)
                .IsRequired();

            modelBuilder.Entity<User>()
            .Property(x => x.Lastname)
            .HasMaxLength(100)
            .IsRequired();

            modelBuilder.Entity<User>()
            .Property(x => x.Address)
            .HasMaxLength(100)
            .IsRequired();

            modelBuilder.Entity<User>()
            .Property(x => x.Phonenumber)
            .HasMaxLength(20)
            .IsRequired();

            modelBuilder.Entity<User>()
            .Property(x => x.Email)
            .HasMaxLength(60)
            .IsRequired();

            modelBuilder.Entity<User>()
            .Property(x => x.UserName)
            .HasMaxLength(30)
            .IsRequired();



            //Relations
            modelBuilder.Entity<User>()
                .HasMany(x => x.RentInfo)
                .WithOne(x => x.User)
                .HasForeignKey(x => x.UserId);

            var md5 = new MD5CryptoServiceProvider();
            var md5data = md5.ComputeHash(Encoding.ASCII.GetBytes("123456bojan"));
            var hashedPassword = Encoding.ASCII.GetString(md5data);

            //Seeding
            //Seeding for needed entities
            modelBuilder.Entity<Book>()
                .HasData
                (
                    new Book { Id = 1, Title = "Black Water Lillies", Author = "Michel Bussi", Genre = GenreEnum.Mystery, Availability = true, Year = 2011, RentInfo = new List<RentInfo> { } },
                    new Book { Id = 2, Title = "The Raven", Author = "Edgar Allan Poe", Genre = GenreEnum.Poetry, Availability = true, Year = 1845, RentInfo = new List<RentInfo> { } },
                    new Book { Id = 3, Title = "The Great Gatsby", Author = "F. Scott Fitzgerald", Genre = GenreEnum.Novel, Availability = true, Year = 1925, RentInfo = new List<RentInfo> { } },
                    new Book { Id = 4, Title = "Beloved", Author = "Toni Morrison", Genre = GenreEnum.Novel, Availability = true, Year = 1987, RentInfo = new List<RentInfo> { } }
                );

            modelBuilder.Entity<User>()
                .HasData
                (
                    new User { Id = 1, Firstname = "Bojan", Lastname = "Doe", Address = "Kensignton street 58b", Email = "joe_doe@gmail.com", Phonenumber = "123456789", UserName = "joe123", RentInfo = new List<RentInfo> { } },
                    new User { Id = 2, Firstname = "Mark", Lastname = "Richardson", Address = "Myrtle bay 546", Email = "mrichardson@gmail.com", Phonenumber = "123456789", UserName = "mich123", RentInfo = new List<RentInfo> { } }

                );

            modelBuilder.Entity<RentInfo>()
                .HasData
                (
                    new RentInfo { Id = 1, BookId = 1, UserId = 1, DateOfPickUp = DateTime.Today, Price = 50, BookTitle = "Black Water Lillies" },
                    new RentInfo { Id = 2, BookId = 2, UserId = 2, DateOfPickUp = DateTime.Today, Price = 50, BookTitle = "The Raven" },
                    new RentInfo { Id = 3, BookId = 3, UserId = 5, DateOfPickUp = DateTime.Today, Price = 50, BookTitle = "The Great Gatsby" }
                );

            modelBuilder.Entity<Admin>()
                .HasData
                (
                    new Admin { Id = 1, Firstname = "Michael", Lastname = "Scott", Email = "scott123@gmail.com", Username = "scott123", Password = hashedPassword }
                );
        }
    }
}
