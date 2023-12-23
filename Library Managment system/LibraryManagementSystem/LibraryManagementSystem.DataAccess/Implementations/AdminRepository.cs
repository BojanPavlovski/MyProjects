using LibraryManagementSystem.DataAccess.Interfaces;
using LibraryManagementSystem.Domain.Domain;

namespace LibraryManagementSystem.DataAccess.Implementations
{
    public class AdminRepository : IAdminRepository
    {
        private LibraryManagementSystemDbContext _dbContext;

        public AdminRepository(LibraryManagementSystemDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        //making a call to the database to add Admin(register admin)
        public void Add(Admin entity)
        {
            _dbContext.Add(entity);
            _dbContext.SaveChanges();
        }
        //making a call to the database to retrive Admins
        public List<Admin> GetAdmin()
        {
            return _dbContext.Admins.ToList();
        }

    }
}
