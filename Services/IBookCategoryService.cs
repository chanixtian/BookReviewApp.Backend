using BookReviewApp.Backend.Core.Dtos;
using BookReviewApp.Backend.Core.Entities;

namespace BookReviewApp.Backend.Services
{
    public interface IBookCategoryService
    {
        public Task<BookCategory> Create(string name);
        public Task<List<BookCategory>> GetAll();
        public Task<BookCategory> GetById(int id);
        public Task<BookCategory> Update(int id, UpdateCategoryDto dto);
        public Task<BookCategory> Delete(int id);
    }
}
