using Books.Models.Domain;

namespace Books.Models.DTOs.ReviewDto
{
    public class GeneralReviewDto
    {
       
        public string Name { get; set; }

        public string Comment { get; set; }

        public int rating { get; set; }

        public Guid BookId { get; set; }

        public Guid UserId { get; set; }

        public Book Book { get; set; }

        public User User { get; set; }
    }
}
