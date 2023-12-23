namespace SEDC.BurgerApp.Domain.Orders
{
    public class Order : BaseEntity
    {
        public string FullName { get; set; }
        public string Address { get; set; }
        public bool IsDelivered { get; set; }
        public List<BurgerOrder> Burgers { get; set; }
        public string Location { get; set; }
        

        public Order()
        {
            Burgers = new List<BurgerOrder>();
        }

    }
}
