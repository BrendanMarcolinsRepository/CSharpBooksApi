using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Books.Models.Domain
{
    [Table("Author")]
    public class Author
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }

        public Book book { get; set; }
    }
}
