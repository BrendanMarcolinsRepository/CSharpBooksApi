using Books.Models.Domain;
using Books.Models.DTOs.AuthorsDto;

namespace Books.Service
{
    public interface IAuthorService
    {
        Task<List<AuthorDto>> GetAllAuthors();

        Task<List<AuthorDto>?> GetAuthorsWithTopRatedBooks();

        Task<List<AuthorDto>?> GetAuthorsWithMostRecentBooks();

        Task<AuthorDto?> GetAnAuthor(Guid id);

        Task<AuthorDto> GetAnAuthorByName(String name);

        Task<AuthorDto?> CreateAnAuthor(AddAuthorDto author);


        Task<AuthorDto?> UpdateAnAuthor(Guid id, AddAuthorDto author);

        Task<AuthorDto?> DeleteAnAuthor(Guid id, AddAuthorDto author);
    }
}
