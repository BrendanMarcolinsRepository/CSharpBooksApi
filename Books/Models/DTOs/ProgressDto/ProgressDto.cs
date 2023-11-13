using Books.Models.Domain;
using System.Text.Json.Serialization;

namespace Books.Models.DTOs.ProgressDto
{
    public class ProgressDto
    {
        public Guid Id { get; set; }

        public int percentage { get; set; }

        public bool completed { get; set; }

        public int timeleft { get; set; }

        public Guid BookId { get; set; }

        public Guid UserId { get; set; }

        [JsonIgnore]
        public Book Book { get; set; }

        [JsonIgnore]
        public User User { get; set; }
    }
}
