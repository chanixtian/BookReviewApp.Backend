using BookReviewApp.Backend.Core.Dtos;
using BookReviewApp.Backend.Services;
using Microsoft.AspNetCore.Mvc;

namespace BookReviewApp.Backend.Controllers
{
    [ApiController, Route("api/[controller]")]
    public class BookCategoryController : ControllerBase
    {
        private readonly IBookCategoryService service;
        public BookCategoryController(IBookCategoryService _service)
        {
            service = _service;
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory(string name)
        {
            try
            {
                var category = await service.Create(name);

                return Ok(category);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCategory()
        {
            try
            {
                var category = await service.GetAll();

                return Ok(category);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdCategory(int id)
        {
            try
            {
                var category = await service.GetById(id);

                return Ok(category);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("update-name/{id}")]
        public async Task<IActionResult> UpdateCategory(int id, UpdateCategoryDto dto)
        {
            try
            {
                var category = await service.Update(id, dto);

                return Ok(category);    
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            try
            {
                var category = await service.Delete(id);

                return Ok(category);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
