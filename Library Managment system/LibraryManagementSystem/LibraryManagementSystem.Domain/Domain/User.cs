namespace LibraryManagementSystem.Domain.Domain
{
    public class User : BaseEntity
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Address { get; set; }
        public string Phonenumber { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public List<RentInfo> RentInfo { get; set; }
    }
}
