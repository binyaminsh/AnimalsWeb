using AnimalsWeb.Data.Models;

namespace AnimalsWeb.Bl.Services
{
    public interface ICommentService
    {
        Task<Comment> GetDetailsAsync(int id);
        Task<IEnumerable<Comment>> GetAllCommentsAsync();
        Task<Comment> CreateAsync(string content ,int id);
        Task<Comment> DeleteAsync(int id);
    }
}
