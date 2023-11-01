using Books.Models.DTOs.DifficultiesDto;
using Books.Models.DTOs.GenresDto;

namespace Books.Service.GenreService
{
    public interface IGenreService
    {
        Task<List<GenreDto>> GetAllGenre();

        Task<GenreDto?> GetAGenreById(Guid id);

        Task<GenreDto> GetAGenreByName(string name);

        Task<GenreDto?> CreateAGenre(AddDeleteUpdateGenreDto generalGenreDto);


        Task<GenreDto?> UpdateAGenre(Guid id, AddDeleteUpdateGenreDto generalGenreDto);

        Task<GenreDto?> DeleteAGenre(Guid id, AddDeleteUpdateGenreDto generalGenreDto);
    }
}
