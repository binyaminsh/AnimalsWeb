using AnimalsWeb.Data.Models;
using AnimalsWeb.Data.Repositories;

namespace AnimalsWeb.Bl.Services
{
    public class CommentService : ICommentService
    {
        private readonly ICommentRepository commentRepository;
        private readonly IAnimalRepository animalRepositRry;


        public CommentService(ICommentRepository commentRepository, IAnimalRepository animalRepository)
        {
            this.commentRepository = commentRepository;
            this.animalRepositRry = animalRepository;
        }

        public async Task<Comment> CreateAsync(string content, int id)
        {
            var comment = new Comment
            {
                Content = content,
                AnimalId = id
            };

            if (await animalRepositRry.GetByIdAsync(id) is null)
                return null;

            return await commentRepository.AddAsync(comment);
        }

        public Task<Comment> DeleteAsync(int id) => commentRepository.DeleteAsync(id);

        public Task<IEnumerable<Comment>> GetAllCommentsAsync() => commentRepository.GetAllAsync();

        public Task<Comment> GetDetailsAsync(int id) => commentRepository.GetByIdAsync(id);
    }
}
