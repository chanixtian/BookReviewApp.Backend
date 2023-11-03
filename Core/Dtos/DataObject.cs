using BookReviewApp.Backend.Core.Entities;

namespace BookReviewApp.Backend.Core.Dtos
{
    public class UserCreateDto
    {
        public string Username { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public IFormFile Image { get; set; }
    }

    public class UserLoginDto
    {
        public string UsernameOrEmail { get; set; }
        public string Password { get; set; }
    }

    public class UserUpdateProfileDetailsDto
    {
        public string Username { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public IFormFile Image { get; set; }
    }
    
    public class CreateBookDto
    {
        public int AuthorId { get; set; }
        public int BookCategoryId { get; set; }
        public string ISBN { get; set; }
        public DateTime PublishDate { get; set; }
        public IFormFile CoverImage { get; set; }
    }

    public class UpdateBookDto
    {
        public int AuthorId { get; set; }
        public int BookCategoryId { get; set; }
        public string ISBN { get; set; }
        public DateTime PublishDate { get; set; }
        public IFormFile CoverImage { get; set; }
    }

    public class CreateAuthorDto
    {
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
    }

    public class UpdateCategoryDto
    {
        public string CategoryName { get; set; }
    }

    public class UpdateAuthorDto
    {
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
    }

    public class CreateReviewDto
    {
        public int UserId { get; set; }
        public int BookId { get; set; }
        public int Rating { get; set; }
        public string Comment { get; set; }
    }
}
