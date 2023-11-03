namespace BookReviewApp.Backend.Core.Entities;

public class Book
{
    public int Id { get; set; }
    public int AuthorId { get; set; }
    public virtual Author Author { get; set; }
    public int BookCategoryId { get; set; }
    public virtual BookCategory BookCategory { get; set; }
    public string ISBN { get; set; }
    public DateTime PublishDate { get; set; }
    public string CoverImage { get; set; }
    public DateTime DateCreated { get; set; }
    public bool IsActive { get; set; }

    public ICollection<Review> Reviews { get; set; }
}
