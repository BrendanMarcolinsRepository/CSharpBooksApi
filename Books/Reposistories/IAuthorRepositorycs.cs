using Books.Models.Domain;
using Books.Models.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace Books.Reposistories
{
    public interface IAuthorRepositorycs
    {
        Task<List<Author>> GetAllAuthors();

        Task<List<Author>> GetAuthorsWithTopRatedBooks();

        Task<List<Author>> GetAuthorsWithMostRecentBooks();

        Task<Author?> GetAnAuthor(Guid id);

        Task<Author> GetAnAuthorByName(String name);

        Task<Author?> CreateAnAuthor(Author author);


        Task<Author?> UpdateAnAuthor(Guid id, Author author);

        Task<Author?> DeleteAnAuthor(Guid id, Author author);
    }
}
