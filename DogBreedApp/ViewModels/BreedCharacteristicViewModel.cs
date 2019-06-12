using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DogBreedApp.ViewModels
{
    public class BreedCharacteristicViewModel
    {
        public int Id { get; set; }
        [Required]
        public int Score { get; set; }

        [Required]
        public int CharacteristicId { get; set; }
        public string CharacteristicName { get; set; }

    }
}
