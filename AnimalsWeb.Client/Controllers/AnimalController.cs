using AnimalsWeb.Bl.Services;
using AnimalsWeb.Client.Models;
using AnimalsWeb.Data.Models;
using Microsoft.AspNetCore.Mvc;

namespace AnimalsWeb.Client.Controllers
{
    public class AnimalController : Controller
    {
        private readonly IAnimalService animalService;
        private readonly ICommentService commentService;

        public AnimalController(IAnimalService animalService, ICommentService commentService)
        {
            this.animalService = animalService;
            this.commentService = commentService;
        }


        public async Task<IActionResult> List(string category)
        {
            var vm = new AnimalListViewModel();

            if (string.IsNullOrEmpty(category))
            {
                vm.Animals = await animalService.GetAllAnimalsAsync();
                if (!vm.Animals.Any())
                    return NoContent();
                vm.CurrentCategory = "All Animals";
            }
            else
            {
                vm.Animals = await animalService.GetAllByCategoryAsync(category);
                if (!vm.Animals.Any())
                    return NoContent();
                vm.CurrentCategory = category;
            }

            return View(vm);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var vm = new AddCommentViewModel();
            var animal = await animalService.GetByIdAsync(id);
            vm.Animal = animal;
            if (animal == null)
                return NotFound();

            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> Details(int id, [FromForm] AddCommentViewModel newComment)
        {
            if (ModelState.IsValid)
            {
                var comment = await commentService.CreateAsync(newComment.Content!, id);
                if (comment.AnimalId == 0)
                    return NoContent();
                return RedirectToAction(nameof(Details), new { id = comment.AnimalId });
            }
            else
            {
                return NoContent();
            }

        }

        public async Task<IActionResult> Search(string name)
        {
            if(string.IsNullOrEmpty(name))
                return NoContent();
            var animals = await animalService.GetAnimalsByNameAsync(name);
            if (animals == null)
                return NoContent();

            return View(animals);
        }
    }
}
