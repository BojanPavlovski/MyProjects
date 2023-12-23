namespace LibraryManagementSystem.Dtos.RentInfo
{
    public class RentInfoDto
    {
        public string Name { get; set; }
        public string Username { get; set; }
        public string BookName { get; set; }
        public int Price { get; set; }
        public DateTime DateOfPickUp { get; set; }
        public DateTime DateOfReturn { get; set; }
    }
}
