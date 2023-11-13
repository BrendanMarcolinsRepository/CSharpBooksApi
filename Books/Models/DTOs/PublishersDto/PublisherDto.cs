using Books.Models.Domain;

namespace Books.Models.DTOs.PublishersDto
{
    public class PublisherDto
    {

        public Guid Id { get; set; }
        public string Name { get; set; }

        public ICollection<Book> Books { get; set; }
    }
}
