using LibraryManagementSystem.DataAccess.Interfaces;
using LibraryManagementSystem.Domain.Domain;
using LibraryManagementSystem.Domain.Enums;
using LibraryManagementSystem.Dtos.Books;
using LibraryManagementSystem.Mappers.Books;
using LibraryManagementSystem.Services.Interfaces;

namespace LibraryManagementSystem.Services.Implementations
{
    public class BookService : IBookService
    {
        private IBookRepository _bookRepository;


        public BookService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }
        //a method that adds a Book entity and calling the book repository to do so
        public void AddBook(AddBookDto book)
        {
            //validations
            if (string.IsNullOrEmpty(book.Title))
                throw new Exception("Title is required");
            if (string.IsNullOrEmpty(book.Author))
                throw new Exception("Author is required");
            if (book.Year <= 0)
                throw new Exception("Year is invalid.");
            if (!Enum.IsDefined(typeof(GenreEnum), book.Genre))
                throw new Exception("Genre is invalid");
          
            Book bookName = _bookRepository.GetBookByTitle(book.Title);
            if (bookName == null)
            {
                //if book title does not exist in db, add it to db else throw exception
                Book newBook = book.ToBook();
                _bookRepository.Add(newBook);
            }
            else
            {
                throw new Exception("Such a book already exists.");
            }
        }
        //a method that deletes a Book entity using the provided book title,making a call to the book repository
        public void DeleteBook(string bookTitle)
        {
            //validation
            if (string.IsNullOrEmpty(bookTitle))
                throw new Exception("Book title is invalid.");
            //getting book by title
            var bookDb = _bookRepository.GetBookByTitle(bookTitle);
            if (bookDb == null)
            {
                throw new Exception("Title was not found.");
            }
            //calling repository to delete book entity
            _bookRepository.Delete(bookDb);
        }


        //a method that retrieves all Books in db by making a call to the book repository
        public List<BookDto> GetAllBooks()
        {
            //caling repository to retrive all books from database
            List<Book> bookDb = _bookRepository.GetAll();
            if (bookDb == null)
            {
                throw new Exception("An error ocurred.");
            }
            //mapping 
            List<BookDto> bookDto = bookDb.Select(x => BookMapper.ToBookDto(x)).ToList();
            return bookDto;
        }
        //a method that retrieves a book entity based on provided title by calling the book repository
        public BookDto GetBookByTitle(string title)
        {
            //validation
            if (string.IsNullOrEmpty(title) || title.Length == 0)
            {
                throw new Exception("Title can not be empty!Enter a value to search again.");
            }
            //get book entity
            var book = _bookRepository.GetBookByTitle(title);
            if (book == null)
            {
                throw new Exception("Such a title was not found.");
            }
            //mapping
            return BookMapper.ToBookDto(book);

        }
        //a method that calls the book repository to update the Book entity stored in db
        public void UpdateBook(UpdateBookDto updateBookDto)
        {
            //validation
            if (string.IsNullOrEmpty(updateBookDto.Title))
                throw new Exception("Title must be valid.");
            if (string.IsNullOrEmpty(updateBookDto.Author))
                throw new Exception("Author must be valid.");
            if (updateBookDto.Year <= 0)
                throw new Exception("Year is invalid.");
            if (!Enum.IsDefined(typeof(GenreEnum), updateBookDto.Genre))
                throw new Exception("Genre is invalid");
            //get book to update
            var bookDb = _bookRepository.GetBookByTitle(updateBookDto.Title);
            if (bookDb == null)
                throw new Exception("Such a book does not exist.");
            //mapping
            bookDb.Author = updateBookDto.Author;
            bookDb.Year = updateBookDto.Year;
            bookDb.Genre = updateBookDto.Genre;
            bookDb.Title = updateBookDto.Title;
            bookDb.Availability = updateBookDto.Availability;
            //calling repo
            _bookRepository.Update(bookDb);
        }
    }
}
