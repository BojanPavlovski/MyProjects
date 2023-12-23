using LibraryManagementSystem.DataAccess.Interfaces;
using LibraryManagementSystem.Domain.Domain;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementSystem.DataAccess.Implementations
{
    public class UserRepository : IUserRepository
    {
        private LibraryManagementSystemDbContext _dbContext;

        public UserRepository(LibraryManagementSystemDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        //making a call to the database to add User entity 
        public void Add(User entity)
        {
            _dbContext.Add(entity);
            _dbContext.SaveChanges();
        }
        //making a call to Db to delete a User entity
        public void Delete(User entity)
        {
            _dbContext.Users.Remove(entity);
            _dbContext.SaveChanges();
        }
        //making a call to db to retrieve all Users stored in database
        public List<User> GetAll()
        {
            return _dbContext.Users.Include(x => x.RentInfo).ThenInclude(x => x.Book).OrderBy(x => x.Lastname).ToList();
        }

        //making a call to db to get User entity based on provided Id
        public User GetById(int id)
        {
            return _dbContext.Users.SingleOrDefault(x => x.Id == id);
        }

        //making a call to the database to retrieve a User entity based on username
        public User GetUserByUsername(string username)
        {
            return _dbContext.Users.Include(x => x.RentInfo).ThenInclude(x => x.Book).FirstOrDefault(x => x.UserName == username);
        }
        //making a call to the db to update User entity
        public void Update(User entity)
        {
            _dbContext.Users.Update(entity);
            _dbContext.SaveChanges();
        }

    }
}
