using Books.Models.Domain;
using Books.Models.DTOs.PublishersDto;
using Books.Models.DTOs.ReviewDto;

namespace Books.Service.ReviewService
{
    public interface IReviewService
    {
        Task<List<ReviewDto>> GetAllReviews();

        Task<ReviewDto?> GetAReviewById(Guid id);

        Task<List<ReviewDto>> GetAllRecentReviews();

        Task<List<ReviewDto>> GetAllPopularReviews();
    }
}
