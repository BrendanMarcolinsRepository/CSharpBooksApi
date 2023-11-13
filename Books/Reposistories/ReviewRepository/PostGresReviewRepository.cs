using Books.Data;
using Books.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace Books.Reposistories.ReviewRepository
{
    public class PostGresReviewRepository : IReviewRepository
    {
        private readonly BooksDbContext dbContext;

        public PostGresReviewRepository(BooksDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<List<Review>> GetAllReviews()
        {
            var reviews = await dbContext.Reviews.Include(r => r.Book).Include(r => r.User).ToListAsync();

            return reviews ?? null;
        }

        public async Task<Review?> GetAReview(Guid id)
        {
            var review = await dbContext.Reviews.Include(r => r.Book).Include(r => r.User).FirstOrDefaultAsync(r => r.Id == id);

            return review ?? null;
        }
    }
}
