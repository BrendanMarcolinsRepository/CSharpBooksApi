using Books.Models.Domain;

namespace Books.Models.DTOs.PublishersDto
{
    public class GeneralPublisherDto
    {
        public string Name { get; set; }

        public ICollection<Book> Books { get; set; }
    }
}
