using System.Text.Json.Serialization;

namespace Books.Models.Domain
{
    public class Review
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Comment { get; set; }

        public int rating { get; set; }

        public Guid BookId { get; set; }

        public Guid UserId { get; set; }
        [JsonIgnore]
        public Book Book { get; set;}
        [JsonIgnore]
        public User User { get; set; }
    }
}
