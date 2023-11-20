using Books.Models.Domain;
using Microsoft.AspNetCore.Mvc;

namespace Books.Reposistories
{
    public interface IBookRepository
    {
        Task <Book> createABook(Book book);
        Task<List<Book>> getAllBooks(
                string? filterOn = null, string? filterQuery = null,
                string? sortBy = null,  bool isAscending = true,
                int pageNumber = 1, int pageSize = 200
            );

        Task<Book?> getBookById(Guid id);

        Task<Book?> updateABook(Guid id, Book book);

        Task<Book?> DeleteABook(Guid id);

        Task<List<Book>> GetRecentBooks();

        Task<List<Book>> GetPopularBooks();
    }
}
