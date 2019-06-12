using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DogBreedApp.Data.Entities
{
    public class UserAnswer
    {
        [Key]   
        public int Id { get; set; }
        public User User { get; set; }
        public Answer Answer { get; set; }
    }
}
