using LibraryManagementSystem.Domain.Domain;

namespace LibraryManagementSystem.DataAccess.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
        User GetUserByUsername(string username);

    }
}
