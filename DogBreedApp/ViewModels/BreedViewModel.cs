using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DogBreedApp.ViewModels
{
    public class BreedViewModel
    {
        public int BreedId { get; set; }
        [Required]
        public string Name { get; set; }

        public ICollection<BreedCharacteristicViewModel> BreedCharacteristics { get; set; }
    }
}
