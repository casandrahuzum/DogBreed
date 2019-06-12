using AutoMapper;
using DogBreedApp.Data;
using DogBreedApp.Data.Entities;
using DogBreedApp.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DogBreedApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IDogRepository repository;
        private readonly IMapper mapper;

        public HomeController(IDogRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult AllDogBreeds()
        {
            var results = repository.GetBreeds(true);
            return View(results);
        }

        [HttpGet("breed/{id:int}")]
        public IActionResult Breed(int id)
        {
            var breed = repository.GetBreedById(id);
            var result = mapper.Map<Breed, BreedViewModel>(breed);
            return View(result);
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
