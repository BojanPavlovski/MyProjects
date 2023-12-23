using Microsoft.EntityFrameworkCore;
using SEDC.BurgerApp.Domain.Burgers;
using SEDC.BurgerApp.Domain.Orders;

namespace SEDC.BurgerApp.DataAccess
{
    public class BurgerAppDbContext : DbContext
    {
        public BurgerAppDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Order> Orders { get; set; }
        public DbSet<Burger> Burgers { get; set; }
        public DbSet<BurgerOrder> BurgerOrders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //defining relations
            modelBuilder.Entity<Order>()
                .HasMany(x => x.Burgers)
                .WithOne(x => x.Order)
                .HasForeignKey(x => x.OrderId);

            modelBuilder.Entity<Burger>()
                .HasMany(x => x.Burgers)
                .WithOne(x => x.Burger)
                .HasForeignKey(x => x.BurgerId);

            //seeding
            //Burgers
            modelBuilder.Entity<Burger>()
                .HasData
                (
                    new Burger
                    {
                        Id = 1,
                        Name = "Hamburger",
                        Price = 250,
                        IsVegetarian = false,
                        IsVegan = false,
                        HasFries = true,
                        Burgers = new List<BurgerOrder> { }
                    },
                new Burger
                {
                    Id = 2,
                    Name = "Cheeseburger",
                    Price = 300,
                    IsVegetarian = true,
                    IsVegan = false,
                    HasFries = true,
                    Burgers = new List<BurgerOrder> { }
                },
                new Burger
                {
                    Id = 3,
                    Name = "Bacon Burger",
                    Price = 350,
                    IsVegetarian = false,
                    IsVegan = false,
                    HasFries = true,
                    Burgers = new List<BurgerOrder> { }
                }
                );

            //Orders
            modelBuilder.Entity<Order>()
                .HasData
                (
                     new Order
                     {
                         Id = 1,
                         FullName = "Petko Petkovski",
                         Address = "Leninova 1",
                         IsDelivered = false,
                         Location = "Partizanski odredi"
                       
                     },
                     new Order
                     {
                         Id = 2,
                         FullName = "Marko Markovski",
                         Address = "Leninova 2",
                         IsDelivered = true,
                         Location = "Partizanski odredi"
                     }
                );

            //BurgerOrders
            modelBuilder.Entity<BurgerOrder>()
                .HasData
                (
                     new BurgerOrder
                     {
                         Id = 1,
                         BurgerId = 1,
                         OrderId = 1,
                         NumberOfBurgers = 1
                     },
                      new BurgerOrder
                      {
                          Id = 3,
                          BurgerId = 2,
                          OrderId = 2,
                          NumberOfBurgers = 1
                      }
                );
        }

    }
}
