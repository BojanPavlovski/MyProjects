namespace LibraryManagementSystem.Dtos.Users
{
    public class UserDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string Phonenumber { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public List<string>? RentedBooks { get; set; }
    }
}
