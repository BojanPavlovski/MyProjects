using LibraryManagementSystem.Domain.Domain;

namespace LibraryManagementSystem.DataAccess.Interfaces
{
    public interface IRentInfoRepository : IRepository<RentInfo>
    {
        List<RentInfo> GetAllRentInfoByUsername(string username);
        RentInfo GetRentInfoByUsernameAndBookTitle(string username, string booktitle);
    }
}
