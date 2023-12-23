using SEDC.BurgerApp.DataAccess.Interfaces;
using SEDC.BurgerApp.Domain.Orders;


namespace SEDC.BurgerApp.DataAccess.Implementations
{
    public class OrderRepository : IRepository<Order>
    {
        public void Delete(Order order)
        {
            Order orderDb = GetById(order.Id);
            StaticDb.Orders.Remove(orderDb);
        }

        public List<Order> GetAll()
        {
            return StaticDb.Orders;
        }

        public Order GetById(int id)
        {
            return StaticDb.Orders.FirstOrDefault(x => x.Id == id);
        }

        public void Insert(Order entity)
        {
            entity.Id = StaticDb.Orders.Count + 1;
            StaticDb.Orders.Add(entity);
        }

        public void Update(Order entity)
        {
            Order orderDb = StaticDb.Orders.FirstOrDefault(x => x.Id == entity.Id);
            int index = StaticDb.Orders.IndexOf(orderDb);
            StaticDb.Orders[index] = entity;
        }
    }
}
