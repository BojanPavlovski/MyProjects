using LibraryManagementSystem.Dtos.Books;

namespace LibraryManagementSystem.Services.Interfaces
{
    public interface IBookService
    {
        public List<BookDto> GetAllBooks();
        void AddBook(AddBookDto book);
        void DeleteBook(string bookTitle);
        void UpdateBook(UpdateBookDto updateBookDto);
        BookDto GetBookByTitle(string title);

    }
}
