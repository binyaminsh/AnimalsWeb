using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AnimalsWeb.Data.Models
{
    public partial class Category
    {
        public Category()
        {
            Animals = new HashSet<Animal>();
        }

        [Key]
        public int CategoryId { get; set; }
        [StringLength(50)]
        public string Name { get; set; } = null!;

        [InverseProperty("Category")]
        public virtual ICollection<Animal> Animals { get; set; }
    }
}
