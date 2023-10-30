using Books.Models.Domain;
using Books.Models.DTOs.ImageDto;
using Microsoft.AspNetCore.Mvc;

namespace Books.Service
{
    public interface IImageService
    {
        Task<ImageDto> UploadImage(ImageUploadRequestDto imageDto);
    }
}
