using System.ComponentModel.DataAnnotations;

namespace Books.Models.DTOs
{
    public class UpdateBookDto
    {
        [Required]
        [MinLength(1, ErrorMessage = "Empty Input Here")]
        [MaxLength(40, ErrorMessage = "You have acceeded the characters for the authors name")]
        public string Name { get; set; }

        [Required]
        [MinLength(1, ErrorMessage = "Empty Input Here")]
        [MaxLength(300, ErrorMessage = "You have acceeded the characters for the authors name")]
        public string Description { get; set; }

        [Required]
        [MinLength(1, ErrorMessage = "Empty Input Here")]
        [MaxLength(100, ErrorMessage = "You have acceeded the characters for the authors name")]
        public string? BookCover { get; set; }


        [Required]
        [MinLength(1, ErrorMessage = "Empty Input Here")]
        public int Pagecount { get; set; }

        [Required]
        [MinLength(1, ErrorMessage = "Empty Input Here")]
        public int WordsPerPage { get; set; }

        [Required]
        [MinLength(1, ErrorMessage = "Empty Input Here")]
        public int WordCount { get; set; }

        [Required]
        public Guid AuthorId { get; set; }

        [Required]
        public Guid DifficultyId { get; set; }
    }
}
