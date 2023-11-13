using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Books.Models.Domain
{
    [Table("Book")]
    public class Book
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Pagecount { get; set; }

        public int WordsPerPage { get; set; }

        public int WordCount { get; set; }

        public string? BookCover { get; set; }

        public Guid AuthorId { get; set; }

        public Guid DifficultyId { get; set; }

        public Guid PublisherId { get; set; }

        public Guid GenreId { get; set; }

        public Guid ProgressId { get; set; }

        [JsonIgnore]
        public Author Author { get; set; }
        [JsonIgnore]
        public Difficulty Difficulty { get; set; }
        [JsonIgnore]
        public Publisher Publisher { get; set; }
        [JsonIgnore]
        public Genre Genre { get; set; }

        [JsonIgnore]
        public Progress Progress { get; set; }

        [JsonIgnore]
        public ICollection<User> Users { get; set; }
        [JsonIgnore]
        public ICollection<Review> Reviews { get; set; }

    }
}
