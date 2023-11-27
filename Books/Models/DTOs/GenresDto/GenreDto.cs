using Books.Models.Domain;
using System.Text.Json.Serialization;

namespace Books.Models.DTOs.GenresDto
{
    public class GenreDto
    {

        public Guid Id { get; set; }
        public string Name { get; set; }

        
        public ICollection<Book> Books { get; set; }
    }
}
