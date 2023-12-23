using SEDC.BurgerApp.Domain.Burgers;

namespace SEDC.BurgerApp.Domain.Orders
{
    public class BurgerOrder : BaseEntity
    {
        //foreign key for Burger
        public int BurgerId { get; set; }
        public Burger Burger { get; set; }
        //foreign key for Order
        public int OrderId { get; set; }
        public Order Order { get; set; }
        public int NumberOfBurgers { get; set; }
       
    }
}
