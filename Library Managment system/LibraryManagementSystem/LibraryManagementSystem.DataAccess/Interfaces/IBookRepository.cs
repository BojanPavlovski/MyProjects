using LibraryManagementSystem.Domain.Domain;

namespace LibraryManagementSystem.DataAccess.Interfaces
{
    public interface IBookRepository : IRepository<Book>
    {
        Book GetBookByTitle(string title);

    }
}
