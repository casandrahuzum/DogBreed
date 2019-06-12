using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DogBreedApp.ViewModels
{
    public class BreedMatchViewModel
    {
        public double MatchScore { get; set; }
        public int BreedId { get; set; }
        public string BreedName { get; set; }

        public string UserName { get; set; }
    }
}
