using Books.Models.Domain;
using System.ComponentModel.DataAnnotations;

namespace Books.Models.DTOs.UserDto
{
    public class UserDto
    {

        public Guid Id { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Username { get; set; }


        [DataType(DataType.Password)]
        public string Password { get; set; }

        public string[] Roles { get; set; }

      
    }
}
