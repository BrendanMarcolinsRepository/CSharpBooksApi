using Books.Data;
using Books.Models.Domain;
using Books.Models.DTOs;
using Microsoft.EntityFrameworkCore;


namespace Books.Reposistories
{
    public class PostGresAuthorRepository : IAuthorRepositorycs
    {

        private readonly BooksDbContext dbContext;

        public PostGresAuthorRepository(BooksDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Author> CreateAnAuthor(Author author)
        {
            await dbContext.Authors.AddAsync(author);
            await dbContext.SaveChangesAsync();
            return author;
        }

        public async Task<Author?> DeleteAnAuthor(Guid id, Author author)
        {
            // Author by Id 
            var authorCurrentId = await GetAnAuthor(id);
            var authorCurrentName = await GetAnAuthorByName(author.Name);

            //check to see if author is null
            if (authorCurrentId != null && authorCurrentId != null)
            {

                dbContext.Authors.Remove(author);
                await dbContext.SaveChangesAsync();

                return author;

               

            }

            return null;
        }

        public async Task<List<Author>> GetAllAuthors()
        {

            //get data from database = domain model

            var author = await dbContext.Authors.ToListAsync();
            return author;
           
        }

        public async Task<Author?> GetAnAuthor(Guid id)
        {
            var author = await dbContext.Authors.FirstOrDefaultAsync(_author => _author.Id == id);
            return author;
        }

        public async Task<Author?> GetAnAuthorByName(string name)
        {
            var author = await dbContext.Authors.FirstOrDefaultAsync(_author => _author.Name == name);
            return author;
        }

        public async Task<Author?> UpdateAnAuthor(Guid id, Author author)
        {
            var authorCurrentDetails = await GetAnAuthor(id);

            //check to see if author is null
            if (author != null && authorCurrentDetails != null)
            {
                //update author and save changes in the database
                authorCurrentDetails.Name = author.Name;


                await dbContext.SaveChangesAsync();


                return authorCurrentDetails;

            }

            return null;
        }
    }
}
