using AutoMapper;
using BookReviewApp.Backend.Core.Context;
using BookReviewApp.Backend.Core.Dtos;
using BookReviewApp.Backend.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookReviewApp.Backend.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly AppDbContext context;
        private readonly IMapper mapper;
        public AuthorService(AppDbContext dbcontext, IMapper _mapper)
        {
            context = dbcontext;
            mapper = _mapper;
        }

        public async Task<Author> Create(CreateAuthorDto dto)
        {
            try
            {
                var author = await context.Authors
                                          .Where(a => a.Name == dto.Name)
                                          .FirstOrDefaultAsync();
                if (author != null)
                    throw new InvalidOperationException("Author already exists");

                var addAuthor = mapper.Map<Author>(dto);
                addAuthor.BirthDate = new DateTime(dto.BirthDate.Year, dto.BirthDate.Month, dto.BirthDate.Day);

                context.Authors.Add(addAuthor); 
                await context.SaveChangesAsync();

                return addAuthor;
            }
            catch (Exception e)
            {
                throw new ArgumentException(e.Message);
            }
        }

        public async Task<List<Author>> GetAll()
            => await context.Authors
                            .ToListAsync();

        public async Task<Author> GetById(int id)
            => await context.Authors
                            .Where(u => u.Id == id)
                            .FirstOrDefaultAsync();

        public async Task<Author> Update(int id, UpdateAuthorDto dto)
        {
            try
            {
                var author = await context.Authors
                                          .Where(a => a.Id == id)
                                          .FirstOrDefaultAsync();
                if (author == null)
                    throw new InvalidOperationException("Author not found");

                mapper.Map(dto, author);

                context.Authors.Update(author);
                await context.SaveChangesAsync();   

                return author;
            }
            catch (Exception e)
            {
                throw new InvalidOperationException(e.Message);
            }
        }

        public async Task<Author> Delete(int id)
        {
            try
            {
                var author = await context.Authors
                                          .Where(a => a.Id == id)
                                          .FirstOrDefaultAsync();
                if (author == null)
                    throw new InvalidOperationException("Author not found");

                context.Authors.Remove(author);
                await context.SaveChangesAsync();

                return author;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
