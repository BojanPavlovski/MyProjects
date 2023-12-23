using Microsoft.AspNetCore.Mvc;
using SEDC.BurgerApp.Domain.Orders;
using SEDC.BurgerApp.Services.Interfaces;
using SEDC.BurgerApp.ViewModels.Orders;


namespace SEDC.BurgerApp.Controllers
{
    public class OrderController : Controller
    {
        private IOrderService _orderService;
        private IBurgerService _burgerService;
        public OrderController(IOrderService orderService, IBurgerService burgerService)
        {
            _orderService = orderService;
            _burgerService = burgerService;
        }


        //Get all orders
        public IActionResult Index()
        {
            //calling service to retrive all orders from db
            List<OrderListViewModel> orders = _orderService.GetAllOrders();
            return View(orders);
        }

        //Getting Order details
        public IActionResult Details(int id)
        {
            if (id <= 0)
            {
                throw new Exception($"The id: {id} is not valid.");
            }
            //sending a mapped view model to the View folowing the implementation of _orderService.OrderDetails(id)
            OrderDetailsViewModel orderDetailsViewModel = _orderService.OrderDetails(id);
            //returning view with OrderDetailsViewModel
            return View(orderDetailsViewModel);
        }

        //creating an order 
        //step 1
        public IActionResult CreateOrder(int id)
        {
            //sending an empty OrderDetailsViewModel so later it can be populated with new data
            OrderDetailsViewModel orderDetails = new OrderDetailsViewModel();
            orderDetails.Id = id;
            //sending data to the View with ViewBag
            ViewBag.Burgers = _burgerService.GetAllBurgersForDropdown();
            //returning view with OrderDetailsViewModel
            return View(orderDetails);
        }
        //step 2
        [HttpPost]
        public IActionResult CreateOrderPost(OrderDetailsViewModel model)
        {
            //calling service to create a new order  
            _orderService.CreateOrder(model);
            //return to all orders view
            return RedirectToAction("Index");
        }

        //adding a burger
        //step 1
        public IActionResult AddBurger(int id)
        {
            //sending an empty form so that later it can be populated with data
            AddBurgerViewModel addBurgerViewModel = new AddBurgerViewModel();
            addBurgerViewModel.OrderId = id;

            //sending burgers from database and sending them for dropdown via VewBag
            ViewBag.Burgers = _burgerService.GetAllBurgersForDropdown();
            //returning view with AddBurgerViewModel
            return View(addBurgerViewModel);
        }

        //step 2
        [HttpPost]
        public IActionResult AddBurgerPost(AddBurgerViewModel model)
        {
            //calling service to add a burger to the order
            _orderService.AddBurgerToOrder(model);
            //return to order details view
            return RedirectToAction("Details", new { id = model.OrderId });
        }

        //deleting ,step 1
        public IActionResult Delete(int id)
        {
            //calling service to find,map and return the OrderDetailsViewModel with given id
            OrderDetailsViewModel orderDetailsViewModel = _orderService.OrderDetails(id);
            //returning it to the view
            return View(orderDetailsViewModel);
        }

        //step 2
        public IActionResult ConfirmDelete(Order order)
        {
            //calling service to delete the order
            _orderService.DeleteOrder(order.Id);
            //returning to all orders view
            return RedirectToAction("Index");

        }

        //editing an order
        //part 1
        public IActionResult EditOrder(int id)
        {
            //find order to edit with id
            //use OrderDetailsViewModel because of needed properties
            OrderDetailsViewModel orderDetails = _orderService.OrderDetails(id);

            //send burger names for dropdown via ViewBag
            ViewBag.Burgers = _burgerService.GetAllBurgersForDropdown();
            //returing OrderDetialsViewModel to the View
            return View(orderDetails);
        }
        //part 2
        [HttpPost]
        public IActionResult EditOrderPost(OrderDetailsViewModel model)
        {
            //calling service to find the entity to be deleted
            Order orderDb = _orderService.EditDetails(model.Id);
            //adjust data
            orderDb.Id = model.Id;
            orderDb.FullName = model.UserFullName;
            orderDb.IsDelivered = model.isDelivered;
            orderDb.Location = model.Location;
            model.BurgerNames = orderDb.Burgers.Select(x => x.Burger.Name).ToList();
            //calling service to find and update the entity
            _orderService.ConfirmEdit(orderDb);
            //returing to all orders view
            return RedirectToAction("Index");
        }


    }
}
