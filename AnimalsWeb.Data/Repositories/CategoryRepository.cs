using AnimalsWeb.Data.Contexts;
using AnimalsWeb.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace AnimalsWeb.Data.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly AnimalsWebSiteDbContext context;

        public CategoryRepository(AnimalsWebSiteDbContext context)
        {
            this.context = context;
        }

        public async Task<Category> AddAsync(Category entity)
        {
            context.Categories.Add(entity);
            await context.SaveChangesAsync();

            return entity;
        }

        public async Task<Category> DeleteAsync(int id)
        {
            var category = await context.Categories
                .Include(c => c.Animals)
                .FirstOrDefaultAsync(a => a.CategoryId == id);

            if (category == null)
                return category;
            
            context.Categories.Remove(category);
            await context.SaveChangesAsync();
            return category;
        }

        public async Task<IEnumerable<Category>> GetAllAsync()
        {
            return await context.Categories.OrderBy(c => c.Name).ToListAsync();
        }

        public Task<Category> GetByIdAsync(int id)
        {
            return context.Categories.Include(c => c.Animals).FirstOrDefaultAsync(c => c.CategoryId == id)!;
        }

        public async Task<Category> UpdateAsync(Category entity)
        {
            context.Categories.Update(entity);
            await context.SaveChangesAsync();

            return entity;
        }
    }
}
