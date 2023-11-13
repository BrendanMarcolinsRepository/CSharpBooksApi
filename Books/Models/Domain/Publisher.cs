using System.Text.Json.Serialization;

namespace Books.Models.Domain
{
    public class Publisher
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        [JsonIgnore]
        public ICollection<Book> Books { get; set; }
    }
}
