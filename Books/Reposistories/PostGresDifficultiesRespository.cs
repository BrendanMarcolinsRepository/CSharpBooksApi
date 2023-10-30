using Books.Data;
using Books.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace Books.Reposistories
{
    public class PostGresDifficultiesRespository : IDifficultiesRepository
    {
        private readonly BooksDbContext dbContext;

        public PostGresDifficultiesRespository(BooksDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Difficulty?> CreateADifficulty(Difficulty difficulty)
        {
            await dbContext.Difficulties.AddAsync(difficulty);
            await dbContext.SaveChangesAsync();
            return difficulty;
        }

        public async Task<Difficulty?> DeleteADifficulty(Guid id, Difficulty difficulty)
        {
            // Author by Id 
            var difficultyCurrentId = await GetADifficultyById(id);
            var difficultyCurrentName = await GetADifficultyByName(difficulty.Name);

            //check to see if author is null
            if (difficultyCurrentId != null && difficultyCurrentName != null)
            {

                dbContext.Difficulties.Remove(difficulty);
                await dbContext.SaveChangesAsync();

                return difficulty;

            }

            return null; 
        }

        public async Task<Difficulty> GetADifficultyByName(string name)
        {
            var difficulty = await dbContext.Difficulties.FirstOrDefaultAsync(_difficulty => _difficulty.Name == name);
            return difficulty;
        }

        public async Task<Difficulty?> GetADifficultyById(Guid id)
        {
            var difficulty = await dbContext.Difficulties.FirstOrDefaultAsync(_difficulty => _difficulty.Id == id);
            return difficulty;
        }

        public async Task<List<Difficulty>> GetAllDifficulties()
        {
            //get data from database = domain model
            var difficulties = await dbContext.Difficulties.ToListAsync();
            return difficulties;
        }

        public async Task<Difficulty?> UpdateADifficulty(Guid id, Difficulty difficulty)
        {
            var difficultyCurrentDetails = await GetADifficultyById(id);

            //check to see if author is null
            if (difficulty != null && difficultyCurrentDetails != null)
            {
                //update author and save changes in the database
                difficultyCurrentDetails.Name = difficulty.Name;


                await dbContext.SaveChangesAsync();


                return difficultyCurrentDetails;

            }

            return null;
        }
    }
}
