using AnimalsWeb.Data.Models;

namespace AnimalsWeb.Bl.Services
{
    public interface ICategoryService
    {
        Task<Category> GetByIdAsync(int id);
        Task<IEnumerable<Category>> GetAllCategoriesAsync();
        Task<Category> AddAsync(Category category);
        Task<Category> DeleteAsync(int id);
    }
}
