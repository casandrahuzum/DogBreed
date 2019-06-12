using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace DogBreedApp.Migrations
{
    public partial class InitialDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DogBreeds",
                columns: table => new
                {
                    Name = table.Column<string>(nullable: false),
                    AdaptsWellToApartmentLiving = table.Column<int>(nullable: false),
                    AffectionateWithFamily = table.Column<int>(nullable: false),
                    AmountOfShedding = table.Column<int>(nullable: false),
                    DogFriendly = table.Column<int>(nullable: false),
                    DroolingPotential = table.Column<int>(nullable: false),
                    EasyToGroom = table.Column<int>(nullable: false),
                    EasyToTrain = table.Column<int>(nullable: false),
                    EnergyLevel = table.Column<int>(nullable: false),
                    ExerciseNeeds = table.Column<int>(nullable: false),
                    FriendlyTowardStrangers = table.Column<int>(nullable: false),
                    GeneralHealth = table.Column<int>(nullable: false),
                    GoodForNoviceOwners = table.Column<int>(nullable: false),
                    IncrediblyKidFriendlyDogs = table.Column<int>(nullable: false),
                    Intelligence = table.Column<int>(nullable: false),
                    Intensity = table.Column<int>(nullable: false),
                    PotentialForMouthiness = table.Column<int>(nullable: false),
                    PotentialForPlayfulness = table.Column<int>(nullable: false),
                    PotentialForWeightGain = table.Column<int>(nullable: false),
                    PreyDrive = table.Column<int>(nullable: false),
                    SensitivityLevel = table.Column<int>(nullable: false),
                    Size = table.Column<int>(nullable: false),
                    TendencyToBarkOrHowl = table.Column<int>(nullable: false),
                    ToleratesBeingAlone = table.Column<int>(nullable: false),
                    ToleratesColdWeather = table.Column<int>(nullable: false),
                    ToleratesHotWeather = table.Column<int>(nullable: false),
                    WanderlustPotential = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DogBreeds", x => x.Name);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DogBreeds");
        }
    }
}
