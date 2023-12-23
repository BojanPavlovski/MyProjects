using SEDC.BurgerApp.Domain.Burgers;

namespace SEDC.BurgerApp.ViewModels
{
    public class HomeIndexViewModel
    {
        public int NumberOfOrders { get; set; }
        public double AverageOrderPrice { get; set; }
        public Burger PopularBurger { get; set; }

    }
}
