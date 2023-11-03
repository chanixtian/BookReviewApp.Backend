using BookReviewApp.Backend.Core.Dtos;
using BookReviewApp.Backend.Services;
using Microsoft.AspNetCore.Mvc;

namespace BookReviewApp.Backend.Controllers
{
    [ApiController, Route("api/[controller]")]
    public class AuthorController : ControllerBase
    {
        private readonly IAuthorService service;
        public AuthorController(IAuthorService _service)
        {
            service = _service;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAuthor(CreateAuthorDto dto)
        {
            try
            {
                var author = await service.Create(dto);

                return Ok(author);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAuthor()
        {
            try
            {
                var author = await service.GetAll();

                return Ok(author);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var author = await service.GetById(id);

                return Ok(author);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("author-update/{id}")]
        public async Task<IActionResult> UpdateAuthor(int id, UpdateAuthorDto dto)
        {
            try
            {
                var author = await service.Update(id, dto);

                return Ok(author);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("delete-author/{id}")]
        public async Task<IActionResult> DeleteAuthor(int id)
        {
            try
            {
                var author = await service.Delete(id);

                return Ok(author);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
