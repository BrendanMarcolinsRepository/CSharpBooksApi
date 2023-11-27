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

        public async Task<List<Review>> GetAllPopularReviews()
        {
           
            return await dbContext.Reviews
                .Include(r => r.Book)
                    .ThenInclude(r => r.Author)
                .Include(r => r.Book)
                    .ThenInclude(r => r.Publisher)
                .GroupBy(r => r.Book.Id)
                .Select(g => new Review
                {
                    Id = g.Key,
                    Name = g.First().Name,
                    Comment = g.First().Comment,
                    rating = (int) g.Average(r => r.rating),
                    posted = g.First().posted,
                    updated = g.First().updated,
                    Book = g.First().Book,
                    User = g.First().User
                    
                })
                .Distinct()
                .ToListAsync();
        }

        public async Task<List<Review>> GetAllRecentReviews()
        {
            return await dbContext.Reviews
                .Include(r => r.Book)
                    .ThenInclude(r => r.Author)
                .Include(r => r.Book)
                    .ThenInclude(r => r.Publisher)
                .OrderByDescending(b => b.posted)
                .ToListAsync();
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
