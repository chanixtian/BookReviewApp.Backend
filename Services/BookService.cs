using AutoMapper;
using BookReviewApp.Backend.Core.Context;
using BookReviewApp.Backend.Core.Dtos;
using BookReviewApp.Backend.Core.Entities;
using BookReviewApp.Backend.Core.ImagePathFolder;
using Microsoft.EntityFrameworkCore;

namespace BookReviewApp.Backend.Services
{
    public class BookService : IBookService
    {
        private readonly AppDbContext context;
        private readonly IMapper mapper;
        public BookService(AppDbContext dbcontext, IMapper _mapper)
        {
            context = dbcontext;
            mapper = _mapper;
        }

        public async Task<Book> Create(CreateBookDto dto)
        {
            try
            {
                var book = await context.Books
                                        .Where(b => b.ISBN == dto.ISBN)
                                        .FirstOrDefaultAsync();

                if (book != null)
                    throw new InvalidOperationException("ISBN already exists");

                var coverImagePath = await new ImageDirectory().bookCoverImage(dto.CoverImage);

                var newBook = mapper.Map<Book>(dto);
                newBook.CoverImage = coverImagePath;
                newBook.DateCreated = DateTime.Now;
                newBook.IsActive = true;

                context.Books.Add(newBook);
                await context.SaveChangesAsync();   

                return newBook; 
            }
            catch (Exception e)
            {
                throw new ArgumentException(e.Message);
            }
        }

        public async Task<List<Book>> GetAllBook()
            => await context.Books
                            .Include(b => b.Author)
                            .Include(b => b.BookCategory)
                            .ToListAsync();

        public async Task<Book> GetById(int id)
            => await context.Books
                            .Include(b => b.Author)
                            .Include(b => b.BookCategory)
                            .Where(b => b.Id == id)
                            .FirstOrDefaultAsync();

        public async Task<Book> Update(int id, UpdateBookDto dto)
        {
            try
            {
                var book = await context.Books
                                        .Where(b => b.Id == id)
                                        .FirstOrDefaultAsync();
                if (book == null)
                    throw new InvalidOperationException("Book not found");

                var coverImagePath = await new ImageDirectory().bookCoverImage(dto.CoverImage);

                mapper.Map(dto, book);
                book.CoverImage = coverImagePath;

                context.Books.Update(book);
                await context.SaveChangesAsync();

                return book;
            }
            catch (Exception e)
            {
                throw new ArgumentException(e.Message);
            }
        }

        public async Task<Book> BookActivation(int id)
        {
            try
            {
                var book = await context.Books
                                        .Where(b => b.Id == id)
                                        .FirstOrDefaultAsync();
                if (book == null)
                    throw new InvalidOperationException("Book not found");

                book.IsActive = true;

                context.Books.Update(book);
                await context.SaveChangesAsync();

                return book;
            }
            catch (Exception e)
            {
                throw new ArgumentException(e.Message);
            }
        }

        public async Task<Book> BookDeactivation(int id)
        {
            try
            {
                var book = await context.Books
                                        .Where(b => b.Id == id)
                                        .FirstOrDefaultAsync();
                if (book == null)
                    throw new InvalidOperationException("Book not found");

                book.IsActive = false;

                context.Books.Update(book);
                await context.SaveChangesAsync();

                return book;
            }
            catch (Exception e)
            {
                throw new ArgumentException(e.Message);
            }
        }

        public async Task<Book> Delete(int id)
        {
            try
            {
                var book = await context.Books
                                        .Where(b => b.Id == id)
                                        .FirstOrDefaultAsync();
                if (book == null)
                    throw new InvalidOperationException("Book not found");

                context.Books.Remove(book);
                await context.SaveChangesAsync();

                return book;
            }
            catch (Exception e)
            {
                throw new ArgumentException(e.Message);
            }
        }
    }
}
