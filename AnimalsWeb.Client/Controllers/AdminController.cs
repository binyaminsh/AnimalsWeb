using AnimalsWeb.Bl.Services;
using AnimalsWeb.Client.Models;
using AnimalsWeb.Data.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace AnimalsWeb.Client.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        private readonly IAnimalService animalService;
        private readonly ICategoryService categoryService;
        private readonly ICommentService commentService;

        public AdminController(IAnimalService animalService, ICategoryService categoryService, ICommentService commentService)
        {
            this.animalService = animalService;
            this.categoryService = categoryService;
            this.commentService = commentService;
        }

        public async Task<ActionResult> List()
        {
            var animals = await animalService.GetAllAnimalsAsync();
            return !animals.Any() ? RedirectToAction("Index", "Home") : View(animals);
        }

        public async Task<ActionResult> Create()
        {
            var categories = await categoryService.GetAllCategoriesAsync();
            ViewBag.Categories = new SelectList(categories, "CategoryId", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([FromForm] CreateAnimalViewModel vm)
        {
            try
            {
                var categories = await categoryService.GetAllCategoriesAsync();
                vm.Animal.Category = categories.FirstOrDefault(c => c.CategoryId == vm.Animal.CategoryId)!;
                ModelState.Clear();

                if (TryValidateModel(vm, nameof(vm)))
                {
                    var animal = await animalService.AddAsync(vm.Animal, vm.ImageFile);
                    if (animal != null)
                        return RedirectToAction("Details", "Animal", new { id = animal.AnimalId });
                }
            }
            catch
            {
                return View();
            }
            return NoContent();
        }

        public async Task<ActionResult> Edit(int id)
        {
            var animal = await animalService.GetByIdAsync(id);
            var categories = await categoryService.GetAllCategoriesAsync();
            ViewBag.Categories = new SelectList(categories, "CategoryId", "Name");
            var vm = new CreateAnimalViewModel { Animal = animal };

            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([FromForm] CreateAnimalViewModel vm)
        {
            try
            {
                var categories = await categoryService.GetAllCategoriesAsync();
                vm.Animal.Category = categories.FirstOrDefault(c => c.CategoryId == vm.Animal.CategoryId)!;
                ModelState.Clear();
                
                if (TryValidateModel(vm, nameof(vm)))
                {
                    var updetedAnimal = await animalService.UpdateAsync(vm.Animal, vm.ImageFile!);

                    if (updetedAnimal != null)
                        return RedirectToAction("Details", "Animal", new { id = updetedAnimal.AnimalId });
                }
            }
            catch(DbUpdateConcurrencyException ex)
            {
                return BadRequest(ex.Message);
            }

            return NoContent();
        }

        public async Task<ActionResult> Delete(int id)
        {
            var animal = await animalService.GetByIdAsync(id);

            if (animal == null)
            {
                return NotFound();
            }

            return View(animal);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            try
            {
                var deletedAnimal = await animalService.DeleteAsync(id);
                return RedirectToAction(nameof(List));
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        public IActionResult CreateCategory()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateCategory(Category category)
        {
            if (category == null)
                return NoContent();

            await categoryService.AddAsync(category);
            return RedirectToAction(nameof(List));
        }
        public async Task<IActionResult> DeleteCategory()
        {
            var categories = await categoryService.GetAllCategoriesAsync();
            ViewBag.Categories = new SelectList(categories, "CategoryId", "Name");
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> DeleteCategory(int categoryId)
        {
            var deletedCategory = await categoryService.DeleteAsync(categoryId);
            return RedirectToAction(nameof(List));
        }

        public async Task<IActionResult> DeleteComment(int commentId)
        {
            var comment = await commentService.GetDetailsAsync(commentId);
            var deletedComment = await commentService.DeleteAsync(commentId);
            return RedirectToAction("Details", "Animal",new { id = comment.AnimalId });
        }
    }
}
