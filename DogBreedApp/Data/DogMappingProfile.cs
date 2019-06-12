using AutoMapper;
using DogBreedApp.Data.Entities;
using DogBreedApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DogBreedApp.Data
{
    public class DogMappingProfile : Profile
    {
        public DogMappingProfile()
        {
            CreateMap<Breed, BreedViewModel>()
                .ForMember(b => b.BreedId, ex => ex.MapFrom(b => b.Id))
                .ReverseMap();

            CreateMap<BreedCharacteristic, BreedCharacteristicViewModel>()
                .ReverseMap();

            CreateMap<Question, QuestionViewModel>()
                .ForMember(q => q.QuestionId, ex => ex.MapFrom(q => q.Id))
                .ReverseMap();

            CreateMap<Answer, AnswersViewModel>()
                .ReverseMap();

            CreateMap<AnswerCharacteristic, AnswerCharacteristicsViewModel>()
                .ReverseMap();
        }
    }
}
