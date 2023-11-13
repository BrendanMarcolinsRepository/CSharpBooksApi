using Books.Data;
using Books.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace Books.Reposistories.ProgressRepository
{
    public class PostGresProgressRepository : IProgressRepository
    {
        private readonly BooksDbContext dbContext;
        public PostGresProgressRepository(BooksDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<List<Progress>> GetAllProgress()
        {
            var progress = await dbContext.Progress.Include(p => p.User).Include(p => p.Book).ToListAsync();

            return progress == null ? new List<Progress>() : progress;
        }

        public async Task<Progress?> GetAProgress(Guid id)
        {
            var progress = await dbContext.Progress.Include(p => p.User).Include(p => p.Book).FirstOrDefaultAsync(x => x.Id == id);

            return progress ?? null;
        }
    }
}
