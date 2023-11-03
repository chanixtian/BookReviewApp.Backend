using BookReviewApp.Backend.Core.Enum;

namespace BookReviewApp.Backend.Core.Entities;

public class User
{
    public int Id { get; set; }
    public string Username { get; set; }
    public string Firstname { get; set; }
    public string Lastname { get; set; }
    public string Email { get; set; }   
    public string Password { get; set; }
    public string Image { get; set; }
    public bool IsActive { get; set; }
    public bool IsValidate { get; set; }
    public UserRole UserRole { get; set; }
    public virtual ICollection<Review> Reviews { get; set; }
}
