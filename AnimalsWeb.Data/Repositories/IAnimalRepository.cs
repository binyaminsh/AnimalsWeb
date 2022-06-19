using AnimalsWeb.Data.Models;

namespace AnimalsWeb.Data.Repositories
{
    public interface IAnimalRepository : IRepository<Animal>
    {
        Task<IEnumerable<Animal>> GetPoppularAnimalsAsync(int count);
        Task<IEnumerable<Animal>> GetAnimalsByCategoryAsync(string categoryName);
        Task<IEnumerable<Animal>> GetAnimalsByNameAsync(string name);
        Task AnimalsRemoveRangeAsync(IEnumerable<Animal> animals);
    }
}
