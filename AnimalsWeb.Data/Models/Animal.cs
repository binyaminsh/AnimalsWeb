using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AnimalsWeb.Data.Models
{
    public partial class Animal
    {
        public Animal()
        {
            Comments = new HashSet<Comment>();
        }

        [Key]
        public int AnimalId { get; set; }
        [StringLength(50)]
        public string Name { get; set; } = null!;
        [Column(TypeName = "date")]
        [Display(Name = "Date of birth")]
        [DataType(DataType.Date)]
        
        public DateTime Age { get; set; }
        public string? Description { get; set; }
        [Display(Name ="Category")]
        public int CategoryId { get; set; }
        [StringLength(200)]
        public string? PhotoUrl { get; set; }

        [ForeignKey("CategoryId")]
        [InverseProperty("Animals")]
        public virtual Category Category { get; set; } = null!;
        [InverseProperty("Animal")]
        public virtual ICollection<Comment> Comments { get; set; }
    }
}
