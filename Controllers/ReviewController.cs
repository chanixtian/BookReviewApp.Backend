using BookReviewApp.Backend.Core.Dtos;
using BookReviewApp.Backend.Services;
using Microsoft.AspNetCore.Mvc;

namespace BookReviewApp.Backend.Controllers
{
    [ApiController, Route("api/[controller]")]
    public class ReviewController : ControllerBase
    {
        private readonly IReviewService service;
        public ReviewController(IReviewService _service)
        {
            service = _service;
        }

        [HttpPost]
        public async Task<IActionResult> ReviewAdd(CreateReviewDto dto)
        {
            try
            {
                var review = await service.AddReview(dto);

                return Ok(review);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAllReview()
        {
            try
            {
                var review = await service.GetAll();

                return Ok(review);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdReview(int id)
        {
            try
            {
                var review = await service.GetById(id);

                return Ok(review);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
