using AutoMapper;
using BookReviewApp.Backend.Core.Context;
using BookReviewApp.Backend.Core.Dtos;
using BookReviewApp.Backend.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookReviewApp.Backend.Services
{
    public class BookCategoryService : IBookCategoryService
    {
        private readonly AppDbContext context;
        private readonly IMapper mapper;
        public BookCategoryService(AppDbContext dbcontext, IMapper _mapper)
        {
            context = dbcontext;
            mapper = _mapper;   
        }

        public async Task<BookCategory> Create(string name)
        {
            try
            {
                var category = await context.Categories
                                            .Where(c => c.CategoryName == name)
                                            .FirstOrDefaultAsync();

                if (category != null)
                    throw new InvalidOperationException("Book Category already exists");

                var addCategory = new BookCategory
                { 
                    CategoryName = name 
                };

                context.Categories.Add(addCategory);
                await context.SaveChangesAsync();

                return addCategory;
            }
            catch (Exception e)
            {
                throw new ArgumentException(e.Message);
            }
        }

        public async Task<List<BookCategory>> GetAll()
            => await context.Categories
                            .ToListAsync();

        public async Task<BookCategory> GetById(int id)
            => await context.Categories
                            .Where(c => c.Id == id)
                            .FirstOrDefaultAsync();

        public async Task<BookCategory> Update(int id, UpdateCategoryDto dto)
        {
            try
            {
                var category = await context.Categories
                                            .Where(c => c.Id == id)
                                            .FirstOrDefaultAsync();
                if (category == null)
                    throw new InvalidOperationException("Book Category not found");

                mapper.Map(dto, category);
                category.CategoryName = dto.CategoryName;

                context.Categories.Update(category);
                await context.SaveChangesAsync();

                return category;
            }
            catch (Exception e)
            {
                throw new ArgumentException(e.Message);
            }
        }

        public async Task<BookCategory> Delete(int id)
        {
            try
            {
                var category = await context.Categories
                                            .Where(c => c.Id == id)
                                            .FirstOrDefaultAsync();
                if (category == null)
                    throw new InvalidOperationException("Book Category not found");

                context.Categories.Remove(category);
                await context.SaveChangesAsync();

                return category;
            }
            catch (Exception e)
            {
                throw new ArgumentException(e.Message);
            }
        }
    }
}
