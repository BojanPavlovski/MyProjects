using SEDC.BurgerApp.Domain.Orders;
using SEDC.BurgerApp.ViewModels.Orders;


namespace SEDC.BurgerApp.Services.Interfaces
{
    public interface IOrderService
    {
        List<OrderListViewModel> GetAllOrders();
        OrderDetailsViewModel OrderDetails(int id);
        public void CreateOrder(OrderDetailsViewModel model);
        void AddBurgerToOrder(AddBurgerViewModel model);
        public void DeleteOrder(int id);
        public Order EditDetails(int id);
        public void ConfirmEdit(Order model);

    }
}
