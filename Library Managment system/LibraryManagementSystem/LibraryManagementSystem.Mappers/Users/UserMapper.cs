using LibraryManagementSystem.Domain.Domain;
using LibraryManagementSystem.Dtos.Users;

namespace LibraryManagementSystem.Mappers.Users
{
    public static class UserMapper
    {
        //mapping from domain User entity to UserDto, using this method as an extension method
        public static UserDto ToUserDto(this User user)
        {
            return new UserDto
            {
                FirstName = user.Firstname,
                LastName = user.Lastname,
                Address = user.Address,
                Phonenumber = user.Phonenumber,
                Email = user.Email,
                UserName = user.UserName,
                RentedBooks = user.RentInfo.Select(x => x.Book.Title).ToList()
            };
        }
        //mapping from AddUserDto to User entity, using this method as an extension method
        public static User ToUser(this AddUserDto newUser)
        {
            return new User
            {
                Firstname = newUser.Firstname,
                Lastname = newUser.Lastname,
                Address = newUser.Address,
                Email = newUser.Email,
                UserName = newUser.UserName,
                Phonenumber = newUser.Phonenumber
            };
        }

    }
}
