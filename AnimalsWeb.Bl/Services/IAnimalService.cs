using AnimalsWeb.Data.Models;
using Microsoft.AspNetCore.Http;

namespace AnimalsWeb.Bl.Services
{
    public interface IAnimalService
    {
        Task<Animal> GetByIdAsync(int id);
        Task<IEnumerable<Animal>> GetAnimalsByNameAsync(string name);
        Task<Animal> DeleteAsync(int id);
        Task<IEnumerable<Animal>> GetAllAnimalsAsync();
        Task<IEnumerable<Animal>> GetPoppularAnimalsAsync(int count);
        Task<Animal> AddAsync(Animal animal, IFormFile file);
        Task<IEnumerable<Animal>> GetAllByCategoryAsync(string categoryName);
        Task<Animal> UpdateAsync(Animal animal, IFormFile file);
    }
}
