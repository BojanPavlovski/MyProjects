namespace SEDC.BurgerApp.ViewModels.Burgers
{
    public class BurgerDetailsViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public bool HasFries { get; set; }
        public bool IsVegan { get; set; }
    }
}
