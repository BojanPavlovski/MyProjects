namespace LibraryManagementSystem.Dtos.RentInfo
{
    public class AddRentInfoDto
    {
        public string Username { get; set; }
        public string BookTitle { get; set; }
        public int Price { get; set; }
        public DateTime DateOfPickUp => DateTime.Now.ToLocalTime();
        public DateTime DateOfReturn => DateOfPickUp.AddDays(14);
    }
}
