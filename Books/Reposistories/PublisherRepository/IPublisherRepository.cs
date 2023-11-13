using Books.Models.Domain;

namespace Books.Reposistories.PublisherRepository
{
    public interface IPublisherRepository
    {
        Task<List<Publisher>> GetAllPublishers();

        Task<Publisher?> GetAnPublisher(Guid id);

        Task<Publisher> GetAPublisherByName(String name);

        Task<Publisher?> CreateAPublisher(Publisher publisher);


        Task<Publisher?> UpdateAPublisher(Guid id, Publisher publisher);

        Task<Publisher?> DeleteAPublisher(Guid id, Publisher publisher);
    }
}
