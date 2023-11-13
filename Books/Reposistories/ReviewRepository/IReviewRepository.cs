using Books.Models.Domain;

namespace Books.Reposistories.ReviewRepository
{
    public interface IReviewRepository
    {
        Task<List<Review>> GetAllReviews();

        Task<Review?> GetAReview(Guid id);
    }
}
