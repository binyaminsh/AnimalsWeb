using AnimalsWeb.Data.Models;
using AnimalsWeb.Data.Repositories;

namespace AnimalsWeb.Bl.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository repository;
        private readonly IFileService fileService;

        public CategoryService(ICategoryRepository repository, IFileService fileService)
        {
            this.repository = repository;
            this.fileService = fileService;
        }

        public Task<Category> GetByIdAsync(int id) => repository.GetByIdAsync(id);

        public Task<IEnumerable<Category>> GetAllCategoriesAsync() => repository.GetAllAsync();

        public Task<Category> AddAsync(Category category) => repository.AddAsync(category);

        public async Task<Category> DeleteAsync(int id)
        {
            var category = await repository.DeleteAsync(id);
            if (category.Animals != null && category.Animals.Count > 0)
            {
                category.Animals.ToList().ForEach(animal =>
                    fileService.DeleteFile(animal));
            }

            return category;
        }
    }
}
