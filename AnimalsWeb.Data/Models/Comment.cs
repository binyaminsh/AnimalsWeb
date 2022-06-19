using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AnimalsWeb.Data.Models
{
    public partial class Comment
    {
        [Key]
        public int CommentId { get; set; }
        public int AnimalId { get; set; }
        public string Content { get; set; } = null!;

        [ForeignKey("AnimalId")]
        [InverseProperty("Comments")]
        public virtual Animal Animal { get; set; } = null!;
    }
}
