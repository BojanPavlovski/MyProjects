using SEDC.BurgerApp.DataAccess.Interfaces;
using SEDC.BurgerApp.Domain.Burgers;

namespace SEDC.BurgerApp.DataAccess.Implementations
{
    public class BurgerRepository : IRepository<Burger>
    {
        public void Delete(Burger burger)
        {
            Burger burgerDb = GetById(burger.Id);
            StaticDb.Burgers.Remove(burgerDb);
        }

        public List<Burger> GetAll()
        {
            return StaticDb.Burgers;
        }

        public Burger GetById(int id)
        {
            return StaticDb.Burgers.FirstOrDefault(x => x.Id == id);
        }


        public void Insert(Burger entity)
        {
            entity.Id = StaticDb.Burgers.Count + 1;
            StaticDb.Burgers.Add(entity);
        }

        public void Update(Burger entity)
        {
            Burger burgerDb = StaticDb.Burgers.FirstOrDefault(x => x.Id == entity.Id);
            int index = StaticDb.Burgers.IndexOf(burgerDb);
            StaticDb.Burgers[index] = entity;
        }
    }
}
