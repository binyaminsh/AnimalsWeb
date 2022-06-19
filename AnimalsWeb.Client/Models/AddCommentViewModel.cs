using AnimalsWeb.Data.Models;
using System.ComponentModel.DataAnnotations;

namespace AnimalsWeb.Client.Models
{
    public class AddCommentViewModel
    {
        public Animal? Animal { get; set; }

        [Required(ErrorMessage = "Content is required.")]
        public string? Content { get; set; }
    }
}
