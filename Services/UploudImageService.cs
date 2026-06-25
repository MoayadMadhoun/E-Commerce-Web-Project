using System;

namespace MyStore.Services
{
    public class UploudImageService : IUploudService
    {
        private readonly IWebHostEnvironment _environment;
        private string[] allowedExtenstions = { ".jpg", ".jpeg", ".png", ".tif", ".gif" };
        private int fileSize = (1 * 1024 * 1024); // file size in byte  
        public static string accept = "image/*";

        private string basePath = "images";

        public UploudImageService(IWebHostEnvironment environment)
        {
            this._environment = environment;
        }
        public string UploudFile(IFormFile Upload, string subFolder="products")
        {
            string fileUrl = string.Empty;
            //validation
            if (Upload.Length > fileSize)
            {
                throw new Exception($"Allowed file size {fileSize / 1024 / 1024} MB");
            }

            if (!allowedExtenstions.Contains(Path.GetExtension(Upload.FileName)))
            {
                throw new Exception($"Allowed file type {string.Join(",", allowedExtenstions)} MB");
            }

            var fileName = Guid.NewGuid().ToString() + Path.GetExtension(Upload.FileName);
            var filePath = Path.Combine(_environment.WebRootPath, basePath, subFolder, fileName);
            using (var filesstream = System.IO.File.Create(filePath))
            {
                Upload.CopyTo(filesstream);
            }

            //fileUrl ="/"+ Path.Combine(basePath, fileName);
            fileUrl = $"{basePath}/{subFolder}/{fileName}";
            return fileUrl;
        }

    }
}
