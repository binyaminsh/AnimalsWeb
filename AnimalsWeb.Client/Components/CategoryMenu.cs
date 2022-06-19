using AnimalsWeb.Bl.Services;
using Microsoft.AspNetCore.Mvc;

namespace AnimalsWeb.Client.Components
{
    public class CategoryMenu : ViewComponent
    {
        private readonly ICategoryService service;

        public CategoryMenu(ICategoryService service)
        {
            this.service = service;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var categories = await service.GetAllCategoriesAsync();
            return View(categories);
        }
    }
}
