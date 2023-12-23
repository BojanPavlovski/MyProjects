namespace LibraryManagementSystem.Domain.Domain
{
    public class RentInfo : BaseEntity
    {
        public User User { get; set; }
        public int UserId { get; set; }
        public Book Book { get; set; }
        public string BookTitle { get; set; }
        public int BookId { get; set; }
        public int Price { get; set; }
        public DateTime DateOfPickUp { get; set; }
        public DateTime DateOfReturn { get; set; }
    }
}
