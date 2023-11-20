using AutoMapper;
using Books.Models.Domain;
using Books.Models.DTOs;
using Books.Models.DTOs;
using Books.Reposistories;

namespace Books.Service
{
    public class ImageService : IImageService
    {
        private readonly double MEGABYTE = 10485760; //10 mg in bytes
        private readonly string[] ALLOWEDEXTENSIONS = new string[] { ".jpg", ".jpeg", ".png" };
        private readonly IMapper mapper;
        private readonly IImageRepository imageRepository;

        public ImageService(IMapper mapper, IImageRepository imageRepository)
        {
            this.mapper = mapper;
            this.imageRepository = imageRepository;
        }

        public async Task<ImageDto> UploadImage(ImageUploadRequestDto imageDtoRequest)
        {

            if (
                    imageDtoRequest == null ||
                    !ALLOWEDEXTENSIONS.Contains(Path.GetExtension(imageDtoRequest.File.FileName)) ||
                    imageDtoRequest.File.Length > MEGABYTE
                )
            {
                return null;
            }


            var image = new Image
            {
                File = imageDtoRequest.File,
                FileExtension = Path.GetExtension(imageDtoRequest.File.FileName),
                FileSizeInBytes = imageDtoRequest.File.Length,
                FileName = imageDtoRequest.FileName,
                FileDescription = imageDtoRequest.FileDescription
            };

           await imageRepository.UploadImage(image);


            var imageDto = mapper.Map<ImageDto>(image);

            return imageDto;


        }
    }
}
