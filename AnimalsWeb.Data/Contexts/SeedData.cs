using AnimalsWeb.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalsWeb.Data.Contexts
{
    public static class SeedData
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Animal>(entity =>
            {
                entity.HasData(
                    new Animal
                    {
                        AnimalId = 1,
                        Name = "Bombay Cat",
                        Age = new DateTime(2021, 01, 02),
                        Description = "The Bombay is an easy-going, yet energetic cat.",
                        PhotoUrl = "Bombay.webp",
                        CategoryId = 1
                    },
                    new Animal
                    {
                        AnimalId = 2,
                        Name = "Alaskan Malamute",
                        Age = new DateTime(2020, 07, 20),
                        Description = "One of the oldest Arctic sled dogs, the Alaskan Malamute was first bred in Alaska to carry large loads over long distances.",
                        PhotoUrl = "Alaskan-Malamute-dog.webp",
                        CategoryId = 2
                    },
                    new Animal
                    {
                        AnimalId = 3,
                        Name = "Beagle",
                        Age = new DateTime(2022, 01, 13),
                        Description = "Once used as a hunting companion by English gentlemen in the 1500s, the Beagle is a friendly and cheerful family companion",
                        PhotoUrl = "Beagle-dog.jpg",
                        CategoryId = 2
                    },
                    new Animal
                    {
                        AnimalId = 4,
                        Name = "Bush Viper",
                        Age = new DateTime(2021, 04, 09),
                        Description = " A solitary creature, the bush viper is arboreal and terrestrial. Their colors make for exceptional camouflage.",
                        PhotoUrl = "Bush-Viper.jpeg",
                        CategoryId = 3
                    });
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasData(
                    new Category
                    {
                        CategoryId = 1,
                        Name = "Cats"
                    },
                    new Category
                    {
                        CategoryId = 2,
                        Name = "Dogs"
                    },
                    new Category
                    {
                        CategoryId = 3,
                        Name = "Reptiles"
                    });
            });

            modelBuilder.Entity<Comment>(entity =>
            {
                entity.HasData(
                    new Comment
                    {
                        CommentId = 1,
                        Content = "hello",
                        AnimalId = 1
                    },
                    new Comment
                    {
                        CommentId = 2,
                        Content = "test comment",
                        AnimalId = 2
                    },
                    new Comment
                    {
                        CommentId = 3,
                        Content = "wow",
                        AnimalId = 3
                    });
            });
        }
    }
}
