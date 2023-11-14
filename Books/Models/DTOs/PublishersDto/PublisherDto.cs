using Books.Models.Domain;
using System.Text.Json.Serialization;

namespace Books.Models.DTOs.PublishersDto
{
    public class PublisherDto
    {

        public Guid Id { get; set; }
        public string Name { get; set; }

        [JsonIgnore]
        public ICollection<Book> Books { get; set; }
    }
}
