using DogBreedApp.Data.Entities;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Json;
using System.Linq;
using System.Threading.Tasks;

namespace DogBreedApp.Data
{
    public class DogSeeder
    {
        private readonly DogContext context;
        private readonly IHostingEnvironment hosting;
        private readonly UserManager<User> userManager;

        public DogSeeder(DogContext context, IHostingEnvironment hosting, UserManager<User> userManager)
        {
            this.context = context;
            this.hosting = hosting;
            this.userManager = userManager;
        }

        public async Task Seed()
        {
            context.Database.EnsureCreated();

            var user = await userManager.FindByNameAsync("casandrahuzum");

            if (user == null)
            {
                user = new User()
                {
                    FirstName = "Casandra",
                    LastName = "Huzum",
                    UserName = "casandrahuzum"
                };

                var result = await userManager.CreateAsync(user, "P@ssw0rd!");
                if (result != IdentityResult.Success)
                {
                    throw new InvalidOperationException("Failed to create defaul user!");
                }
            }


            if (context.Breeds.Any() || context.Characteristics.Any() || context.Questions.Any())
                return;

            ICollection<Characteristic> characteristics = new List<Characteristic>();
            ICollection<Breed> breeds = new List<Breed>();
            string filepath = Path.Combine(hosting.ContentRootPath, "Data/characteristics.json");
            string jsonText = File.ReadAllText(filepath);


            JsonArray jsonArray = (JsonArray)JsonValue.Parse(jsonText);

            JsonObject firstObject = (JsonObject)jsonArray.First();

            foreach (string key in firstObject.Keys.Where(key => key != "Name"))
            {
                characteristics.Add(new Characteristic()
                {
                    Name = key
                });
            }

            foreach (JsonObject jsonObject in jsonArray)
            {
                ICollection<BreedCharacteristic> breedCharacteristics = new List<BreedCharacteristic>();

                foreach (Characteristic characteristic in characteristics)
                {
                    breedCharacteristics.Add(new BreedCharacteristic()
                    {
                        Characteristic = characteristic,
                        Score = jsonObject[characteristic.Name]
                    });
                }

                breeds.Add(new Breed()
                {
                    Name = jsonObject["Name"],
                    BreedCharacteristics = breedCharacteristics
                });
            }

            ICollection<Question> questions = new List<Question>();
            string filepathQuestions = Path.Combine(hosting.ContentRootPath, "Data/questions.json");
            string jsonTextQuestions = File.ReadAllText(filepathQuestions);

            JsonArray jsonArrayQuestions = (JsonArray)JsonValue.Parse(jsonTextQuestions);

            foreach (JsonObject jsonObject in jsonArrayQuestions)
            {
                ICollection<Answer> answers = new List<Answer>();
                JsonArray jsonAnswers = (JsonArray)jsonObject["Answers"];

                foreach (JsonObject jsonAnswer in jsonAnswers)
                {
                    ICollection<AnswerCharacteristic> answerCharacteristics = new List<AnswerCharacteristic>();
                    JsonArray jsonCharacteristics = (JsonArray)jsonAnswer["Characteristics"];

                    foreach (JsonObject jsonCharacteristic in jsonCharacteristics)
                    {
                        answerCharacteristics.Add(new AnswerCharacteristic()
                        {
                            Score = jsonCharacteristic["Score"],
                            Characteristic = characteristics.Where(c => c.Name == jsonCharacteristic["CharacteristicName"]).First()
                        });
                    }

                    answers.Add(new Answer()
                    {
                        Sentence = jsonAnswer["Sentence"],
                        AnswerCharacteristics = answerCharacteristics
                    });
                }
                questions.Add(new Question()
                {
                    Sentence = jsonObject["Sentence"],
                    Answers = answers
                });
            }

            context.AddRange(characteristics);
            context.AddRange(breeds);
            context.AddRange(questions);

            context.SaveChanges();

        }
    }
}
