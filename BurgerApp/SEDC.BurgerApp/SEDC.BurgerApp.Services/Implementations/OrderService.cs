using SEDC.BurgerApp.DataAccess.Interfaces;
using SEDC.BurgerApp.Domain.Burgers;
using SEDC.BurgerApp.Domain.Orders;
using SEDC.BurgerApp.Mappers.Orders;
using SEDC.BurgerApp.Services.Interfaces;
using SEDC.BurgerApp.ViewModels.Orders;


namespace SEDC.BurgerApp.Services.Implementations
{
    public class OrderService : IOrderService
    {
        private IRepository<Order> _orderRepository;
        private IRepository<Burger> _burgerRepository;
        
        public OrderService(IRepository<Order> orderRepository, IRepository<Burger> burgerRepository)
        {
            _burgerRepository = burgerRepository;
            _orderRepository = orderRepository;
        }

        //adding a burger to order
        public void AddBurgerToOrder(AddBurgerViewModel model)
        {
            //calling repository to find orderDb and burgerDb from DB
            Order orderDb = _orderRepository.GetById(model.OrderId);
            Burger burgerDb = _burgerRepository.GetById(model.BurgerId);

            //adding burger to the order
            orderDb.Burgers.Add(new BurgerOrder
            {
                OrderId = model.OrderId,
                Order = orderDb,
                BurgerId = model.BurgerId,
                Burger = burgerDb,
                NumberOfBurgers = model.NumberOfBurgers
            });
            //calling repo to update entity
            _orderRepository.Update(orderDb);
        }

        //creating an order
        public void CreateOrder(OrderDetailsViewModel model)
        {
            //calling repo to insert a new Order
            _orderRepository.Insert(new Order
            {
                Id = model.Id,
                FullName = model.UserFullName,
                Address = model.Location,
                IsDelivered = model.isDelivered,
                Location = model.Location
                
                
            });
        }

        //get all orders
        public List<OrderListViewModel> GetAllOrders()
        {
            //calling repository to get all orders and return them in a list
            List<Order> orderDb = _orderRepository.GetAll();
            //mapping OrderListViewModel and returning it
            List<OrderListViewModel> orderListViewModel = orderDb.Select(x => OrderMapper.OrderListViewModel(x)).ToList();
            return orderListViewModel;
        }

        //get order details
        public OrderDetailsViewModel OrderDetails(int id)
        {
            //finding order in db with given id
            Order orderDb = _orderRepository.GetById(id);
            if(orderDb == null)
            {
                throw new Exception($"Order with {id} was not found.");
            }
            //mapping
            OrderDetailsViewModel orderDetailsViewModel = OrderMapper.OrderDetailsViewModel(orderDb);
            return orderDetailsViewModel;
        }

        //deleting order through repository
        public void DeleteOrder(int id)
        {
            //calling repo to find and return entity with corresponding id
            Order orderDb = _orderRepository.GetById(id);
            //calling repo to delete entity
            _orderRepository.Delete(orderDb);
            
        }

        //find order 
        public Order EditDetails(int id)
        {
            //calling repo to get entity id
            return _orderRepository.GetById(id);
        }
        
        //confirm edit
        public void ConfirmEdit(Order model)
        {
            //caling repo to geet entity by id
            Order orderDb = _orderRepository.GetById(model.Id);
            //calling repo to update entity
            _orderRepository.Update(orderDb);
        }
    }
}
