using DogBreedApp.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DogBreedApp.Data
{
    public class DogRepository : IDogRepository
    {
        private readonly DogContext context;
        private readonly ILogger<DogRepository> logger;

        public DogRepository(DogContext context, ILogger<DogRepository> logger)
        {
            this.context = context;
            this.logger = logger;
        }

        public IEnumerable<Breed> GetBreeds(bool includeCharacteristics)
        {
            if (includeCharacteristics)
            {
                return context.Breeds
                .Include(b => b.BreedCharacteristics)
                .ThenInclude(bc => bc.Characteristic)
                .OrderBy(b => b.Name)
                .ToList();
            }
            else
            {
                return context.Breeds.ToList();
            }
        }

        public Breed GetBreedById(int id)
        {
            return context.Breeds
                .Include(b => b.BreedCharacteristics)
                .ThenInclude(bc => bc.Characteristic)
                .Where(b => b.Id == id)
                .FirstOrDefault();
        }

        public IEnumerable<Characteristic> GetAllCharacteristics()
        {
            try
            {
                logger.LogInformation("GetAllCharacteristics was called");

                return context.Characteristics
                    .OrderBy(p => p.Name)
                    .ToList();
            }
            catch (Exception e)
            {
                logger.LogError($"Failed to get all characteristics {e}");
                return null;
            }

        }

        //public IEnumerable<Characteristic> GetCharacteristicsByBreed(int idBreed)
        //{
        //    return
        //}

        public bool SaveAll()
        {
            return context.SaveChanges() > 0;
        }

    }
}
