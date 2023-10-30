using Books.Models.Domain;
using Books.Models.DTOs.ImageDto;

namespace Books.Reposistories
{
    public interface IImageRepository
    {
        Task<Image> UploadImage(Image image);
    }
}
