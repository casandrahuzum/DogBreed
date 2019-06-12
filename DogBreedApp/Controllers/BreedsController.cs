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
    [Route("api/[Controller]")]
    public class BreedsController : Controller
    {
        private readonly IDogRepository repository;
        private readonly ILogger<BreedsController> logger;
        private readonly IMapper mapper;

        public BreedsController(IDogRepository repository, ILogger<BreedsController> logger, IMapper mapper)
        {
            this.repository = repository;
            this.logger = logger;
            this.mapper = mapper;
        }

        [HttpGet]
        public ActionResult Get(bool includeItems = true)
        {
            try
            {
                var result = repository.GetBreeds(includeItems);
                return Ok(mapper.Map<IEnumerable<Breed>, IEnumerable<BreedViewModel>>(result));
            }
            catch(Exception e)
            {
                logger.LogError($"Failed to get breeds: {e}");
                return BadRequest("Failed to get breeds");
            }
        }

        [HttpGet("{id:int}")]
        public IActionResult Get(int id)
        {
            try
            {
                var breed = repository.GetBreedById(id);
                if (breed != null)
                {
                    return Ok(mapper.Map<Breed, BreedViewModel>(breed));
                }
                else
                {
                    return NotFound();
                }

            }
            catch (Exception ex)
            {

                logger.LogError($"Failed to get breed: {ex}");
                return BadRequest("Failed to get breed");
            }
        }


    }
}
