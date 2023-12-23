using LibraryManagementSystem.Dtos.RentInfo;
using LibraryManagementSystem.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementSystem.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class RentInfoController : ControllerBase
    {
        private IRentInfoService _rentInfoService;
        public RentInfoController(IRentInfoService rentInfoService)
        {
            _rentInfoService = rentInfoService;
        }
        //a method that gets all rentInfo from Db ,making a call to the rentInfo Service
        [HttpGet]
        public ActionResult<List<RentInfoDto>> GetAllRentInfo()
        {
            try
            {
                return Ok(_rentInfoService.GetAll());
            }
            catch
            {
                return BadRequest();
            }
        }
        //a method that retrieves a rentInfo using a username
        [HttpGet("getByUsername/{username}")]
        public ActionResult<List<RentInfoDto>> GetRentInfoByUsername(string username)
        {
            try
            {
                return Ok(_rentInfoService.GetRentInfoByUsername(username));
            }
            catch
            {
                return BadRequest();
            }
        }
        //a method that gets rentInfo by username and book title
        [HttpGet("getRentInfoByUsernameAndBookTitle/{username}/{booktitle}")]
        public ActionResult<RentInfoDto> GetRentInfoByUsernameAndBooktitle(string username, string booktitle)
        {
            try
            {
                return Ok(_rentInfoService.GetRendInfoByUsernameAndBooktitle(username, booktitle));
            }
            catch
            {
                return BadRequest();
            }
        }

        //a method that deletes rentInfo based on username and book title
        //because they are unique identifiers for  rentInfo since we don't want
        //to show Id in the client side
        [HttpDelete("deleteRentInfoByUsernameAndBooktitle/{username}/{booktitle}")]
        public IActionResult Delete(string username, string booktitle)
        {
            try
            {
                _rentInfoService.Delete(username, booktitle);
                return StatusCode(StatusCodes.Status204NoContent, "Deleted resource");
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
