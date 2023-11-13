using Books.Models.Domain;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Books.Models.DTOs.UserDto
{
    public class GeneralUserDto
    {

        public Guid Id { get; set; }
        [DataType(DataType.EmailAddress)]
        public string Username { get; set; }

        
        public ICollection<Book> Books { get; set; }
    }
}
