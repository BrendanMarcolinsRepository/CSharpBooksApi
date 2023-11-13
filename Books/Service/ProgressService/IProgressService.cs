using Books.Models.DTOs.ProgressDto;

namespace Books.Service.ProgressService
{
    public interface IProgressService
    {
        Task<List<ProgressDto>> GetAllProgress();

        Task<ProgressDto?> GetAProgress(Guid id);
    }
}
