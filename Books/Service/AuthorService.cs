using AutoMapper;
using Books.Controllers;
using Books.Models.Domain;
using Books.Models.DTOs.AuthorsDto;
using Books.Reposistories;
using Microsoft.IdentityModel.Tokens;
using System.Text.Json;

namespace Books.Service
{
    public class AuthorService : IAuthorService
    {
        private readonly IAuthorRepositorycs authorRepository;
        private readonly IMapper mapper;
        private readonly ILogger<AuthController> logger;

        public AuthorService(IAuthorRepositorycs authorRepository, IMapper mapper, ILogger<AuthController> logger)
        {
            this.authorRepository = authorRepository;
            this.mapper = mapper;
            this.logger = logger;
        }

        public async Task<AuthorDto?> CreateAnAuthor(AddAuthorDto author)
        {
            var authorCreate = new Author { Name = author.Name };

            authorCreate = await authorRepository.CreateAnAuthor(authorCreate);

         

            if (authorCreate == null) return null;

            var authorDto = mapper.Map<AuthorDto>(authorCreate);

            System.Diagnostics.Debug.WriteLine("wokred =============== " + authorDto.Name + " "  + authorDto.Id);

            return authorDto;
        }

        public async Task<AuthorDto?> DeleteAnAuthor(Guid id, AddAuthorDto author)
        {
            var deleteAuthor  = new Author { Id = id, Name = author.Name };

            deleteAuthor = await authorRepository.DeleteAnAuthor(id, deleteAuthor);

            //var authorDto = new AuthorDto { Id = author.Id, Name = updateDto.Name };
            var authorDto = mapper.Map<AuthorDto>(deleteAuthor);

            return authorDto;

        }

        public async Task<List<AuthorDto>> GetAllAuthors()
        {

            var author = await authorRepository.GetAllAuthors();


            if (author == null) return null;

            var authorDto = mapper.Map<List<AuthorDto>>(author);

            //Return DTO
            return authorDto;
        }

        public async Task<AuthorDto?> GetAnAuthor(Guid id)
        {
            var author = await authorRepository.GetAnAuthor(id);

            if (author == null) return null;

            var authorDto = mapper.Map<AuthorDto>(author);

            return authorDto;
        }

        public async Task<AuthorDto> GetAnAuthorByName(string name)
        {
            var author = await authorRepository.GetAnAuthorByName(name);

            if (author == null) return null;

            var authorDto = mapper.Map<AuthorDto>(author);

            return authorDto;
        }

        public async Task<List<AuthorDto>?> GetAuthorsWithTopRatedBooks()
        {
            var authors = await authorRepository.GetAuthorsWithTopRatedBooks();

            return !authors.IsNullOrEmpty() ? mapper.Map<List<AuthorDto>>(authors) : null;
        }

        public async Task<List<AuthorDto>?> GetAuthorsWithMostRecentBooks()
        {
            var authors = await authorRepository.GetAuthorsWithMostRecentBooks();

            return !authors.IsNullOrEmpty() ? mapper.Map<List<AuthorDto>>(authors) : null;
        }


        public async Task<AuthorDto?> UpdateAnAuthor(Guid id, AddAuthorDto author)
        {

            var updateAuthor = mapper.Map<Author>(author);
            // Author by Id 
            updateAuthor = await authorRepository.UpdateAnAuthor(id, updateAuthor);

            if(updateAuthor == null) return null;

            var authorDto = mapper.Map<AuthorDto>(updateAuthor);

            return authorDto;

        }
    }
}
