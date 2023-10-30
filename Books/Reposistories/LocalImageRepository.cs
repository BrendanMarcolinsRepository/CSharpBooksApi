using Books.Controllers;
using Books.Data;
using Books.Models.Domain;

namespace Books.Reposistories
{
    public class LocalImageRepository : IImageRepository
    {
        private readonly IWebHostEnvironment webHost;
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly BooksDbContext dbContext;
        private readonly ILogger<LocalImageRepository> logger;

        public LocalImageRepository(IWebHostEnvironment webHost, IHttpContextAccessor httpContextAccessor, BooksDbContext dbContext, ILogger<LocalImageRepository> logger)
        {
            this.webHost = webHost;
            this.httpContextAccessor = httpContextAccessor;
            this.dbContext = dbContext;
            this.logger = logger;
        }

        public async Task<Image> UploadImage(Image image)
        {

            logger.LogInformation($"Logging image file extension ==  {image.FileExtension}");

            var localFilePath = Path.Combine(webHost.ContentRootPath, "Images");

            logger.LogInformation($"Logging image localfile extension ==  {localFilePath} image size ==  {image.FileSizeInBytes}");

            using var stream = new FileStream(localFilePath, FileMode.Create);
            await image.File.CopyToAsync(stream);

            var urlFilePath = $"{httpContextAccessor.HttpContext.Request.Scheme}://{httpContextAccessor.HttpContext.Request.Host}{httpContextAccessor.HttpContext.Request.PathBase}/Images/{image.FileName}{image.FileExtension}";

            image.FilePath = urlFilePath;

            await dbContext.Images.AddAsync(image);
            await dbContext.SaveChangesAsync();

            return image;




        }
    }
}
