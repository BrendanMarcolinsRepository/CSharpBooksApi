using System.ComponentModel.DataAnnotations;

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

        public ICollection<Book> Books { get; set; }
    }
}
