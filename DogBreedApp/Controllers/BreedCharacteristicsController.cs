using AutoMapper;
using DogBreedApp.Data;
using DogBreedApp.Data.Entities;
using DogBreedApp.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DogBreedApp.Controllers
{
    [Route("api/breeds/{breedid}/characteristics")]
    public class BreedCharacteristicsController : Controller
    {
        private readonly IDogRepository repository;
        private readonly ILogger<BreedCharacteristicsController> logger;
        private readonly IMapper mapper;

        public BreedCharacteristicsController(IDogRepository repository, ILogger<BreedCharacteristicsController> logger, IMapper mapper)
        {
            this.repository = repository;
            this.logger = logger;
            this.mapper = mapper;
        }

        [HttpGet]
        public IActionResult Get(int breedId)
        {
            var breed = repository.GetBreedById(breedId);
            if (breed != null) return Ok(mapper.Map<IEnumerable<BreedCharacteristic>, IEnumerable<BreedCharacteristicViewModel>>(breed.BreedCharacteristics));
            return NotFound();
        }

        [HttpGet("{chid}")]
        public IActionResult Get(int breedId, int chId)
        {
            var breed = repository.GetBreedById(breedId);
            if (breed != null)
            {
                var breedCharacteristic = breed.BreedCharacteristics.Where(i => i.Characteristic.Id == chId).FirstOrDefault();
                if (breedCharacteristic != null)
                {
                    return Ok(mapper.Map<BreedCharacteristic, BreedCharacteristicViewModel>(breedCharacteristic));
                }
            }
            return NotFound();
        }

    }
}
