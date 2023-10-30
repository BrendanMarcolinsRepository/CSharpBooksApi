using AutoMapper;
using Books.CustomActionFilters;
using Books.Data;
using Books.Models.Domain;
using Books.Models.DTOs;
using Books.Models.DTOs.DifficultiesDto;
using Books.Reposistories;
using Books.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Books.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class DifficultiesController : ControllerBase
    {
        public IDifficultiesService difficultiesService;

        public DifficultiesController(IDifficultiesService difficultiesService)
        {
            this.difficultiesService = difficultiesService;
        }


        [HttpGet]
       //[Authorize(Roles = "Reader)")]
        public async Task<IActionResult> GetAllDifficulties()
        {

            //get data from database = domain model

            var difficulties = await difficultiesService.GetAllDifficulties();

            if(difficulties == null) return NotFound();


            //Return DTOs
            return Ok(difficulties);

        }

        [HttpGet]
        [Route("{id:Guid}")]
        [Authorize(Roles = "Reader")]
        public async Task<IActionResult> GetADifficultyById([FromRoute] Guid id)
        {

            if(id == null) return NotFound();

            var difficulty = await difficultiesService.GetADifficultyById(id);

            if(difficulty == null) return NotFound();

            return Ok(difficulty);
        }


        //(GET a Single Author by ID )
        [HttpGet("{name}")]
        [Authorize(Roles = "Reader")]
        public async Task<IActionResult> GetADifficultyByName([FromRoute] String name)
        {

            if (string.IsNullOrEmpty(name)) return NotFound();

            var difficulty = await difficultiesService.GetADifficultyByName(name);

            if (difficulty == null) return NotFound();

            return Ok(difficulty);
        }

        [HttpPost]
        [ValidateModel]
        [Authorize(Roles = "Writer")]
        public async Task<IActionResult> CreateADifficulty([FromBody] AddDifficultyDto difficultyDtoRequest)
        {


            // var author = new Author { Name = authorDtoRequest.Name };

            if(difficultyDtoRequest == null) return NotFound();

            var difficulties = await difficultiesService.CreateADifficulty(difficultyDtoRequest);

            if(difficulties == null) return NotFound();

           
            return CreatedAtAction(nameof(GetADifficultyById), new { id = difficulties.Id }, difficulties);


        }

        [HttpPut]
        [Route("{id:Guid}")]
        [ValidateModel]
        [Authorize(Roles = "Writer")]
        public async Task<IActionResult> UpdateAnDifficulty([FromRoute] Guid id, [FromBody] AddDifficultyDto difficultyDto)
        {
            
            if (id == null || difficultyDto == null) return NotFound();

            var difficulty = await difficultiesService.UpdateADifficulty(id, difficultyDto);

            if (difficulty == null) return NotFound();


            return Ok(difficulty);

        }


        [HttpDelete]
        [Route("{id:Guid}")]
        [Authorize(Roles = "Writer")]
        public async Task<IActionResult> DeleteADifficulty([FromRoute] Guid id, [FromBody] AddDifficultyDto difficultyDto)
        {
            if (id == null || difficultyDto == null) return NotFound();
            

            var difficulty = await difficultiesService.DeleteADifficulty(id, difficultyDto);

            if (difficulty == null) return NotFound();
            

            return Ok(difficulty);
        }
    }

   
}
