using Books.Models.Domain;

namespace Books.Reposistories.ProgressRepository
{
    public interface IProgressRepository
    {
        Task<List<Progress>> GetAllProgress();

        Task<Progress?> GetAProgress(Guid id);
    }
}
