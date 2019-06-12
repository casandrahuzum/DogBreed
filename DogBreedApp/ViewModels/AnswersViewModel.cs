using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DogBreedApp.ViewModels
{
    public class AnswersViewModel
    {
        public int Id { get; set; }
        public string Sentence { get; set; }

        public ICollection<AnswerCharacteristicsViewModel> AnswerCharacteristics { get; set; }
    }
}
