using AnimalsWeb.Data.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace AnimalsWeb.Bl.Services
{
    public class FileService : IFileService
    {
        private readonly IHostingEnvironment environment;

        public FileService(IHostingEnvironment environment)
        {
            this.environment = environment;
        }

        public void DeleteFile(Animal animal)
        {
            var fullPath = Path.Combine(environment.WebRootPath, "Images", animal.PhotoUrl!);
            if (File.Exists(fullPath))
            {
                File.Delete(fullPath);
            }
        }

        public async Task<(bool isSuccess, string fileName)> UploadFile(IFormFile file)
        {
            if (file != null && file.Length > 0)
            {
                if (Path.GetExtension(file.FileName.ToLower()) is ".jpeg" or ".webp" or ".png" or ".jpg")
                {
                    var filename = $"{Guid.NewGuid()}{file.FileName}";
                    var fullPath = Path.Combine(environment.WebRootPath, "Images", filename);
                    using (var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                    }

                    return (true, filename);

                }

            }
            return (false, String.Empty);
        }
    }
}
