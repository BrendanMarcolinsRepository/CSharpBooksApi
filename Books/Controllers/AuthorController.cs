using AutoMapper;
using Books.CustomActionFilters;
using Books.Data;
using Books.Models.Domain;
using Books.Models.DTOs.AuthorsDto;
using Books.Reposistories;
using Books.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text.Json;

namespace Books.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly IAuthorService authorService;
        private readonly IMapper mapper;
        private readonly ILogger<AuthController> logger;

        public AuthorController( IAuthorService authorService, IMapper mapper, ILogger<AuthController> logger)
        {
            this.authorService = authorService;
            this.mapper = mapper;
            this.logger = logger;
        }


        [HttpGet]
        public async Task<IActionResult> GetAllAuthors()
        {

            logger.LogInformation("----- Get All Running -----");

            var author = await authorService.GetAllAuthors();

            if(author == null) return NotFound();

            logger.LogInformation($"----- Get All Running Finished ----- : \n {JsonSerializer.Serialize(author)}" );

            Console.WriteLine($"here ====================> the author: {author}");
            //Return DTOs
            return Ok(author);

        }

        [HttpGet]
        [Route("TopBooks")]
        public async Task<IActionResult> GetAuthorsWithTopRatedBooks()
        {
            var authors = await authorService.GetAuthorsWithTopRatedBooks();

            if(authors.IsNullOrEmpty()) return NotFound();

            return Ok(authors);
        
        }

        [HttpGet]
        [Route("RecentBooks")]
        public async Task<IActionResult> GetAuthorsWithMostRecentBooks()
        {
            var authors = await authorService.GetAuthorsWithMostRecentBooks();

            if(authors.IsNullOrEmpty()) return NotFound();

            return Ok(authors);
        }

        //(GET a Single Author by ID )
        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetAnAuthorById([FromRoute] Guid id)
        {

            //find author by id

            //var author = dbContext.Authors.Find(id);

            if(id == null) return NotFound();

            var author = await authorService.GetAnAuthor(id);
           
            return Ok(author);
        }

        //(GET a Single Author by ID )
        [HttpGet("{name}")]
        public async Task<IActionResult> GetAnAuthorByName([FromRoute] String name)
        {

            if (string.IsNullOrWhiteSpace(name)) return NotFound();

            var author = await authorService.GetAnAuthorByName(name);

            return Ok(author);
        }

        //POST to create new Author

        [HttpPost]
        [ValidateModel]
        public async Task<IActionResult> CreateAnAuthor([FromBody] AddAuthorDto authorDtoRequest)
        {

            if(authorDtoRequest == null) return NotFound();

            var author = await authorService.CreateAnAuthor(authorDtoRequest);

            if (author == null) return NotFound();

            return Ok(author);

        }

        [HttpPut]
        [Route("{id:Guid}")]
        [ValidateModel]
        public async Task<IActionResult> UpdateAnAuthor([FromRoute] Guid id, [FromBody] AddAuthorDto updateDto)
        {
            //check to see if id or author name in body request is null


            if (!id.Equals("") || !updateDto.Equals(null)) return NotFound();

            var author = await authorService.UpdateAnAuthor(id, updateDto);

            if (author == null) return NotFound();

            return Ok(author);
            


        }


        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> DeleteAnAuthor([FromRoute] Guid id, [FromBody] AddAuthorDto updateDto)
        {
            if (!id.Equals("") || !updateDto.Equals(null)) return NotFound();

            var author = await authorService.DeleteAnAuthor(id, updateDto);

            if (author == null) return NotFound();

            return Ok(author);

        }
    }


    
}
