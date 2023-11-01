using AutoMapper;
using Books.Models.Domain;
using Books.Models.DTOs.GenresDto;
using Books.Reposistories.GenreRepository;

namespace Books.Service.GenreService
{
    public class GenreService : IGenreService
    {
        private readonly IGenreRepository genreRepository;
        private readonly IMapper mapper;

        public GenreService(IGenreRepository genreRepository, IMapper mapper )
        {
            this.genreRepository = genreRepository;
            this.mapper = mapper;
        }

        public async Task<GenreDto?> CreateAGenre(AddDeleteUpdateGenreDto generalGenreDto)
        {
            var genre = mapper.Map<Genre>(generalGenreDto);

            genre = await genreRepository.CreateAGenre(genre);

            if (genre == null) return null;

            var generalDto = mapper.Map<GenreDto>(genre);

            return generalDto;
        }

        public async Task<GenreDto?> DeleteAGenre(Guid id, AddDeleteUpdateGenreDto generalGenreDto)
        {
            var genre = mapper.Map<Genre>(generalGenreDto);

            genre = await genreRepository.DeleteAGenre(id,genre);

            if (genre == null) return null;

            var generalDto = mapper.Map<GenreDto>(genre);

            return generalDto;
        }

        public async Task<GenreDto?> GetAGenreById(Guid id)
        {
            var genre = await genreRepository.GetAGenreById(id);

            if (genre == null) return null;

            var generalDto = mapper.Map<GenreDto>(genre);

            return generalDto;
        }

        public async Task<GenreDto> GetAGenreByName(string name)
        {
            var genre = await genreRepository.GetAGenreByName(name);

            if (genre == null) return null;

            var generalDto = mapper.Map<GenreDto>(genre);

            return generalDto;
        }

        public async Task<List<GenreDto>> GetAllGenre()
        {
            var genres = await genreRepository.GetAllGenres();

            var generalDto = mapper.Map<List<GenreDto>>(genres);

            return generalDto;
        }


        public async Task<GenreDto?> UpdateAGenre(Guid id, AddDeleteUpdateGenreDto generalGenreDto)
        {
            var genre = mapper.Map<Genre>(generalGenreDto);

            genre = await genreRepository.UpdateAGenre(id, genre);

            if (genre == null) return null;

            var generalDto = mapper.Map<GenreDto>(genre);

            return generalDto;
        }
    }
}
