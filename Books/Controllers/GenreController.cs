using Books.Models.DTOs.DifficultiesDto;
using Books.Models.DTOs.GenresDto;
using Books.Service.GenreService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Books.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenreController : ControllerBase
    {
        private readonly IGenreService genreService;

        public GenreController(IGenreService genreService)
        {
            this.genreService = genreService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllGenres()
        { 
            var genres = await genreService.GetAllGenre();

            return genres.Count > 0 ? Ok(genres) : NotFound("Error or No Genres Exist!");

        }


        [HttpGet]
        [Route("{id:Guid}")]
        [Authorize(Roles = "Reader")]
        public async Task<IActionResult> GetAGenreById([FromRoute] Guid id)
        {
            var genres = await genreService.GetAGenreById(id);

            return genres != null ? Ok(genres) : NotFound("Error or No Genres Exist!");

        }

        [HttpGet("{name}")]
        [Authorize(Roles = "Reader")]
        public async Task<IActionResult> GetAGenreByName([FromRoute] string name)
        {
            var genres = await genreService.GetAGenreByName(name);

            return genres != null ? Ok(genres) : NotFound("Error or No Genres Exist!");

        }

        [HttpPost]
        [Authorize(Roles = "Writer")]
        public async Task<IActionResult> CreateAGenre([FromBody] AddDeleteUpdateGenreDto genreGeneralDto)
        {
            var genres = await genreService.CreateAGenre(genreGeneralDto);

            return genres != null ? Ok(genres) : NotFound("Error or No Genres Exist!");

        }

        [HttpPut]
        [Route("{id:Guid}")]
        [Authorize(Roles = "Writer")]
        public async Task<IActionResult> UpdateAGenre([FromRoute] Guid id , [FromBody] AddDeleteUpdateGenreDto genreGeneralDto)
        {
            var genres = await genreService.UpdateAGenre(id, genreGeneralDto);

            return genres != null ? Ok(genres) : NotFound("Error or No Genres Exist!");

        }

        [HttpDelete]
        [Route("{id:Guid}")]
        [Authorize(Roles = "Writer")]
        public async Task<IActionResult> DeleteAGenre([FromRoute] Guid id, [FromBody] AddDeleteUpdateGenreDto genreGeneralDto)
        {
            var genres = await genreService.DeleteAGenre(id, genreGeneralDto);

            return genres != null ? Ok(genres) : NotFound("Error or No Genres Exist!");

        }
    }
}
