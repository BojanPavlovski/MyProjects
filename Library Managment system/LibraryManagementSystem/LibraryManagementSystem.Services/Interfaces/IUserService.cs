using LibraryManagementSystem.Dtos.RentInfo;
using LibraryManagementSystem.Dtos.Users;

namespace LibraryManagementSystem.Services.Interfaces
{
    public interface IUserService
    {
        List<UserDto> GetAllUsers();
        void AddUser(AddUserDto userDto);
        void DeleteUser(string username);
        public void Update(UpdateUserDto entity);
        UserDto GetUserByUsername(string username);
        public void AddRentInfoForUser(AddRentInfoDto rentInfoDto);
    }
}
