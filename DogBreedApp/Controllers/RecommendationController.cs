using DogBreedApp.Data;
using DogBreedApp.Data.Entities;
using DogBreedApp.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DogBreedApp.Controllers
{
    [Authorize]
    public class RecommendationController : Controller
    {
        private readonly ILogger<RecommendationController> logger;
        private readonly IQuizRepository quizRepository;
        private readonly IDogRepository dogRepository;
        private readonly UserManager<User> userManager;

        public RecommendationController(ILogger<RecommendationController> logger,
            IQuizRepository quizRepository,
            IDogRepository dogRepository,
            UserManager<User> userManager)
        {
            this.logger = logger;
            this.quizRepository = quizRepository;
            this.dogRepository = dogRepository;
            this.userManager = userManager;
        }

        public async Task<IActionResult> Matches()
        {
            IEnumerable<BreedMatchViewModel> breedMatches = await MatchBreedsToUser();

            if(breedMatches.First().MatchScore == 0)
            {
                return RedirectToAction("GetQuiz", "Quiz");
            }

            return View(breedMatches);
        }

        private async Task<IEnumerable<BreedMatchViewModel>> MatchBreedsToUser()
        {
            string username = this.User.Identity.Name;
            User currentUser = await userManager.FindByNameAsync(username);
            ICollection<UserAnswer> userAnswers = quizRepository.GetUserAnswers(currentUser);
            List<CharacteristicUserScore> characteristicUserScores = new List<CharacteristicUserScore>();
            List<BreedMatchViewModel> breedMatches = new List<BreedMatchViewModel>();

            IEnumerable<Breed> breeds = dogRepository.GetBreeds(true);

            foreach (UserAnswer answer in userAnswers)
            {
                foreach (AnswerCharacteristic answerCharacteristic in answer.Answer.AnswerCharacteristics)
                {
                    characteristicUserScores.Add(new CharacteristicUserScore()
                    {
                        UserScore = answerCharacteristic.Score,
                        CharacteristicName = answerCharacteristic.Characteristic.Name
                    });
                }
            }

            foreach (Breed breed in breeds)
            {
                double matchScore = 0;

                foreach (CharacteristicUserScore userCharacteristic in characteristicUserScores)
                {
                    int userScore = userCharacteristic.UserScore;
                    if (userScore == 0)
                    {
                        matchScore += 100;
                    }
                    else
                    {
                        int breedScore = breed.BreedCharacteristics.Where(bc => bc.Characteristic.Name == userCharacteristic.CharacteristicName).First().Score;
                        matchScore += 100 - Math.Abs(userScore - breedScore) * 20;
                    }
                }

                breedMatches.Add(new BreedMatchViewModel()
                {
                    BreedId = breed.Id,
                    BreedName = breed.Name,
                    MatchScore = matchScore/26,
                    UserName = currentUser.FirstName
                });
            }

            return breedMatches.OrderByDescending(bm => bm.MatchScore);
        }
    }
}
