using AutoMapper;
using Books.Models.Domain;
using Books.Models.DTOs.DifficultiesDto;
using Books.Reposistories;

namespace Books.Service
{
    public class DifficultiesService : IDifficultiesService
    {
        private readonly IDifficultiesRepository difficultiesRepository;
        private readonly IMapper mapper;

        public DifficultiesService(IDifficultiesRepository difficultiesRepository, IMapper mapper)
        {
            this.difficultiesRepository = difficultiesRepository;
            this.mapper = mapper;
        }


        public async Task<DifficultyDto?> CreateADifficulty(AddDifficultyDto difficulty)
        {
            var difficult = mapper.Map<Difficulty>(difficulty);

            var difficulties = await difficultiesRepository.CreateADifficulty(difficult);

            if (difficulties == null) return null;

            var difficultyDto = mapper.Map<DifficultyDto>(difficulties);

            return difficultyDto;

        }

        public async Task<DifficultyDto?> DeleteADifficulty(Guid id, AddDifficultyDto difficulty)
        {
            var difficult = new Difficulty { Id = id, Name = difficulty.Name };

            var difficulties = await difficultiesRepository.DeleteADifficulty(id, difficult);

            if (difficulties == null) return null;

            //var authorDto = new AuthorDto { Id = author.Id, Name = updateDto.Name };
            var authorDto = mapper.Map<DifficultyDto>(difficulties);

            return authorDto;
        }

        public async Task<DifficultyDto?> GetADifficultyById(Guid id)
        {
            var difficulty = await difficultiesRepository.GetADifficultyById(id);

            if (difficulty == null) return null;

            var difficultiesDto = mapper.Map<DifficultyDto>(difficulty);

            return difficultiesDto;

        }

        public async Task<DifficultyDto> GetADifficultyByName(string name)
        {
            var difficulty = await difficultiesRepository.GetADifficultyByName(name);

            if (difficulty == null) return null;

            var difficultiesDto = mapper.Map<DifficultyDto>(difficulty);

            return difficultiesDto;
        }

        public async Task<List<DifficultyDto>> GetAllDifficulties()
        {
            var difficulties = await difficultiesRepository.GetAllDifficulties();

            if (difficulties == null) return null;

            var difficultiesDto = mapper.Map<List<DifficultyDto>>(difficulties);

            return difficultiesDto;
        }

        public async Task<DifficultyDto?> UpdateADifficulty(Guid id, AddDifficultyDto difficulty)
        {
            //var author = new Author { Id = id, Name = updateDto.Name };
            var difficult = mapper.Map<Difficulty>(difficulty);
            // Author by Id 
            var difficulties = await difficultiesRepository.UpdateADifficulty(id, difficult);

            if(difficulties == null) return null;

            var difficultyDto = mapper.Map<DifficultyDto>(difficulties);

            return difficultyDto;
        }
    }
}
