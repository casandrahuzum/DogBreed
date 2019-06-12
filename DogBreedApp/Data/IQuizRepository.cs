using DogBreedApp.Data.Entities;
using System.Collections.Generic;

namespace DogBreedApp.Data
{
    public interface IQuizRepository
    {
        IEnumerable<Question> GetQuestions(bool includeAnswers);
        ICollection<Answer> GetAnswers();
        Answer GetAnswer(int id);
        void AddUserAnswer(UserAnswer userAnswer);
        ICollection<UserAnswer> GetUserAnswers(User currentUser);
        bool SaveAll();
        void DeleteUserAnswer(UserAnswer currentUserAnswer);
    }
}