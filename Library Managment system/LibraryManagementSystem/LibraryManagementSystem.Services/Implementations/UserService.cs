using LibraryManagementSystem.DataAccess.Interfaces;
using LibraryManagementSystem.Domain.Domain;
using LibraryManagementSystem.Dtos.RentInfo;
using LibraryManagementSystem.Dtos.Users;
using LibraryManagementSystem.Mappers.Users;
using LibraryManagementSystem.Services.Interfaces;
using LibraryManagementSystem.Shared;

namespace LibraryManagementSystem.Services.Implementations
{
    public class UserService : IUserService
    {
        private IUserRepository _userRepository;
        private IBookRepository _bookRepository;

        public UserService(IUserRepository userRepository, IBookRepository bookRepository)
        {
            _userRepository = userRepository;
            _bookRepository = bookRepository;
        }
        //a method that adds a User to db by calling repository
        public void AddUser(AddUserDto userDto)
        {
            //validation
            if (string.IsNullOrEmpty(userDto.Firstname))
                throw new Exception("First name must be valid.");
            if (string.IsNullOrEmpty(userDto.Lastname))
                throw new Exception("Last name must be valid.");
            if (string.IsNullOrEmpty(userDto.Address))
                throw new Exception("Address must be valid.");
            if (string.IsNullOrEmpty(userDto.Phonenumber))
                throw new Exception("Phone number must be valid.");
            if (string.IsNullOrEmpty(userDto.Email))
                throw new Exception("Email must be valid.");
            if (string.IsNullOrEmpty(userDto.UserName))
                throw new Exception("Username must be valid.");
            //retrieving domain entity from db
            User user = _userRepository.GetUserByUsername(userDto.UserName);
            if (user == null)
            {
                //mapping
                User userDb = UserMapper.ToUser(userDto);
                //calling repositoty to add entity
                _userRepository.Add(userDb);
            }
            else
            {
                throw new Exception("Such a username already exists.Pick a diferent one.");
            }
        }
        //a method that calls repository to delete User from db
        public void DeleteUser(string username)
        {
            //validation
            if (string.IsNullOrEmpty(username))
                throw new Exception("Username is invalid.");
            //retrieving domain entity
            User user = _userRepository.GetUserByUsername(username);

            if (user == null)
                throw new Exception("User was not found.");
            //calling repo to delete entity
            _userRepository.Delete(user);
        }
        //a method that calls repo to get all Users from db
        public List<UserDto> GetAllUsers()
        {
            //retrieving all domain Users from db
            List<User> userDb = _userRepository.GetAll();
            //validate
            if (userDb == null)
                throw new Exception("An error occured.");
            //mapping and returning
            List<UserDto> userDto = userDb.Select(x => UserMapper.ToUserDto(x)).ToList();
            return userDto;
        }
        //a method that returns a user based on provided username
        public UserDto GetUserByUsername(string username)
        {
            //validation
            if (string.IsNullOrEmpty(username))
                throw new Exception("Username must be valid.");
            //getting domain entity from db
            var user = _userRepository.GetUserByUsername(username);
            if (user == null)
            {
                throw new Exception("User does not exist.");
            }
            //mapping and returning
            return UserMapper.ToUserDto(user);
        }

        //a method that calls repository to Update entity 
        public void Update(UpdateUserDto entity)
        {
            //vaidation
            if (string.IsNullOrEmpty(entity.Firstname))
                throw new Exception("First name must be valid.");
            if (string.IsNullOrEmpty(entity.Lastname))
                throw new Exception("Last name must be valid.");
            if (string.IsNullOrEmpty(entity.Address))
                throw new Exception("Address must be valid.");
            if (string.IsNullOrEmpty(entity.Phonenumber))
                throw new Exception("Phone number must be valid.");
            if (string.IsNullOrEmpty(entity.Email))
                throw new Exception("Email must be valid.");
            if (string.IsNullOrEmpty(entity.Username))
                throw new Exception("Username must be valid.");
            //find user to update by username
            var userDb = _userRepository.GetUserByUsername(entity.Username);
            if (userDb == null)
                throw new Exception("Such a user could not be found.");

            //mapping
            userDb.Firstname = entity.Firstname;
            userDb.Lastname = entity.Lastname;
            userDb.Address = entity.Address;
            userDb.Email = entity.Email;
            userDb.Phonenumber = entity.Phonenumber;
            //calling repo to update entity
            _userRepository.Update(userDb);
        }
          //a method that adds RentInfo for user
        public void AddRentInfoForUser(AddRentInfoDto rentInfoDto)
        {
            //finding user to add rentInfo for
            User user = _userRepository.GetUserByUsername(rentInfoDto.Username);
            //validate
            if (user == null)
                throw new Exception("User can not be found.");
            //finding book to add to the RentInfo entity by book title
            Book book = _bookRepository.GetBookByTitle(rentInfoDto.BookTitle);
            if (book == null)
                throw new Exception($"Book with title: {rentInfoDto.BookTitle} can not be found.");
            //adding rentInfo for user
            user.RentInfo.Add(new RentInfo
            {
                BookTitle = rentInfoDto.BookTitle,
                BookId = book.Id,
                Price = rentInfoDto.Price,
                DateOfPickUp = rentInfoDto.DateOfPickUp,
                DateOfReturn = rentInfoDto.DateOfReturn,
                UserId = user.Id,
                User = user,
                Book = book
            });
            //calling repository to update User
            _userRepository.Update(user);

        }
    }
}
