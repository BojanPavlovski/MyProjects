using LibraryManagementSystem.Dtos.RentInfo;

namespace LibraryManagementSystem.Services.Interfaces
{
    public interface IRentInfoService
    {
        List<RentInfoDto> GetAll();
        List<RentInfoDto> GetRentInfoByUsername(string username);
        void Delete(string username, string booktitle);
        RentInfoDto GetRendInfoByUsernameAndBooktitle(string username, string booktitle);
    }
}
