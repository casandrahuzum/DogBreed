using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DogBreedApp.Data.Entities
{
    public class Answer
    {
        [Key]
        public int Id { get; set; }
        public string Sentence { get; set; }
        public Question Question { get; set; }

        public ICollection<AnswerCharacteristic> AnswerCharacteristics { get; set; }
    }
}
