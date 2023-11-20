using Books.Models.Domain;
using Books.Models.DTOs.AuthorsDto;
using Books.Models.DTOs.DifficultiesDto;
using Books.Models.DTOs.GenresDto;
using Books.Models.DTOs.PublishersDto;
using Books.Models.DTOs;

namespace Books.Models.DTOs
{
    public class BookDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public int Pagecount { get; set; }

        public int WordsPerPage { get; set; }

        public int WordCount { get; set; }

        public ImageDto Image { get; set; }

        public PublisherDto Publisher { get; set; }
      
        public GenreDto Genre { get; set; }

        public AuthorDto Author { get; set; }

        public DifficultyDto Difficulty { get; set; }

      

    }
}
