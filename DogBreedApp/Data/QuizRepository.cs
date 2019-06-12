using DogBreedApp.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DogBreedApp.Data
{
    public class QuizRepository : IQuizRepository
    {
        private readonly DogContext context;
        private readonly ILogger<QuizRepository> logger;

        public QuizRepository(DogContext context, ILogger<QuizRepository> logger)
        {
            this.context = context;
            this.logger = logger;
        }

        public IEnumerable<Question> GetQuestions(bool includeAnswers)
        {
            if (includeAnswers)
            {
                return context.Questions
                .Include(q => q.Answers)
                .ThenInclude(a => a.AnswerCharacteristics)
                .ThenInclude(ac => ac.Characteristic)
                .ToList();
            }
            else
            {
                return context.Questions.ToList();
            }
        }

        public ICollection<Answer> GetAnswers()
        {
            return context.Answers
                .Include(a => a.Question)
                .Include(a => a.AnswerCharacteristics)
                .ThenInclude(ac => ac.Characteristic)
                .ToList();
        }

        public Answer GetAnswer(int id)
        {
            return context.Answers
                .Where(a => a.Id == id)
                .Include(a => a.Question)
                .Include(a => a.AnswerCharacteristics)
                .ThenInclude(ac => ac.Characteristic)
                .FirstOrDefault();
        }

        public void AddUserAnswer(UserAnswer userAnswer)
        {
            context.Add(userAnswer);
        }

        public ICollection<UserAnswer> GetUserAnswers(User currentUser)
        {
            return context.UserAnswers
                .Where(u => u.User == currentUser)
                .Include(u => u.User)
                .Include(u => u.Answer)
                .ThenInclude(a => a.AnswerCharacteristics)
                .ThenInclude(ac => ac.Characteristic)
                .ToList();
        }

        public void DeleteUserAnswer(UserAnswer currentUserAnswer)
        {
            context.Remove(currentUserAnswer);
        }

        public bool SaveAll()
        {
            return context.SaveChanges() > 0;
        }

    }
}
