using AutoMapper;
using Books.CustomActionFilters;
using Books.Models.Domain;
using Books.Models.DTOs;
using Books.Reposistories;
using Books.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static System.Reflection.Metadata.BlobBuilder;

namespace Books.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IBookService bookService;

        public BooksController(IMapper mapper, IBookService bookService)
        {
            this.mapper = mapper;
            this.bookService = bookService;
        }

        [HttpPost]
        [ValidateModel]
        [Authorize(Roles = "Writer")]
        public async Task<IActionResult> CreateABook([FromBody] CreateBookDto createBookDto)
        {

            //map dto to domain model books
            if (createBookDto == null) return NotFound();

            var book = await bookService.CreateABook(createBookDto);

            if (book == null) return NotFound("An Error occour creating your Book");

            var bookDto = mapper.Map<BookDto>(book);

            return Ok(bookDto);


        }

        [HttpGet]
        //[Authorize(Roles = "Reader")]
        public async Task<IActionResult> GetAllBooks(
                [FromQuery] string? filterOn, string? filteQuery,
                [FromQuery] string? sortBy, [FromQuery] bool isAscending,
                [FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 1000
            )
        {
            

            var books = await bookService.getAllBooks();

            if (books == null) return NotFound("No Books");

            return Ok(books);
        }

        [HttpGet]
        [Route("{id:Guid}")]
        //[Authorize(Roles = "Reader")]
        public async Task<IActionResult> GetByBookId([FromRoute] Guid id) 
        {
            if (id == null) return NotFound();

            var book = await bookService.GetBookById(id);

            if (book == null) return NotFound();
         

            return Ok(book);

        }

        [HttpPut]
        [Route("{id:Guid}")]
        [ValidateModel]
        [Authorize(Roles = "Writer")]
        public async Task<IActionResult> UpdateABook([FromRoute] Guid id, [FromBody] UpdateBookDto bookDto)
        {

            if(id == null || bookDto == null) return NotFound();

            var book = await bookService.UpdateABook(id, bookDto);

            
            if (book == null) return NotFound();

            return Ok(book);

        }


        [HttpDelete]
        [Route("{id:Guid}")]
        [Authorize(Roles = "Writer")]
        public async Task<IActionResult> DeleteABook([FromRoute] Guid id)
        {

            if (id == null) return NotFound();

            var book = await bookService.DeleteABook(id);

            if (book == null) return NotFound();

            return Ok(book);
        }

    }
}
