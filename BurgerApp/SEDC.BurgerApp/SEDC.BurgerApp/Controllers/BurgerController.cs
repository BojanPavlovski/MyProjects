using Microsoft.AspNetCore.Mvc;
using SEDC.BurgerApp.Domain.Burgers;
using SEDC.BurgerApp.Services.Interfaces;
using SEDC.BurgerApp.ViewModels.Burgers;

namespace SEDC.BurgerApp.Controllers
{
    public class BurgerController : Controller
    {
        private IBurgerService _burgerService;

        public BurgerController(IBurgerService burgerService)
        {
            _burgerService = burgerService;
        }

        //show all burgers
        public IActionResult Index()
        {
            //calling the burgers service to retrive all the burgers
            List<BurgerListViewModel> burgers = _burgerService.GetAllBurgers();
            return View(burgers);
        }
        
        //Show burger details based on burger id
        public IActionResult Details(int id)
        {
            //calling service
            BurgerDetailsViewModel burgerDetailsView = _burgerService.BurgerDetails(id);

            return View(burgerDetailsView);
        }

        //delete existing burger
        //part 1
        public IActionResult Delete(int id)
        {
            //calling service
            BurgerDetailsViewModel burgerDetailsView = _burgerService.BurgerDetails(id);
            return View(burgerDetailsView);
        }
        //part 2 confirm delete
        public IActionResult ConfirmDelete(Burger burger)
        {
            //calling service
            _burgerService.DeleteBurger(burger.Id);
            //return to all burgers view
            return RedirectToAction("Index");
        }

        //adding a new burger
        //part 1
        public IActionResult AddBurger(int id)
        {
            //send an empty burger and later populate it with data
            BurgerDetailsViewModel burgerDetails = new BurgerDetailsViewModel();
            burgerDetails.Id = id;

            return View(burgerDetails);
        }

        //part 2
        [HttpPost]
        public IActionResult AddNewBurgerPost(BurgerDetailsViewModel model)
        {
            //calling service
            _burgerService.AddBurger(model);
            //return to all burgers view
            return RedirectToAction("Index");
        }

        //editing a burger
        //part 1
        public IActionResult Edit(int id)
        {
            //find burger to edit through id
            //using BurgerDetailsViewModel because of needed properties
            BurgerDetailsViewModel burgerDb = _burgerService.BurgerDetails(id);
            //send burger names in a dropdown via ViewBag
            ViewBag.Burgers = _burgerService.GetAllBurgersForDropdown();
            return View(burgerDb);
        }
        //part 2
        [HttpPost]
        public IActionResult ConfirmEdit(BurgerDetailsViewModel model)
        {
            //find burger based on id
            Burger burgerDb = _burgerService.EditBurger(model.Id);
            //adjusting data
            burgerDb.Name = model.Name;
            burgerDb.Price = model.Price;
            burgerDb.IsVegan = model.IsVegan;
            burgerDb.HasFries = model.HasFries;
            //updating with new data
            _burgerService.ConfirmEdit(burgerDb);
            //return to all burgers view
            return RedirectToAction("Index");
        }
    }
}
