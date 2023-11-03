using BookReviewApp.Backend.Core.Dtos;
using BookReviewApp.Backend.Core.Entities;

namespace BookReviewApp.Backend.Services
{
    public interface IBookService
    {
        public Task<Book> Create(CreateBookDto dto);
        public Task<List<Book>> GetAllBook();
        public Task<Book> GetById(int id);
        public Task<Book> Update(int id, UpdateBookDto dto);
        public Task<Book> BookActivation(int id);
        public Task<Book> BookDeactivation(int id);
        public Task<Book> Delete(int id);
    }
}
