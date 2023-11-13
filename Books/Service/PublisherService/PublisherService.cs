using AutoMapper;
using Books.Models.Domain;
using Books.Models.DTOs.PublishersDto;
using Books.Reposistories.PublisherRepository;

namespace Books.Service.PublisherService
{
    public class PublisherService : IPublisherService
    {
        private readonly IMapper mapper;
        private readonly IPublisherRepository publisherRepository;

        public PublisherService(IMapper mapper, IPublisherRepository publisherRepository)
        {
            this.mapper = mapper;
            this.publisherRepository = publisherRepository;
        }

        public async Task<PublisherDto?> CreateAPublisher(GeneralPublisherDto generalPublisherDto)
        {
            var publisher = mapper.Map<Publisher>(generalPublisherDto);

            publisher = await publisherRepository.CreateAPublisher(publisher);

            if(publisher == null) 
            {
                return null;
            }

            var publiisherDto = mapper.Map<PublisherDto>(publisher);

            return publiisherDto;
        }

        public async Task<PublisherDto?> DeleteAPublisher(Guid id, GeneralPublisherDto generalPublisherDto)
        {
            var publisher = mapper.Map<Publisher>(generalPublisherDto);

            publisher  = await publisherRepository.DeleteAPublisher(id , publisher);

            if(publisher == null) { return null; }

            var publisherDto = mapper.Map<PublisherDto>(publisher);

            return publisherDto;


        }

        public async Task<List<PublisherDto>> GetAllPublisher()
        {
            var publishers = await publisherRepository.GetAllPublishers();

            if (publishers == null) { return null; }

            var publisherDto = mapper.Map<List<PublisherDto>>(publishers);

            return publisherDto;

        }

        public async Task<PublisherDto?> GetAPublisherById(Guid id)
        {
            var publisher =  await publisherRepository.GetAnPublisher(id);
        
            return publisher == null ? null : mapper.Map<PublisherDto>(publisher);
            
        }

        public async Task<PublisherDto> GetAPublisherByName(string name)
        {
            var publisher = await publisherRepository.GetAPublisherByName(name);

            return mapper?.Map<PublisherDto>(publisher) ?? null;
        }

        public async Task<PublisherDto?> UpdateAPublisher(Guid id, GeneralPublisherDto generalPublisherDto)
        {
            var publisher = mapper.Map<Publisher>(generalPublisherDto);

            publisher = await publisherRepository.UpdateAPublisher(id, publisher);

            return mapper?.Map<PublisherDto>(publisher) ?? null;
        }
    }
}
