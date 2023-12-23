using SEDC.BurgerApp.Domain.Burgers;
using SEDC.BurgerApp.ViewModels.Burgers;

namespace SEDC.BurgerApp.Services.Interfaces
{
    public interface IBurgerService
    {
        List<BurgerToDropdownViewModel> GetAllBurgersForDropdown();
        List<BurgerListViewModel> GetAllBurgers();
        BurgerDetailsViewModel BurgerDetails(int id);
        public void DeleteBurger(int id);
        public void AddBurger(BurgerDetailsViewModel model);
        public Burger EditBurger(int id);
        public void ConfirmEdit(Burger burgerDb);
    }
}
