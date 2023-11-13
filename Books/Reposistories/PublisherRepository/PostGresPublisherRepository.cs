using Books.Data;
using Books.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace Books.Reposistories.PublisherRepository
{
    public class PostGresPublisherRepository : IPublisherRepository
    {
        private readonly BooksDbContext dbContext;

        public PostGresPublisherRepository(BooksDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Publisher?> CreateAPublisher(Publisher publisher)
        {
            await dbContext.AddAsync(publisher);

            var result = dbContext.SaveChangesAsync().IsCompletedSuccessfully;

            return result ? publisher : null;
        }

        public async Task<Publisher?> DeleteAPublisher(Guid id, Publisher publisher)
        {
            var publisherCurrentDetails = await GetAnPublisher(id);

            if (publisherCurrentDetails == null) 
            {
                return null;
            }

            dbContext.Remove(publisherCurrentDetails);

            var result = dbContext.SaveChangesAsync().IsCompletedSuccessfully;

            return result ? publisher : null;
        }

        public async  Task<List<Publisher>> GetAllPublishers()
        {
            var publishers = await dbContext.Publishers.Include(p => p.Books).ToListAsync();

            return publishers == null ? new List<Publisher>() : publishers;
        }

        public async Task<Publisher?> GetAnPublisher(Guid id)
        {
            var publisher = await dbContext.Publishers.FirstOrDefaultAsync(x => x.Id == id);

            return publisher ?? null;
        }

        public async Task<Publisher> GetAPublisherByName(string name)
        {
            var publisher = await dbContext.Publishers.FirstOrDefaultAsync(x => x.Name == name);

            return publisher ?? null;
        }

        public async Task<Publisher?> UpdateAPublisher(Guid id, Publisher publisher)
        {
            var result = await GetAnPublisher(id);

            if (result == null)
            {
                return null;
            }

            result.Name = publisher.Name;

            var success = dbContext.SaveChangesAsync().IsCompletedSuccessfully;

            return success ? publisher : null;
        }
    }
}
