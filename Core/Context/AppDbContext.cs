using BookReviewApp.Backend.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookReviewApp.Backend.Core.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<BookCategory> Categories { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Review> Reviews { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Review>()
                .HasOne(r => r.Book)
                .WithMany(r => r.Reviews)
                .HasForeignKey(r => r.BookId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Review>()
                .HasOne(r => r.User)
                .WithMany(r => r.Reviews)
                .HasForeignKey(r => r.UserId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
