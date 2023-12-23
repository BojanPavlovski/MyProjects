using System.ComponentModel.DataAnnotations;

namespace SEDC.BurgerApp.ViewModels.Orders
{
    public class AddBurgerViewModel
    {
        [Display(Name ="Burger")]
        public int BurgerId { get; set; }

        [Display(Name ="Number of burgers")]
        public int NumberOfBurgers { get; set; }
        public int OrderId { get; set; }
    }
}
