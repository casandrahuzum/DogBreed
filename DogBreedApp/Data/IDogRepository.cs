using System.Collections.Generic;
using DogBreedApp.Data.Entities;

namespace DogBreedApp.Data
{
    public interface IDogRepository
    {
        IEnumerable<Breed> GetBreeds(bool includeItems);
        IEnumerable<Characteristic> GetAllCharacteristics();
        bool SaveAll();
        Breed GetBreedById(int id);
    }
}