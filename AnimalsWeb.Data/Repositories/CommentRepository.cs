using AnimalsWeb.Data.Contexts;
using AnimalsWeb.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace AnimalsWeb.Data.Repositories
{
    public class CommentRepository : ICommentRepository
    {
        private readonly AnimalsWebSiteDbContext context;

        public CommentRepository(AnimalsWebSiteDbContext context)
        {
            this.context = context;
        }

        public async Task<Comment> AddAsync(Comment entity)
        {
            context.Comments.Add(entity);
            await context.SaveChangesAsync();
            return entity;
        }

        public async Task<Comment> DeleteAsync(int id)
        {
            var comment = await context.Comments
               .FirstOrDefaultAsync(a => a.CommentId == id);

            if (comment == null)
                return comment;

            context.Comments.Remove(comment);
            await context.SaveChangesAsync();
            return comment;
        }

        public async Task<IEnumerable<Comment>> GetAllAsync()
        {
            return await context.Comments.Include(c => c.Animal).ToListAsync();
        }

        public Task<Comment> GetByIdAsync(int id)
        {
            return context.Comments
                .Include(c => c.Animal)
                .FirstOrDefaultAsync(c => c.CommentId == id)!;
        }

        public async Task<Comment> UpdateAsync(Comment entity)
        {
            context.Comments.Update(entity);
            await context.SaveChangesAsync();

            return entity;
        }
    }
}
