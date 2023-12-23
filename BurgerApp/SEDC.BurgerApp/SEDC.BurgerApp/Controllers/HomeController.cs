using Microsoft.AspNetCore.Mvc;
using SEDC.BurgerApp.Models;
using SEDC.BurgerApp.Services.Interfaces;
using SEDC.BurgerApp.ViewModels;
using System.Diagnostics;

namespace SEDC.BurgerApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IOrderService _orderService;
        private readonly IBurgerService _burgerService;

        public HomeController(ILogger<HomeController> logger, IOrderService orderService, IBurgerService burgerService)
        {
            _logger = logger;
            _orderService = orderService;
            _burgerService = burgerService;
        }

        public IActionResult Index()
        {
            //calculating total number of orders in the system
            int totalNumberOfOrders = _orderService.GetAllOrders().Count;
            //calculating avergae price of orders in the system
            int averagePrice = (int)(_orderService.GetAllOrders().Any() ? _orderService.GetAllOrders().Average(o => o.TotalPrice) : 0);
            //setting variables as properties to the new HomeIndexViewModel and sending it to the View();
            HomeIndexViewModel homeIndex = new HomeIndexViewModel
            {
                NumberOfOrders = totalNumberOfOrders,
                AverageOrderPrice = averagePrice
                
        };
            return View(homeIndex);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}