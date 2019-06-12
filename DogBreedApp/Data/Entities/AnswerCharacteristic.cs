using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DogBreedApp.Data.Entities
{
    public class AnswerCharacteristic
    {
        [Key]
        public int Id { get; set; }
        public Answer Answer { get; set; }
        public Characteristic Characteristic { get; set; }
        public int Score { get; set; }
    }
}
