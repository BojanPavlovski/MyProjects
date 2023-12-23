using SEDC.BurgerApp.Domain.Orders;

namespace SEDC.BurgerApp.Domain.Burgers
{
    public class Burger : BaseEntity
    {
        public string Name { get; set; }
        public int Price { get; set; }
        public bool IsVegetarian { get; set; }
        public bool IsVegan { get; set; }
        public bool HasFries { get; set; }
        public List<BurgerOrder> Burgers { get; set;}

    }
}
