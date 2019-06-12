using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DogBreedApp.Data.Entities
{
    public class Breed
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<BreedCharacteristic> BreedCharacteristics { get; set; }
    }
}
