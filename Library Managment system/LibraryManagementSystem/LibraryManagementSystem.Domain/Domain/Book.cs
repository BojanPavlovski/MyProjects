using LibraryManagementSystem.Domain.Enums;

namespace LibraryManagementSystem.Domain.Domain
{
    public class Book : BaseEntity
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public int Year { get; set; }
        public GenreEnum Genre { get; set; }
        public bool Availability { get; set; }
        public List<RentInfo>? RentInfo { get; set; }
    }
}
