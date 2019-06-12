using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DogBreedApp.Data.Entities
{
    public class BreedCharacteristic
    {
        public int Id { get; set; }
        public Breed Breed { get; set; }
        public Characteristic Characteristic { get; set; }
        public int Score { get; set; }
    }
}
