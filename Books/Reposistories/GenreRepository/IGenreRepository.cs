using Books.Models.Domain;

namespace Books.Reposistories.GenreRepository
{
    public interface IGenreRepository
    {
        Task<List<Genre>> GetAllGenres();

        Task<Genre?> GetAGenreById(Guid id);

        Task<Genre> GetAGenreByName(String name);

        Task<Genre?> CreateAGenre(Genre genre);


        Task<Genre?> UpdateAGenre(Guid id, Genre genre);

        Task<Genre?> DeleteAGenre(Guid id, Genre genre);
    }
}
