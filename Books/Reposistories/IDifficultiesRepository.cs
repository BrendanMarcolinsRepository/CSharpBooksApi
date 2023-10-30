using Books.Models.Domain;

namespace Books.Reposistories
{
    public interface IDifficultiesRepository
    {
        Task<List<Difficulty>> GetAllDifficulties();

        Task<Difficulty?> GetADifficultyById(Guid id);

        Task<Difficulty> GetADifficultyByName(String name);

        Task<Difficulty?> CreateADifficulty(Difficulty difficulty);


        Task<Difficulty?> UpdateADifficulty(Guid id, Difficulty difficulty);

        Task<Difficulty?> DeleteADifficulty(Guid id, Difficulty difficulty);
    }
}
