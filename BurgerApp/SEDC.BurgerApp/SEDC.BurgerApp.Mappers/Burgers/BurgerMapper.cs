using SEDC.BurgerApp.Domain.Burgers;
using SEDC.BurgerApp.ViewModels.Burgers;


namespace SEDC.BurgerApp.Mappers.Burgers
{
    public static class BurgerMapper
    {
        //mapping Burger to BurgerToDropdownViewModel
        public static BurgerToDropdownViewModel ToDropdownViewModel(Burger burger)
        {
            return new BurgerToDropdownViewModel
            {
                Id = burger.Id,
                Name = burger.Name
            };
        }

        //mapping from Burger to BurgerListViewModel
        public static BurgerListViewModel BurgerListViewModel(Burger burger)
        {
            return new BurgerListViewModel
            {
                Id = burger.Id,
                Name = burger.Name,
                Price = burger.Price,
                HasFries = burger.HasFries
            };
        }

        //mapping from Burger to BurgerDetailsViewModel
        public static BurgerDetailsViewModel BurgerDetailsViewModel(Burger burger)
        {
            return new BurgerDetailsViewModel
            {
                Id = burger.Id,
                Name = burger.Name,
                Price = burger.Price,
                HasFries = burger.HasFries,
                IsVegan = burger.IsVegan
            };
        }
    }
}
