using Microsoft.EntityFrameworkCore;
using AnimalsWeb.Data.Models;

namespace AnimalsWeb.Data.Contexts
{
    public partial class AnimalsWebSiteDbContext : DbContext
    {
        public AnimalsWebSiteDbContext()
        {
        }

        public AnimalsWebSiteDbContext(DbContextOptions<AnimalsWebSiteDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Animal> Animals { get; set; } = null!;
        public virtual DbSet<Category> Categories { get; set; } = null!;
        public virtual DbSet<Comment> Comments { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("DeafultConnectionString");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Animal>(entity =>
            {
                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Animals)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.ClientCascade)
                    .HasConstraintName("FK_Animals_Categories");

                entity.Navigation(x => x.Comments).AutoInclude();
                entity.Navigation(x => x.Category).AutoInclude();
            });

            modelBuilder.Entity<Comment>(entity =>
            {
                entity.HasOne(d => d.Animal)
                    .WithMany(p => p.Comments)
                    .HasForeignKey(d => d.AnimalId)
                    .OnDelete(DeleteBehavior.ClientCascade)
                    .HasConstraintName("FK_Comments_Animals");
            });

            modelBuilder.Seed();

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
