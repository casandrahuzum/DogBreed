using DogBreedApp.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DogBreedApp.ViewModels
{
    public class QuestionViewModel
    {
        public int QuestionId { get; set; }
        public string Sentence { get; set; }

        public ICollection<AnswersViewModel> Answers { get; set; }
    }
}
