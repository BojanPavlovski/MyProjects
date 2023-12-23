using SEDC.BurgerApp.Domain.Orders;
using SEDC.BurgerApp.ViewModels.Orders;

namespace SEDC.BurgerApp.Mappers.Orders
{
    public static class OrderMapper
    {
        //mapping from Order to OrderListViewModel
        public static OrderListViewModel OrderListViewModel(Order order)
        {
            var price = CalculateOrderPrice(order);
            return new OrderListViewModel
            {
                Id = order.Id,
                UserFullName = $"{order.FullName}",
                TotalPrice = price
            };
        }

        //mapping from Order to  OrderDetailsViewModel
        public static OrderDetailsViewModel OrderDetailsViewModel(Order order)
        {
            var price = CalculateOrderPrice(order);
            return new OrderDetailsViewModel
            {
                Id = order.Id,
                UserFullName = order.FullName,
                isDelivered = order.IsDelivered,
                BurgerNames = order.Burgers.Select(x => x.Burger.Name).ToList(),
                TotalPrice = price,
                Location = order.Location,
                Address = order.Address
            };

        }

        //method that calculates the order price
        private static int CalculateOrderPrice(Order order)
        {
            var price = 0;
            foreach (BurgerOrder burgerOrder in order.Burgers)
            {
                price += burgerOrder.Burger.Price * burgerOrder.NumberOfBurgers;
            }
            return price;
        }
    }
}
