using Books.Models.Domain;


namespace Books.Reposistories
{
    public interface IImageRepository
    {
        Task<Image> UploadImage(Image image);
    }
}
