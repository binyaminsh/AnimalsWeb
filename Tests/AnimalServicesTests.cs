using AnimalsWeb.Bl.Services;
using AnimalsWeb.Data.Models;
using AnimalsWeb.Data.Repositories;
using Microsoft.AspNetCore.Http;
using Moq;
using System;
using System.IO;
using System.Threading.Tasks;
using Xunit;

namespace Tests
{
    public class AnimalServicesTests
    {
        private readonly AnimalService sut;
        private readonly Mock<IAnimalRepository> animalRepoMoq = new();

        public AnimalServicesTests()
        {
            sut = new AnimalService(animalRepoMoq.Object);
        }

        [Fact]
        public async Task GetByIdAsync_ShouldReturnAnimal_WhenAnimalExists()
        {
            //Arrange
            var animalId = 1;
            var animalName = "dog";
            var animal = new Animal
            {
                AnimalId = animalId,
                Name = animalName,
                CategoryId = 1,
                Age = DateTime.Now
            };
            animalRepoMoq.Setup(a => a.GetByIdAsync(animalId)).ReturnsAsync(animal);

            //Act
            var result = await sut.GetByIdAsync(animalId);

            //Assert
            Assert.Equal(animalId, result.AnimalId);
            Assert.Equal(animalName, result.Name);
        }

        [Fact]
        public async Task GetByIdAsync_ShouldReturnNothing_WhenAnimalDoNotExists()
        {
            //Arrange
            animalRepoMoq.Setup(a => a.GetByIdAsync(It.IsAny<int>())).ReturnsAsync(() => null);

            //Act
            var result = await sut.GetByIdAsync(11);

            //Assert
            Assert.Null(result);
        }
    }
}