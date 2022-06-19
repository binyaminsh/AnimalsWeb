using AnimalsWeb.Data.Contexts;
using AnimalsWeb.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace AnimalsWeb.Data.Repositories
{
    public class AnimalRepository : IAnimalRepository
    {
        private readonly AnimalsWebSiteDbContext context;

        public AnimalRepository(AnimalsWebSiteDbContext context)
        {
            this.context = context;
        }

        public async Task<Animal> AddAsync(Animal entity)
        {
            context.Animals.Add(entity);
            await context.SaveChangesAsync();

            return entity;
        }

        public async Task<Animal> DeleteAsync(int id)
        {
            var animal = await context.Animals
                .FirstOrDefaultAsync(a => a.AnimalId == id);

            if (animal == null)
                return animal;

            context.Animals.Remove(animal);
            await context.SaveChangesAsync();
            return animal;
        }

        public Task<Animal> GetByIdAsync(int id)
        {
            return context.Animals
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.AnimalId == id)!;
        }

        public async Task<IEnumerable<Animal>> GetAllAsync()
        {
            return await context.Animals
                  .AsNoTracking()
                  .ToListAsync();
        }

        public async Task<Animal> UpdateAsync(Animal entity)
        {
            context.Animals.Update(entity);
            
            await context.SaveChangesAsync();

            return entity;
        }

        public async Task<IEnumerable<Animal>> GetPoppularAnimalsAsync(int count)
        {
            return await context.Animals
                  .AsNoTracking()
                  .OrderByDescending(a => a.Comments.Count).Take(count)
                  .ToListAsync();
        }

        public async Task<IEnumerable<Animal>> GetAnimalsByNameAsync(string name)
        {
            return await context.Animals
                .AsNoTracking()
                .Where(a => a.Name.Contains(name.ToUpper()))
                .ToListAsync();
        }

        public async Task<IEnumerable<Animal>> GetAnimalsByCategoryAsync(string categoryName)
        {
            return await context.Animals
                .AsNoTracking()
                .Where(a => a.Category.Name == categoryName)
                .ToListAsync();
        }

        public async Task AnimalsRemoveRangeAsync(IEnumerable<Animal> animals)
        {
            context.Animals.RemoveRange(animals);
            await context.SaveChangesAsync();
        }
    }
}
