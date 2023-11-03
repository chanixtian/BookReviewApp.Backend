using BookReviewApp.Backend.Core.Dtos;
using BookReviewApp.Backend.Core.Entities;

namespace BookReviewApp.Backend.Services
{
    public interface IAuthorService
    {
        public Task<Author> Create(CreateAuthorDto dto);
        public Task<List<Author>> GetAll();
        public Task<Author> GetById(int id);
        public Task<Author> Update(int id, UpdateAuthorDto dto);
        public Task<Author> Delete(int id);
    }
}
