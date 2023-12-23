using LibraryManagementSystem.Dtos.Books;
using LibraryManagementSystem.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementSystem.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookService _bookService;
        public BooksController(IBookService bookService)
        {
            _bookService = bookService;
        }

        //a method that gets all books caling the Book service
        [HttpGet]
        public ActionResult<List<BookDto>> GetBooks()
        {
            try
            {
                return Ok(_bookService.GetAllBooks());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        //a method that adds a book, making a call to the book service
        [HttpPost("addBook")]
        public IActionResult AddBook([FromBody] AddBookDto bookDto)
        {
            try
            {
                _bookService.AddBook(bookDto);
                return StatusCode(StatusCodes.Status201Created);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred");
            }
        }
        //a method that deletes a book making a call to the Book service
        [HttpDelete("{bookTitle}")]
        public IActionResult Delete(string bookTitle)
        {
            try
            {
                _bookService.DeleteBook(bookTitle);
                return StatusCode(StatusCodes.Status204NoContent, "Deleted resource");
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred");
            }

        }
        //a method that updates a book and makes a call to the Book service
        [HttpPut("updateBook")]
        public IActionResult UpdateBook([FromBody] UpdateBookDto updateBookDto)
        {
            try
            {
                _bookService.UpdateBook(updateBookDto);
                return StatusCode(StatusCodes.Status204NoContent, "Book updated.");
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred");
            }
        }
        //a method that retrieves a book by it's title, making a call to the book service
        [HttpGet("{title}")]
        public ActionResult<BookDto> GetBookByTitle(string title)
        {
            try
            {
                return Ok(_bookService.GetBookByTitle(title));
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred");
            }
        }


    }
}
