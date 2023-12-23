namespace SEDC.BurgerApp.ViewModels.Orders
{
    public class OrderDetailsViewModel
    {
        public int Id { get; set; }
        public string UserFullName { get; set; }
        public bool isDelivered { get; set; }
        public List<string> BurgerNames { get; set; }
        public int TotalPrice { get; set; }
        public string Location { get; set; }
        public string Address { get; set; }
    }
}
