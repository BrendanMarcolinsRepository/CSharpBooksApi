using Books.Models.Domain;
using System.ComponentModel.DataAnnotations.Schema;

namespace Books.Models.DTOs.ReviewDto
{
    public class ReviewDto
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Comment { get; set; }

        public int rating { get; set; }

        [Column(TypeName = "DATE")]
        public DateTime posted { get; set; }

        [Column(TypeName = "DATE")]
        public DateTime updated { get; set; }

        public Guid BookId { get; set; }

        public Guid UserId { get; set; }

        public Book Book { get; set; }

        public User User { get; set; }
    }
}
