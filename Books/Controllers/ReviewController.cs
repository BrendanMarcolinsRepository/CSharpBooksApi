using Books.Service;
using Books.Service.ReviewService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Books.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewController : Controller
    {
        private readonly IReviewService reviewService;

        public ReviewController(IReviewService reviewService)
        {
            this.reviewService = reviewService;
        }

        [HttpGet]
        //[Authorize(Roles = "Reader")]
        public async Task<IActionResult> GetAllReviews(
             [FromQuery] string? filterOn, string? filteQuery,
             [FromQuery] string? sortBy, [FromQuery] bool isAscending,
             [FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 1000
         )
        {


            var reviews = await reviewService.GetAllReviews();

            if (reviews == null) return NotFound("No Books");

            return Ok(reviews);
        }

        [HttpGet]
        [Route("{id:Guid}")]
        //[Authorize(Roles = "Reader")]
        public async Task<IActionResult> GetByReviewId([FromRoute] Guid id)
        {
            if (id == null) return NotFound();

            var review = await reviewService.GetAReviewById(id);

            if (review == null) return NotFound();


            return Ok(review);

        }


    }
}
