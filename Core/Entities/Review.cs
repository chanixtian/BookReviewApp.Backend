namespace BookReviewApp.Backend.Core.Entities;

public class Review
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public virtual User User { get; set; }
    public int BookId { get; set; }
    public virtual Book Book { get; set; }
    public int Rating { get; set; }
    public string Comment { get; set; }
    public DateTime ReviewDate { get; set; }
}
