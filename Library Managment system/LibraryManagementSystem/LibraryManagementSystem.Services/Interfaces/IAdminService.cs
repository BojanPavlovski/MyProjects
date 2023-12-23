using LibraryManagementSystem.Dtos.Admins;
using LibraryManagementSystem.Dtos.Users;

namespace LibraryManagementSystem.Services.Interfaces
{
    public interface IAdminService
    {
        public AdminDto Authenticate(LogInDto model);
        public void Register(AddAdminDto model);
        public string Login(LogInDto logInDto);
    }
    
}
