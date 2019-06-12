using DogBreedApp.Data.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DogBreedApp.Data
{
    public class DogContext : IdentityDbContext<User>
    {
        public DbSet<Breed> Breeds { get; set; }
        public DbSet<Characteristic> Characteristics { get; set; }
        public DbSet<BreedCharacteristic> BreedCharacteristics { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<AnswerCharacteristic> AnswerCharacteristics { get; set; }
        public DbSet<UserAnswer> UserAnswers { get; set; }

        public DogContext(DbContextOptions<DogContext> options) : base(options) { }
        

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<BreedCharacteristic>()
        //        .HasKey(breedCharacteristic => new { breedCharacteristic.BreedId, breedCharacteristic.CharacteristicId });

        //    modelBuilder.Entity<BreedCharacteristic>()
        //        .HasOne(bc => bc.Breed)
        //        .WithMany(bc => bc.BreedCharacteristics)
        //        .HasForeignKey(bc => bc.BreedId);

        //    modelBuilder.Entity<BreedCharacteristic>()
        //        .HasOne(bc => bc.Characteristic)
        //        .WithMany(bc => bc.BreedCharacteristics)
        //        .HasForeignKey(bc => bc.CharacteristicId);
        //}
    }
}
