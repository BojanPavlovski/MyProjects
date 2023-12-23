using LibraryManagementSystem.Domain.Domain;
using LibraryManagementSystem.Dtos.RentInfo;

namespace LibraryManagementSystem.Mappers.RentInfos
{
    public static class RentInfoMapper
    {
        //mapping from domain RentInfo entity to RentInfoDto
        public static RentInfoDto ToRentInfoDto(RentInfo rentInfo)
        {
            return new RentInfoDto
            {
                Username = rentInfo.User.UserName,
                Name = rentInfo.User.Firstname + ' ' + rentInfo.User.Lastname,
                Price = rentInfo.Price,
                DateOfPickUp = rentInfo.DateOfPickUp,
                DateOfReturn = rentInfo.DateOfReturn,
                BookName = rentInfo.Book.Title
            };
        }

    }
}
