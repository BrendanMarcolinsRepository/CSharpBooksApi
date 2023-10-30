using System.ComponentModel.DataAnnotations;

namespace Books.Models.DTOs
{
    public class CreateBookDto
    {
        [Required]
        [MinLength(1, ErrorMessage = "Empty Input Here")]
        [MaxLength(40, ErrorMessage = "You have acceeded the characters for the authors name")]
        public string Name { get; set; }

        [Required]
        [MinLength(1, ErrorMessage = "Empty Input Here")]
        [MaxLength(200, ErrorMessage = "You have acceeded the characters for the authors name")]
        public string Description { get; set; }

        [Required]
        [MinLength(1, ErrorMessage = "Empty Input Here")]
        [MaxLength(100, ErrorMessage = "You have acceeded the characters for the authors name")]
        public string? BookCover { get; set; }

        [Required]
        public Guid AuthorId { get; set; }

        [Required]
        public Guid DifficultyId { get; set; }
    }
}
