using Books.Models.Domain;
using Books.Models.DTOs.DifficultiesDto;

namespace Books.Service
{
    public interface IDifficultiesService
    {
        Task<List<DifficultyDto>> GetAllDifficulties();

        Task<DifficultyDto?> GetADifficultyById(Guid id);

        Task<DifficultyDto> GetADifficultyByName(String name);

        Task<DifficultyDto?> CreateADifficulty(AddDifficultyDto difficulty);


        Task<DifficultyDto?> UpdateADifficulty(Guid id, AddDifficultyDto difficulty);

        Task<DifficultyDto?> DeleteADifficulty(Guid id, AddDifficultyDto difficulty);
    }
}
