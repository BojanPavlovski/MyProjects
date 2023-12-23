using SEDC.BurgerApp.DataAccess.Interfaces;
using SEDC.BurgerApp.Domain.Burgers;

namespace SEDC.BurgerApp.DataAccess.EFImplementations
{
    public class BurgerEFRepository : IRepository<Burger>
    {
        private BurgerAppDbContext _dbContext;

        public BurgerEFRepository(BurgerAppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Delete(Burger entity)
        {
            _dbContext.Burgers.Remove(entity);
            _dbContext.SaveChanges();
        }

        public List<Burger> GetAll()
        {
            return _dbContext.Burgers.ToList();
        }

        public Burger GetById(int id)
        {
            return _dbContext.Burgers.FirstOrDefault(x => x.Id == id);
        }

        public void Insert(Burger entity)
        {
            _dbContext.Burgers.Add(entity);
            _dbContext.SaveChanges();
        }

        public void Update(Burger entity)
        {
            _dbContext.Burgers.Update(entity);
            _dbContext.SaveChanges();
        }
    }
}
