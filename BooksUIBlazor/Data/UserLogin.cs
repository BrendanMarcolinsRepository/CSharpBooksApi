using System.ComponentModel.DataAnnotations;

namespace BooksUIBlazor.Data
{
    public class UserLogin
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Username { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
