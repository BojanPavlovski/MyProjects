using LibraryManagementSystem.DataAccess.Interfaces;
using LibraryManagementSystem.Domain.Domain;
using LibraryManagementSystem.Dtos.RentInfo;
using LibraryManagementSystem.Mappers.RentInfos;
using LibraryManagementSystem.Services.Interfaces;

namespace LibraryManagementSystem.Services.Implementations
{
    public class RentInfoService : IRentInfoService
    {
        private IRentInfoRepository _rentInfoRepository;


        public RentInfoService(IRentInfoRepository rentInfoRepository)
        {
            _rentInfoRepository = rentInfoRepository;
        }
        //a method that calls rentInfo repository to delete entity
        public void Delete(string username, string booktitle)
        {
            //validation
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(booktitle))
                throw new Exception("Username or booktitle are invalid.");
            //get entity to delete
            RentInfo rentInfo = _rentInfoRepository.GetRentInfoByUsernameAndBookTitle(username, booktitle);
            if (rentInfo == null)
                throw new Exception("Rent information was not found.");
            //calling repo to delete entity
            _rentInfoRepository.Delete(rentInfo);
        }
        //a method that retrieves all rentInfo from db by calling repository
        public List<RentInfoDto> GetAll()
        {
            //caling db to get all domain entities stored in db
            List<RentInfo> rentInfoDb = _rentInfoRepository.GetAll();
            if (rentInfoDb == null)
                throw new Exception("An error occured.");
            //mapping
            List<RentInfoDto> rentInfoDtos = rentInfoDb.Select(x => RentInfoMapper.ToRentInfoDto(x)).ToList();
            return rentInfoDtos;

        }
        //a method that retrieves rentInfo based on provided username and booktitle
        public RentInfoDto GetRendInfoByUsernameAndBooktitle(string username, string booktitle)
        {
            //getting all domain entities from database
            RentInfo rentInfo = _rentInfoRepository.GetRentInfoByUsernameAndBookTitle(username, booktitle);
            //validation
            if (rentInfo == null)
            {
                throw new Exception("Rent info does not exists.");
            }
            //map and return
            return RentInfoMapper.ToRentInfoDto(rentInfo);
        }
        //a mehod that retrieves rentInfo based on provided username
        public List<RentInfoDto> GetRentInfoByUsername(string username)
        {
            //validation
            if (string.IsNullOrEmpty(username))
                throw new Exception("Username must be valid.Enter a value!");
            //get domain entity
            List<RentInfo> rentInfoDb = _rentInfoRepository.GetAllRentInfoByUsername(username);
            if (rentInfoDb == null)
            {
                throw new Exception("An error occured.");
            }
            //mapping and returning
            List<RentInfoDto> rentInfoDtos = rentInfoDb.Select(x => RentInfoMapper.ToRentInfoDto(x)).ToList();
            return rentInfoDtos;
        }
    }
}
