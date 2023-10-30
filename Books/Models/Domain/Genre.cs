namespace Books.Models.Domain
{
    public class Genre
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public Book book { get; set; }
    }
}
