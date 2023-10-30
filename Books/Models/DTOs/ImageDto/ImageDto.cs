namespace Books.Models.DTOs.ImageDto
{
    public class ImageDto
    {
        public IFormFile File { get; set; }

        public string FileName { get; set; }

        public string? FileDescription { get; set; }

        public string? FileExtension { get; set; }

        public long? FileSizeInBytes { get; set; }

        public string? FilePath { get; set; }
    }
}
