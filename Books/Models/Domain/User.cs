using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Books.Models.Domain
{
    public class User
    {

        public Guid Id { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Username { get; set; }

        
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public string[] Roles { get; set; }
        
        [JsonIgnore]
        public Progress Progress { get; set; }

        [JsonIgnore]
        public ICollection<Book> Books { get; set; }
        [JsonIgnore]
        public ICollection<Review> Reviews { get; set; }
    }
}
