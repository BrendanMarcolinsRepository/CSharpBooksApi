using Books.Models.Domain;
using Books.Models.DTOs;

namespace Books.Service
{
    public interface IBookService
    {
        Task<BookDto> CreateABook(CreateBookDto createBookDto);
        Task<List<BookDto>> getAllBooks(
                string? filterOn = null, string? filterQuery = null,
                string? sortBy = null, bool isAscending = true,
                int pageNumber = 1, int pageSize = 200
            );

        Task<BookDto?> GetBookById(Guid id);

        Task<BookDto?> UpdateABook(Guid id, UpdateBookDto updateBookDto);

        Task<BookDto?> DeleteABook(Guid id);

        Task<List<BookDto>> GetRecentBooks();

        Task<List<BookDto>> GetPopularBooks();
    }
}
