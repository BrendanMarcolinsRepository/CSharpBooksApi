using Books.Data;
using Books.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace Books.Reposistories.GenreRepository
{
    public class PostGresGenreRepository : IGenreRepository
    {
        private readonly BooksDbContext dbContext;

        public PostGresGenreRepository(BooksDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Genre?> CreateAGenre(Genre genre)
        {
            await dbContext.AddAsync<Genre>(genre);
          

            var result = dbContext.SaveChangesAsync().IsCompletedSuccessfully;

            if (!result)
            {
                return null;
            }

           return genre;


        }

        public async Task<Genre?> DeleteAGenre(Guid id, Genre genre)
        {
            var genreCurrentDetails = await GetAGenreById(id);

            if (genreCurrentDetails == null)
            {
                return null;
            }

            dbContext.Remove(genreCurrentDetails);

            var result = dbContext.SaveChangesAsync().IsCompletedSuccessfully;

            if (!result)
            {
                return null;
            }


            return genre;
        }

        public async Task<Genre?> GetAGenreById(Guid id)
        {
            var genreId = await dbContext.Genres.FirstOrDefaultAsync(x => x.Id ==  id);

            if (genreId == null)
            {
                return null;
            }


            return genreId;

        }

        public async Task<Genre> GetAGenreByName(string name)
        {
            var genreName = await dbContext.Genres.FirstOrDefaultAsync(x => string.Equals(name, x.Name));
            return genreName == null ? null : genreName;
        }

        public async Task<List<Genre>> GetAllGenres()
        {
            var genres = await dbContext.Genres.ToListAsync();

            return genres == null ? new List<Genre>() : genres;
        }

        public async Task<Genre?> UpdateAGenre(Guid id, Genre genre)
        {
         
            var genreCurrentDetails = await GetAGenreById(id);

            if(genreCurrentDetails == null) 
            {
                return null;
            }

            genreCurrentDetails.Name = genre.Name;

             var result = dbContext.SaveChangesAsync().IsCompletedSuccessfully;

            if(!result) 
            {
                return null;
            }


            return genre;
            
            
           
        }
    }
}
