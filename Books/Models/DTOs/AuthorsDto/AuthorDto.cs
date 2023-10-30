using System.ComponentModel.DataAnnotations;

namespace Books.Models.DTOs.AuthorsDto
{
    public class AuthorDto
    {

        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
