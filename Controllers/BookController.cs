using BookReviewApp.Backend.Core.Dtos;
using BookReviewApp.Backend.Services;
using Microsoft.AspNetCore.Mvc;

namespace BookReviewApp.Backend.Controllers
{
    [ApiController, Route("api/[controller]")]
    public class BookController :ControllerBase
    {
        private readonly IBookService service;
        public BookController(IBookService _service)
        {
            service = _service;
        }

        [HttpPost]
        public async Task<IActionResult> CreateBook([FromForm] CreateBookDto dto)
        {
            try
            {
                var book = await service.Create(dto);

                return Ok(book);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBook()
        {
            try
            {
                var book = await service.GetAllBook();

                return Ok(book);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdBook(int id)
        {
            try
            {
                var book = await service.GetById(id);

                return Ok(book);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("update-details/{id}")]
        public async Task<IActionResult> UpdateDetails(int id, [FromForm] UpdateBookDto dto)
        {
            try
            {
                var book = await service.Update(id, dto);

                return Ok(book);    
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("activate/{id}")]
        public async Task<IActionResult> Activate(int id)
        {
            try
            {
                var book = await service.BookActivation(id);

                return Ok(book);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("deactivate/{id}")]
        public async Task<IActionResult> Deactivate(int id)
        {
            try
            {
                var book = await service.BookDeactivation(id);

                return Ok(book);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("delete-book/{id}")]
        public async Task<IActionResult> DeleteBook(int id)
        {
            try
            {
                var book = await service.Delete(id);

                return Ok(book);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
