namespace AnimalsWeb.Data.Repositories
{
    public interface IRepository <T> where T : class
    {
        Task<T> GetByIdAsync(int id);
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> UpdateAsync(T entity);
        Task<T> AddAsync(T entity);
        Task<T> DeleteAsync(int id);
    }
}
