using SEDC.BurgerApp.Domain.Burgers;
using SEDC.BurgerApp.Domain.Orders;

namespace SEDC.BurgerApp.DataAccess
{
    public static class StaticDb
    {
        public static int BurgerId { get; set; }
        public static int OrderId { get; set; }
        public static List<Burger> Burgers { get; set; } 
        public static List<Order> Orders { get; set; }
        
        static StaticDb()
        {
            Burgers = new List<Burger>
            {
                new Burger
                {
                    Id = 1,
                    Name = "Hamburger",
                    Price = 250,
                    IsVegetarian = false,
                    IsVegan = false,
                    HasFries = true,
                    Burgers = new List<BurgerOrder> {}
                },
                new Burger
                {
                    Id = 2,
                    Name = "Cheeseburger",
                    Price = 300,
                    IsVegetarian = true,
                    IsVegan = false,
                    HasFries = true,
                    Burgers = new List<BurgerOrder>{}
                },
                new Burger
                {
                    Id = 3,
                    Name = "Bacon Burger",
                    Price = 350,
                    IsVegetarian = false,
                    IsVegan = false,
                    HasFries = true,
                    Burgers = new List<BurgerOrder>{}
                }

            };
            Orders = new List<Order>
            {
                new Order
                {
                    Id = 1,
                    FullName = "Petko Petkovski",
                    Address = "Leninova 1",
                    IsDelivered = false,
                    Burgers = new List<BurgerOrder>
                    {
                        new BurgerOrder
                        {
                            Id = 1,
                            Burger = Burgers[0],
                            BurgerId = Burgers[0].Id,
                            OrderId = 1,
                            NumberOfBurgers = 1
                        },
                        new BurgerOrder
                        {
                            Id = 2,
                            Burger = Burgers[1],
                            BurgerId = Burgers[1].Id,
                            OrderId = 1,
                            NumberOfBurgers = 1
                        }
                    }
                },
                new Order
                {
                    Id = 2,
                    FullName = "Marko Markovski",
                    Address = "Leninova 2",
                    IsDelivered = true,
                    Burgers = new List<BurgerOrder>
                    {
                        new BurgerOrder
                        {
                            Id = 3,
                            Burger = Burgers[2],
                            BurgerId = Burgers[2].Id,
                            OrderId = 2,
                            NumberOfBurgers = 1
                        },
                         new BurgerOrder
                        {
                            Id = 2,
                            Burger = Burgers[1],
                            BurgerId = Burgers[1].Id,
                            OrderId = 2,
                            NumberOfBurgers = 1
                        }
                    }
                }
            };
        }

    }
}
