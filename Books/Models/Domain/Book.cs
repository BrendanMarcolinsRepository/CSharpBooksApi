using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Books.Models.Domain
{
    [Table("Book")]
    public class Book
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string? BookCover { get; set; }

        public Guid AuthorId { get; set; }

        public Guid DifficultyId { get; set; }

        public Guid PublisherId { get; set; }

        public Guid GenreId { get; set; }

        public Author Author { get; set; }

        public Difficulty Difficulty { get; set; }

        public Publisher Publisher { get; set; }

        public Genre Genre { get; set; }

        public ICollection<User> Users { get; set; }

    }
}
