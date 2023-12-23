using SEDC.BurgerApp.DataAccess.Interfaces;
using SEDC.BurgerApp.Domain.Burgers;
using SEDC.BurgerApp.Mappers.Burgers;
using SEDC.BurgerApp.Services.Interfaces;
using SEDC.BurgerApp.ViewModels.Burgers;


namespace SEDC.BurgerApp.Services.Implementations
{
    public  class BurgerService : IBurgerService
    {
        private IRepository<Burger> _burgerRepository;

        public BurgerService(IRepository<Burger> burgerRepository)
        {
            _burgerRepository = burgerRepository;
        }

        //show all burgers
        public List<BurgerListViewModel> GetAllBurgers()
        {
            //calling repository to retrive all burgers from db
            List<Burger> burgerDb = _burgerRepository.GetAll();
            //mapping the BurgerListViewModel and returning a list of them
            List<BurgerListViewModel> burgerListViews = burgerDb.Select(x => BurgerMapper.BurgerListViewModel(x)).ToList();
            return burgerListViews;
        }

        //burger dropdown
        public List<BurgerToDropdownViewModel> GetAllBurgersForDropdown()
        {
            //calling repository to get burgers from database
            List<Burger> burgerDb = _burgerRepository.GetAll();

            //mapping the BurgerToDropdownViewModel and returing a list of them
            List<BurgerToDropdownViewModel> result = burgerDb.Select(r => BurgerMapper.ToDropdownViewModel(r)).ToList();
            return result;
        }

        //getting burger details
        public BurgerDetailsViewModel BurgerDetails(int id)
        {
            //calling repository to get burger from db
            Burger burgerDb = _burgerRepository.GetById(id);
            //mapping and returning the BurgerDetailsViewModel
            BurgerDetailsViewModel burgerDetailsView = BurgerMapper.BurgerDetailsViewModel(burgerDb);
            return burgerDetailsView;
        }

        //deleting an order by id through repository
        public void DeleteBurger(int id)
        {
            //calling repository to find the Burger with corresponding id
            Burger burgerDb = _burgerRepository.GetById(id);
            //calling repository to delete the entity  from db
            _burgerRepository.Delete(burgerDb);
        }

        //adding a burger
        public void AddBurger(BurgerDetailsViewModel model)
        {
            //adding new burger to DB
            _burgerRepository.Insert(new Burger
            {
                Id = model.Id,
                Name = model.Name,
                Price = model.Price,
                HasFries = model.HasFries,
                IsVegan = model.IsVegan
            });
        }

        //editing a burger
       public Burger EditBurger(int id)
        {
            //getting the burger with corresponding id
            return _burgerRepository.GetById(id);
        }
        public void ConfirmEdit(Burger burgerDb)
        {
            //calling repository to update the entity
            _burgerRepository.Update(burgerDb);
        }
    }
}
