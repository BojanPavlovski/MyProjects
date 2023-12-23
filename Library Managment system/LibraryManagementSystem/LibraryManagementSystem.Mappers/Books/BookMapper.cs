using LibraryManagementSystem.Domain.Domain;
using LibraryManagementSystem.Dtos.Books;

namespace LibraryManagementSystem.Mappers.Books
{
    public static class BookMapper
    {
        //mapping domain Books entities to BookDto
        public static BookDto ToBookDto(Book book)
        {
            return new BookDto
            {
                Title = book.Title,
                Author = book.Author,
                Year = book.Year
            };
        }
        //mapping from AddBookDto to Book domain entity
        public static Book ToBook(this AddBookDto addBook)
        {
            return new Book
            {
                Title = addBook.Title,
                Author = addBook.Author,
                Year = addBook.Year,
                Genre = addBook.Genre,
                Availability = addBook.Availability
            };
        }
    }
}
