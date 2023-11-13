using Books.Service.ProgressService;
using Books.Service.PublisherService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Books.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProgressController : Controller
    {
        private readonly IProgressService progressService;

        public ProgressController(IProgressService progressService)
        {
            this.progressService = progressService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPublisher()
        {
            var progress = await progressService.GetAllProgress();

            return progress.Count > 0 ? Ok(progress) : NotFound("Error or No Genres Exist!");

        }


        [HttpGet]
        [Route("{id:Guid}")]
        //[Authorize(Roles = "Reader")]
        public async Task<IActionResult> GetAPublisherById([FromRoute] Guid id)
        {
            var progress = await progressService.GetAProgress(id);

            return progress != null ? Ok(progress) : NotFound("Error or No Genres Exist!");

        }
    }
}
