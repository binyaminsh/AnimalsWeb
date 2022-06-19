using AnimalsWeb.Bl.Services;
using AnimalsWeb.Client.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace AnimalsWeb.Client.Controllers
{
    public class HomeController : Controller
    {
        private readonly IAnimalService service;

        public HomeController(IAnimalService service)
        {
            this.service = service;
        }

        public async Task<IActionResult> Index()
        {
            var animals = await service.GetPoppularAnimalsAsync(3);

            return View(animals);
        }

       [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}