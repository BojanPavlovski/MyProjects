using LibraryManagementSystem.DataAccess.Interfaces;
using LibraryManagementSystem.Domain.Domain;

namespace LibraryManagementSystem.DataAccess.Implementations
{
    public class BookRepository : IBookRepository
    {
        private LibraryManagementSystemDbContext _dbContext;

        public BookRepository(LibraryManagementSystemDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        //making a call to the database to delete a book
        public void Delete(Book entity)
        {
            _dbContext.Books.Remove(entity);
            _dbContext.SaveChanges();
        }
        //making a call to retrieve all Books stored in the database
        public List<Book> GetAll()
        {
            return _dbContext.Books.ToList();
        }
        //making a call the database to retrieve a book based on provided Id
        public Book GetById(int id)
        {
            return _dbContext.Books.SingleOrDefault(x => x.Id == id);
        }
        //making a call to the Database to add a book
        public void Add(Book entity)
        {
            _dbContext.Add(entity);
            _dbContext.SaveChanges();
        }
        //making a call to the database to update book entity
        public void Update(Book entity)
        {
            _dbContext.Books.Update(entity);
            _dbContext.SaveChanges();
        }
        //making a call to the database to retrieve book entity based on provided book title
        public Book GetBookByTitle(string title)
        {
            Book bookDb = _dbContext.Books.FirstOrDefault(x => x.Title.Contains(title));
            return bookDb;
        }
    }
}
