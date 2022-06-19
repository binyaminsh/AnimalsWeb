using AnimalsWeb.Data.Models;
using AnimalsWeb.Data.Repositories;
using Microsoft.AspNetCore.Http;

namespace AnimalsWeb.Bl.Services
{
    public class AnimalService : IAnimalService
    {
        private readonly IAnimalRepository repository;
        private readonly IFileService fileService;

        public AnimalService(IAnimalRepository repository, IFileService fileService)
        {
            this.repository = repository;
            this.fileService = fileService;
        }
        public AnimalService(IAnimalRepository repository)
        {
            this.repository = repository;
        }
        public Task<Animal> GetByIdAsync(int id) => repository.GetByIdAsync(id);

        public Task<IEnumerable<Animal>> GetAllAnimalsAsync() => repository.GetAllAsync();

        public async Task<IEnumerable<Animal>> GetAllByCategoryAsync(string categoryName) =>
            await repository.GetAnimalsByCategoryAsync(categoryName);

        public Task<IEnumerable<Animal>> GetPoppularAnimalsAsync(int count) => repository.GetPoppularAnimalsAsync(count);

        public async Task<Animal> AddAsync(Animal animal, IFormFile file)
        {
            var (isSuccess, PictureName) = await fileService.UploadFile(file);
            if (isSuccess)
            {
                animal.PhotoUrl = PictureName;
                var updatedAnimal = await repository.AddAsync(animal);
                return updatedAnimal;
            }
            return null;
        }

        public async Task<Animal> DeleteAsync(int id)
        {
            var deletedAnimal = await repository.DeleteAsync(id);
            fileService.DeleteFile(deletedAnimal);
            return deletedAnimal;
        }

        public async Task<Animal> UpdateAsync(Animal animal, IFormFile file)
        {
            Animal updatedAnimal;

            if (file is null)
            {
                updatedAnimal = await repository.UpdateAsync(animal);
            }
            else
            {
                fileService.DeleteFile(animal);
                var (isSuccess, PictureName) = await fileService.UploadFile(file);
                if (isSuccess)
                    animal.PhotoUrl = PictureName;

                updatedAnimal = await repository.UpdateAsync(animal);
            }

            return updatedAnimal;
        }

        public Task<IEnumerable<Animal>> GetAnimalsByNameAsync(string name) => repository.GetAnimalsByNameAsync(name);
    }
}
