
using System;

namespace BlogASP.Data.FileManager
{
    public class FileManager : IFileManager
    {
        private readonly string imagePath;

        public FileManager(IConfiguration config)
        {
            imagePath = config.GetValue<string>("Path:Image");
        }

        public FileStream ImageStream(string image)
        {
            //using (var fileStream = new FileStream(Path.Combine(imagePath, image), FileMode.Open, FileAccess.Read))
            //{
            //    await image.CopyToAsync(fileStream);
            //}
            return new FileStream(Path.Combine(imagePath, image), FileMode.Open, FileAccess.Read);
        }

        public async Task<string> SaveImage(IFormFile image)
        {
            var dataTimePath = DateTime.Now.ToString("yyyy_MM");
            var saveRoot = Path.Combine(imagePath, dataTimePath);
            if (!Directory.Exists(saveRoot))
                Directory.CreateDirectory(saveRoot);

            var fileName = $"img_{DateTime.Now.ToString("dd_HH_mm_ss_")}{image.FileName}";

            var filePath = Path.Combine(saveRoot, fileName);

            if (File.Exists(filePath))
            {
                Console.WriteLine($"{nameof(SaveImage)} error,file exist! path:{filePath}");
            }

            using (var fileStream = new FileStream(filePath, FileMode.Create, FileAccess.Write))
            {
                await image.CopyToAsync(fileStream);
            }

            return Path.Combine(dataTimePath, fileName);
        }
    }
}
