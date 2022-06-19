using AnimalsWeb.Data.Models;

namespace AnimalsWeb.Client.Models
{
    public class CreateAnimalViewModel
    {
        public Animal Animal { get; set; } = null!;
        public IFormFile? ImageFile { get; set; }
    }
}
