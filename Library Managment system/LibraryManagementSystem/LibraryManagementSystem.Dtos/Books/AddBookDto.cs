using LibraryManagementSystem.Domain.Enums;

namespace LibraryManagementSystem.Dtos.Books
{
    public class AddBookDto
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public int Year { get; set; }
        public GenreEnum Genre { get; set; }
        public bool Availability { get; set; }
    }
}
