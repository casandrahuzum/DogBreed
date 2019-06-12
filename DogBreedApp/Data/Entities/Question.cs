using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DogBreedApp.Data.Entities
{
    public class Question
    {
        [Key]
        public int Id { get; set; }
        public string Sentence { get; set; }

        public ICollection<Answer> Answers { get; set; }
    }
}
