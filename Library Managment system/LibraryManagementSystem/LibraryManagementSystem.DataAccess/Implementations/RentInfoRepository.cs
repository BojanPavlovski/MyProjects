using LibraryManagementSystem.DataAccess.Interfaces;
using LibraryManagementSystem.Domain.Domain;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementSystem.DataAccess.Implementations
{

    public class RentInfoRepository : IRentInfoRepository
    {
        private LibraryManagementSystemDbContext _dbContext;

        public RentInfoRepository(LibraryManagementSystemDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        //making a call to the Database to add RentInfo entity
        public void Add(RentInfo entity)
        {
            _dbContext.Add(entity);
            _dbContext.SaveChanges();
        }
        //making a call to the database to delete a RentInfo entity
        public void Delete(RentInfo entity)
        {
            _dbContext.RentInfo.Remove(entity);
            _dbContext.SaveChanges();
        }
        //making a call to the database to get all RentInfo entites stored in db
        public List<RentInfo> GetAll()
        {
            return _dbContext.RentInfo.Include(x => x.User).Include(x => x.Book).ToList();

        }
        //making a call to the database to get RentInfo entity based on provided username
        public List<RentInfo> GetAllRentInfoByUsername(string username)
        {
            return _dbContext.RentInfo.Include(x => x.Book).Include(x => x.User).Where(x => x.User.UserName == username).ToList();
        }
        //making a call to the database to retrieve RentInfo entity based on provided Id
        public RentInfo GetById(int id)
        {
            return _dbContext.RentInfo.SingleOrDefault(x => x.Id == id);
        }
        //making a call to Db to get RentInfo entity based on provided username nad string
        public RentInfo GetRentInfoByUsernameAndBookTitle(string username, string booktitle)
        {
            return _dbContext.RentInfo.Include(x => x.User).Include(x => x.Book).Where(x => x.User.UserName == username && x.Book.Title == booktitle).FirstOrDefault();

        }
        //making a call to the database to update RentInfo entity
        public void Update(RentInfo entity)
        {
            _dbContext.RentInfo.Update(entity);
            _dbContext.SaveChanges();
        }
    }
}
