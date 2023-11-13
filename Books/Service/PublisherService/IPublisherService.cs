using Books.Models.DTOs.GenresDto;
using Books.Models.DTOs.PublishersDto;

namespace Books.Service.PublisherService
{
    public interface IPublisherService
    {
        Task<List<PublisherDto>> GetAllPublisher();

        Task<PublisherDto?> GetAPublisherById(Guid id);

        Task<PublisherDto> GetAPublisherByName(string name);

        Task<PublisherDto?> CreateAPublisher(GeneralPublisherDto generalPublisherDto);


        Task<PublisherDto?> UpdateAPublisher(Guid id, GeneralPublisherDto generalPublisherDto);

        Task<PublisherDto?> DeleteAPublisher(Guid id, GeneralPublisherDto generalPublisherDto);
    }
}
