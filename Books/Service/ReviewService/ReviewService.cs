using AutoMapper;
using Books.Models.DTOs.PublishersDto;
using Books.Models.DTOs.ReviewDto;
using Books.Reposistories.ReviewRepository;

namespace Books.Service.ReviewService
{
    public class ReviewService : IReviewService
    {
        private readonly IReviewRepository reviewRepository;
        private readonly IMapper mapper;

        public ReviewService(IReviewRepository reviewRepository, IMapper mapper)
        {
            this.reviewRepository = reviewRepository;
            this.mapper = mapper;
        }

        public async Task<List<ReviewDto>> GetAllPopularReviews()
        {
            var reviews = await reviewRepository.GetAllPopularReviews();

            return mapper.Map<List<ReviewDto>>(reviews) ?? null;
        }

        public async Task<List<ReviewDto>> GetAllRecentReviews()
        {
            var reviews = await reviewRepository.GetAllRecentReviews();

            return mapper.Map<List<ReviewDto>>(reviews) ?? null;
        }

        public async Task<List<ReviewDto>> GetAllReviews()
        {
            var reviews = await reviewRepository.GetAllReviews();

            return mapper.Map<List<ReviewDto>>(reviews) ?? null;
        }

        public async Task<ReviewDto?> GetAReviewById(Guid id)
        {
            var review = await reviewRepository.GetAReview(id);

            return mapper.Map<ReviewDto>(review) ?? null;
        }
    }
}
