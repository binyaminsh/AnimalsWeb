﻿// <auto-generated />
using System;
using AnimalsWeb.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AnimalsWeb.Data.Migrations
{
    [DbContext(typeof(AnimalsWebSiteDbContext))]
    partial class AnimalsWebSiteDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("AnimalsWeb.Data.Models.Animal", b =>
                {
                    b.Property<int>("AnimalId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AnimalId"), 1L, 1);

                    b.Property<DateTime>("Age")
                        .HasColumnType("date");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("PhotoUrl")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("AnimalId");

                    b.HasIndex("CategoryId");

                    b.ToTable("Animals");

                    b.HasData(
                        new
                        {
                            AnimalId = 1,
                            Age = new DateTime(2021, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CategoryId = 1,
                            Description = "The Bombay is an easy-going, yet energetic cat.",
                            Name = "Bombay Cat",
                            PhotoUrl = "Bombay.webp"
                        },
                        new
                        {
                            AnimalId = 2,
                            Age = new DateTime(2020, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CategoryId = 2,
                            Description = "One of the oldest Arctic sled dogs, the Alaskan Malamute was first bred in Alaska to carry large loads over long distances.",
                            Name = "Alaskan Malamute",
                            PhotoUrl = "Alaskan-Malamute-dog.webp"
                        },
                        new
                        {
                            AnimalId = 3,
                            Age = new DateTime(2022, 1, 13, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CategoryId = 2,
                            Description = "Once used as a hunting companion by English gentlemen in the 1500s, the Beagle is a friendly and cheerful family companion",
                            Name = "Beagle",
                            PhotoUrl = "Beagle-dog.jpg"
                        },
                        new
                        {
                            AnimalId = 4,
                            Age = new DateTime(2021, 4, 9, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CategoryId = 3,
                            Description = " A solitary creature, the bush viper is arboreal and terrestrial. Their colors make for exceptional camouflage.",
                            Name = "Bush Viper",
                            PhotoUrl = "Bush-Viper.jpeg"
                        });
                });

            modelBuilder.Entity("AnimalsWeb.Data.Models.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CategoryId"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("CategoryId");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            CategoryId = 1,
                            Name = "Cats"
                        },
                        new
                        {
                            CategoryId = 2,
                            Name = "Dogs"
                        },
                        new
                        {
                            CategoryId = 3,
                            Name = "Reptiles"
                        });
                });

            modelBuilder.Entity("AnimalsWeb.Data.Models.Comment", b =>
                {
                    b.Property<int>("CommentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CommentId"), 1L, 1);

                    b.Property<int>("AnimalId")
                        .HasColumnType("int");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CommentId");

                    b.HasIndex("AnimalId");

                    b.ToTable("Comments");

                    b.HasData(
                        new
                        {
                            CommentId = 1,
                            AnimalId = 1,
                            Content = "hello"
                        },
                        new
                        {
                            CommentId = 2,
                            AnimalId = 2,
                            Content = "test comment"
                        },
                        new
                        {
                            CommentId = 3,
                            AnimalId = 3,
                            Content = "wow"
                        });
                });

            modelBuilder.Entity("AnimalsWeb.Data.Models.Animal", b =>
                {
                    b.HasOne("AnimalsWeb.Data.Models.Category", "Category")
                        .WithMany("Animals")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired()
                        .HasConstraintName("FK_Animals_Categories");

                    b.Navigation("Category");
                });

            modelBuilder.Entity("AnimalsWeb.Data.Models.Comment", b =>
                {
                    b.HasOne("AnimalsWeb.Data.Models.Animal", "Animal")
                        .WithMany("Comments")
                        .HasForeignKey("AnimalId")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired()
                        .HasConstraintName("FK_Comments_Animals");

                    b.Navigation("Animal");
                });

            modelBuilder.Entity("AnimalsWeb.Data.Models.Animal", b =>
                {
                    b.Navigation("Comments");
                });

            modelBuilder.Entity("AnimalsWeb.Data.Models.Category", b =>
                {
                    b.Navigation("Animals");
                });
#pragma warning restore 612, 618
        }
    }
}
