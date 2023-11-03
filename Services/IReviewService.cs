using BookReviewApp.Backend.Core.Dtos;
using BookReviewApp.Backend.Core.Entities;

namespace BookReviewApp.Backend.Services
{
    public interface IReviewService
    {
        public Task<Review> AddReview(CreateReviewDto dto);
        public Task<List<Review>> GetAll();
        public Task<Review> GetById(int id);
    }
}
