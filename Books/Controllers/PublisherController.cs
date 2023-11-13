using Books.Models.Domain;
using Books.Models.DTOs.GenresDto;
using Books.Models.DTOs.PublishersDto;
using Books.Service.GenreService;
using Books.Service.PublisherService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Books.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublisherController : Controller
    {
        private readonly IPublisherService publisherService;

        public PublisherController(IPublisherService publisherService)
        {
            this.publisherService = publisherService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPublisher()
        {
            var publisher = await publisherService.GetAllPublisher();

            return publisher.Count > 0 ? Ok(publisher) : NotFound("Error or No Genres Exist!");

        }


        [HttpGet]
        [Route("{id:Guid}")]
        [Authorize(Roles = "Reader")]
        public async Task<IActionResult> GetAPublisherById([FromRoute] Guid id)
        {
            var publisher = await publisherService.GetAPublisherById(id);

            return publisher != null ? Ok(publisher) : NotFound("Error or No Genres Exist!");

        }

        [HttpGet("{name}")]
        [Authorize(Roles = "Reader")]
        public async Task<IActionResult> GetAGenreByName([FromRoute] string name)
        {
            var publisher = await publisherService.GetAPublisherByName(name);

            return publisher != null ? Ok(publisher) : NotFound("Error or No Genres Exist!");

        }


        [HttpPost]
        [Authorize(Roles = "Writer")]
        public async Task<IActionResult> CreateAPublisher([FromBody] GeneralPublisherDto publisherGeneralDto)
        {
            var publisher = await publisherService.CreateAPublisher(publisherGeneralDto);

            return publisher != null ? Ok(publisher) : NotFound("Error or No Genres Exist!");

        }

        [HttpPut]
        [Route("{id:Guid}")]
        [Authorize(Roles = "Writer")]
        public async Task<IActionResult> UpdateAPublisher([FromRoute] Guid id, [FromBody] GeneralPublisherDto publisherGeneralDto)
        {
            var publisher = await publisherService.UpdateAPublisher(id, publisherGeneralDto);

            return publisher != null ? Ok(publisher) : NotFound("Error or No Genres Exist!");

        }

        [HttpDelete]
        [Route("{id:Guid}")]
        [Authorize(Roles = "Writer")]
        public async Task<IActionResult> DeleteAPublisher([FromRoute] Guid id, [FromBody] GeneralPublisherDto publisherGeneralDto)
        {
            var publisher = await publisherService.DeleteAPublisher(id, publisherGeneralDto);

            return publisher != null ? Ok(publisher) : NotFound("Error or No Genres Exist!");

        }

    }
}
