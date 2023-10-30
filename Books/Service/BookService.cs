using AutoMapper;
using Books.Models.Domain;
using Books.Models.DTOs;
using Books.Reposistories;

namespace Books.Service
{
    public class BookService : IBookService
    {
        private readonly IBookRepository bookRepository;
        private readonly IMapper mapper;

        public BookService(IBookRepository bookRepository, IMapper mapper)
        {
            this.bookRepository = bookRepository;
            this.mapper = mapper;
        }

        public async Task<BookDto> CreateABook(CreateBookDto createBookDto)
        {
            var book = mapper.Map<Book>(createBookDto);

            var bookResponse= await bookRepository.createABook(book);

            if (bookResponse == null) return null;

            var bookDto = mapper.Map<BookDto>(bookResponse);

            return bookDto;
        }

        public async Task<BookDto?> DeleteABook(Guid id)
        {


            var book = await bookRepository.DeleteABook(id);

            if(book == null) return null;

            var bookDto = mapper.Map<BookDto>(book);

            return bookDto;
        }

       

        public async Task<List<BookDto>> getAllBooks(string? filterOn = null, string? filterQuery = null, string? sortBy = null, bool isAscending = true, int pageNumber = 1, int pageSize = 200)
        {
            var book = await bookRepository.getAllBooks(filterOn, filterQuery, sortBy, isAscending, pageNumber, pageSize);

            if (book == null) return null;

            var bookDto = mapper.Map<List<BookDto>>(book);

            return bookDto;
        }

        public async Task<BookDto?> GetBookById(Guid id)
        {

            var book = await bookRepository.getBookById(id);

            if (book == null) return null;

            var bookDto = mapper.Map<BookDto>(book);

            return bookDto;


        }

        public async Task<BookDto?> UpdateABook(Guid id, UpdateBookDto updateBookDto)
        {
            var book = mapper.Map<Book>(updateBookDto);

            book = await bookRepository.updateABook(id, book);

            if (book == null) return null;

            var bookDto = mapper.Map<BookDto>(book);

            return bookDto;
        }
    }
}
