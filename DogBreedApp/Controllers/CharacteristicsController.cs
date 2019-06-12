using DogBreedApp.Data;
using DogBreedApp.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DogBreedApp.Controllers
{
    [Route("api/[Controller]")]
    public class CharacteristicsController : Controller
    {
        private readonly IDogRepository repository;
        private readonly ILogger<CharacteristicsController> logger;

        public CharacteristicsController(IDogRepository repository, ILogger<CharacteristicsController> logger)
        {
            this.repository = repository;
            this.logger = logger;
        }

        [HttpGet]
        public IEnumerable<Characteristic> Get()
        {
            return repository.GetAllCharacteristics();
        }
    }
}
