using Books.Models.DTOs;
using Books.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Books.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagesController : ControllerBase
    {
        private readonly IImageService imageService;

        public ImagesController(IImageService imageService)
        {
            this.imageService = imageService;
        }

        [HttpPost]
        [Route("UploadImage")]
        public async Task<IActionResult> UploadImage([FromForm] ImageUploadRequestDto imageDto )
        {
            var image = await imageService.UploadImage(imageDto);

            if(image == null) 
            {
                ModelState.AddModelError("File", "Something Went horribly wrong!");
                return BadRequest(ModelState);
            }

            return Ok(image);

        }
    
        
    
    }

}
