namespace Books.Models.Domain
{
    public class Publisher
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public Book book { get; set; }
    }
}
