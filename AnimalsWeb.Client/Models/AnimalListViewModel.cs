using AnimalsWeb.Data.Models;

namespace AnimalsWeb.Client.Models
{
    public class AnimalListViewModel
    {
        public IEnumerable<Animal> Animals { get; set; }
        public string CurrentCategory { get; set; }
    }
}
