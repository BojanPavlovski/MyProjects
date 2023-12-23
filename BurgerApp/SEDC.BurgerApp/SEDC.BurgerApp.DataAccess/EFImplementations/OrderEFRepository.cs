using Microsoft.EntityFrameworkCore;
using SEDC.BurgerApp.DataAccess.Interfaces;
using SEDC.BurgerApp.Domain.Orders;

namespace SEDC.BurgerApp.DataAccess.EFImplementations
{
    public class OrderEFRepository : IRepository<Order>
    {
        private BurgerAppDbContext _dbContext;

        public OrderEFRepository(BurgerAppDbContext dbContext) //Dependency injection
        {
            _dbContext = dbContext;
        }

        public void Delete(Order entity)
        {
            _dbContext.Orders.Remove(entity);
            _dbContext.SaveChanges();
        }

        public List<Order> GetAll()
        {
            return _dbContext.Orders
                .Include(x => x.Burgers)
                .ThenInclude(x => x.Burger)
                .ToList();
        }

        public Order GetById(int id)
        {
            return _dbContext.Orders
                .Include(x => x.Burgers)
                .ThenInclude(x => x.Burger)
                .FirstOrDefault(x => x.Id == id);
        }

        public void Insert(Order entity)
        {
            _dbContext.Orders.Add(entity);
            _dbContext.SaveChanges();

        }

        public void Update(Order entity)
        {

            _dbContext.Orders.Update(entity);
            _dbContext.SaveChanges();
        }
    }
}
