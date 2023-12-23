using LibraryManagementSystem.Dtos.Admins;
using LibraryManagementSystem.Dtos.Users;
using LibraryManagementSystem.Services.Interfaces;
using LibraryManagementSystem.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IAdminService _adminService;
        public AdminController(IAdminService adminService)
        {
            _adminService = adminService;
        }
        //a login method for Admin that makes a call to the admin service
        [AllowAnonymous]
        [HttpPost("login")]
        public ActionResult<string> LogIn([FromBody] LogInDto model)
        {
            try
            {
                string token = _adminService.Login(model);
                return Ok(token);
            }
            catch (UserException ex)
            {
                return BadRequest(ex.Message);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred!");
            }
        }
        //a register method for Admin that makes a call to the admin service
        [AllowAnonymous]
        [HttpPost("registerAdmin")]
        public IActionResult RegisterAdmin([FromBody] AddAdminDto model)
        {
            try
            {
                _adminService.Register(model);
                return Ok();
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred!");
            }
        }
    }
}
