using System.ComponentModel.DataAnnotations;

namespace Books.Models.DTOs.AuthorsDto
{
    public class AddAuthorDto
    {
        [Required]
        [MinLength(1, ErrorMessage = "Empty Input Here")]
        [MaxLength(100, ErrorMessage = "You have acceeded the characters for the authors name")]
        public string Name { get; set; }
    }
}
