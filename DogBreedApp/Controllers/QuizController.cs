using AutoMapper;
using DogBreedApp.Data;
using DogBreedApp.Data.Entities;
using DogBreedApp.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DogBreedApp.Controllers
{
    [Authorize]
    public class QuizController : Controller
    {
        private readonly ILogger<QuizController> logger;
        private readonly IQuizRepository repository;
        private readonly IMapper mapper;
        private readonly UserManager<User> userManager;

        public QuizController(ILogger<QuizController> logger, IQuizRepository repository, IMapper mapper, UserManager<User> userManager)
        {
            this.logger = logger;
            this.repository = repository;
            this.mapper = mapper;
            this.userManager = userManager;
        }

        public IActionResult GetQuiz()
        {
            return View(GetQuestionViewModels());
        }

        [HttpPost]
        public async Task<IActionResult> GetQuiz(IFormCollection results)
        {
            try
            {
                if (results.Count == 18)
                {
                    List<int> answerIds = new List<int>();
                    for (int i = 0; i < results.Count; i++)
                    {
                        if (results.ElementAt(i).Key.Contains("question_"))
                        {
                            string value = results.ElementAt(i).Value;
                            int answerId = Int32.Parse(value);
                            answerIds.Add(answerId);
                        }
                    }
                    string username = this.User.Identity.Name;
                    var currentUser = await userManager.FindByNameAsync(username);

                    if (!AddUserAnswers(currentUser, answerIds))
                    {
                        throw new Exception("Failed to save answers!");
                    }

                    return RedirectToAction("Matches", "Recommendation");
                }
                else
                {
                    ModelState.AddModelError("", "Please answer all the questions!");
                }
            }
            catch (Exception ex)
            {
                logger.LogError($"Failed to save the answers: {ex}");
                ModelState.AddModelError("", "Failed to save answers!");
            }
            return View(GetQuestionViewModels());
        }

        private bool AddUserAnswers(User currentUser, List<int> answerIds)
        {
            ICollection<UserAnswer> currentUserAnswers = repository.GetUserAnswers(currentUser);

            if (currentUserAnswers.Count != 0)
            {
                foreach(UserAnswer currentUserAnswer in currentUserAnswers)
                {
                    repository.DeleteUserAnswer(currentUserAnswer);
                }  
            }

            foreach (int answerId in answerIds)
            {
                Answer answer = repository.GetAnswer(answerId);
                UserAnswer userAnswer = new UserAnswer()
                {
                    Answer = answer,
                    User = currentUser
                };
                repository.AddUserAnswer(userAnswer);
            }

            if (repository.SaveAll())
            {
                return true;
            }

            return false;
        }

        private IEnumerable<QuestionViewModel> GetQuestionViewModels()
        {
            var questions = repository.GetQuestions(true);
            return mapper.Map<IEnumerable<Question>, IEnumerable<QuestionViewModel>>(questions);
        }
    }
}
