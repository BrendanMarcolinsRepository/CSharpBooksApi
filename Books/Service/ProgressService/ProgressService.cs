using AutoMapper;
using Books.Models.DTOs.ProgressDto;
using Books.Models.DTOs.PublishersDto;
using Books.Reposistories.ProgressRepository;
using Books.Reposistories.PublisherRepository;

namespace Books.Service.ProgressService
{
    public class ProgressService : IProgressService
    {
        private readonly IMapper mapper;
        private readonly IProgressRepository progressRepository;

        public ProgressService(IMapper mapper, IProgressRepository progressRepository)
        {
            this.mapper = mapper;
            this.progressRepository = progressRepository;
        }

        public async Task<List<ProgressDto>> GetAllProgress()
        {
            var progress = await progressRepository.GetAllProgress();

            if (progress == null) { return null; }

            var progressDto = mapper.Map<List<ProgressDto>>(progress);

            return progressDto;
        }

        public async Task<ProgressDto?> GetAProgress(Guid id)
        {
            var progress = await progressRepository.GetAProgress(id);

            return progress == null ? null : mapper.Map<ProgressDto>(progress);
        }
    }
}
