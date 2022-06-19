using AnimalsWeb.Data.Models;
using Microsoft.AspNetCore.Http;

namespace AnimalsWeb.Bl.Services
{
    public interface IFileService
    {
        Task<(bool isSuccess, string fileName)> UploadFile(IFormFile file);
        void DeleteFile(Animal animal);
    }
}
