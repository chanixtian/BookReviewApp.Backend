using AutoMapper;
using BookReviewApp.Backend.Core.Context;
using BookReviewApp.Backend.Core.Dtos;
using BookReviewApp.Backend.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookReviewApp.Backend.Services
{
    public class ReviewService : IReviewService
    {
        private readonly AppDbContext context;
        private readonly IMapper mapper;
        public ReviewService(AppDbContext dbcontext, IMapper _mapper)
        {
            context = dbcontext;
            mapper = _mapper;
        }

        public async Task<Review> AddReview(CreateReviewDto dto)
        {
            try
            {
                var userExists = await context.Users.AnyAsync(u => u.Id == dto.UserId);
                if (!userExists)
                {
                    throw new ArgumentException("User does not exist.");
                }

                var bookExists = await context.Books.AnyAsync(b => b.Id == dto.BookId);
                if (!bookExists)
                {
                    throw new ArgumentException("Book does not exist.");
                }

                var review = mapper.Map<Review>(dto);
                review.ReviewDate = DateTime.Now;

                context.Reviews.Add(review);
                await context.SaveChangesAsync();

                return review;
            }
            catch (Exception e)
            {
                throw new ArgumentException(e.Message);
            }
        }

        public async Task<List<Review>> GetAll()
            => await context.Reviews
                            .Include(r => r.User)
                            .Include(r => r.Book)
                            .ToListAsync();

        public async Task<Review> GetById(int id)
            => await context.Reviews
                            .Include(r => r.User)
                            .Include(r => r.Book)
                            .Where(r => r.Id == id)
                            .FirstOrDefaultAsync();

    }
}
