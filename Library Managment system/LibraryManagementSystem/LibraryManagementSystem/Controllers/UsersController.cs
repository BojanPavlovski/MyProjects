using LibraryManagementSystem.Dtos.RentInfo;
using LibraryManagementSystem.Dtos.Users;
using LibraryManagementSystem.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementSystem.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        public UsersController(IUserService userService)
        {
            _userService = userService;
        }
        //a method that gets all users ,making a call to the User service
        [HttpGet]
        public ActionResult<List<UserDto>> GetAllUsers()
        {
            try
            {
                return Ok(_userService.GetAllUsers());
            }
            catch
            {
                return BadRequest();
            }
        }
        //a method that adds a User, making a call to the User service
        [HttpPost]
        public IActionResult AddUser([FromBody] AddUserDto userDto)
        {
            try
            {
                _userService.AddUser(userDto);
                return StatusCode(StatusCodes.Status201Created);

            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred");
            }
        }
        //a method that deletes a User,using it's username
        [HttpDelete("{username}")]
        public IActionResult Delete(string username)
        {
            try
            {
                _userService.DeleteUser(username);
                return StatusCode(StatusCodes.Status204NoContent, "Deleted resource");
            }
            catch
            {
                return BadRequest();
            }
        }
        //a method that updates user info calling the user service
        [HttpPut("updateUser")]
        public IActionResult UpdateUser([FromBody] UpdateUserDto userDto)
        {
            try
            {
                _userService.Update(userDto);
                return StatusCode(StatusCodes.Status204NoContent, "User updated.");
            }
            catch
            {
                return BadRequest();
            }
        }
        //a method that retrieves a user based on username that makes a call to the user service
        [HttpGet("getUser/{username}")]
        public ActionResult<UserDto> GetUserByUsername(string username)
        {
            try
            {
                return Ok(_userService.GetUserByUsername(username));
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred");
            }
        }

        //a method that adds RentInfo to the User,calling the User service
        [HttpPost("addRentInfo")]
        public IActionResult AddRentInfo([FromBody] AddRentInfoDto rentInfoDto)
        {
            try
            {
                _userService.AddRentInfoForUser(rentInfoDto);
                return StatusCode(StatusCodes.Status201Created);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred!");
            }
        }

    }
}
