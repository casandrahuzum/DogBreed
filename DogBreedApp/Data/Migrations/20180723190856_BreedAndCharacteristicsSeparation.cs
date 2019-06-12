using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace DogBreedApp.Migrations
{
    public partial class BreedAndCharacteristicsSeparation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DogBreeds");

            migrationBuilder.CreateTable(
                name: "Breeds",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Breeds", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Characteristics",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Characteristics", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BreedCharacteristic",
                columns: table => new
                {
                    BreedId = table.Column<int>(nullable: false),
                    CharacteristicId = table.Column<int>(nullable: false),
                    Score = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BreedCharacteristic", x => new { x.BreedId, x.CharacteristicId });
                    table.ForeignKey(
                        name: "FK_BreedCharacteristic_Breeds_BreedId",
                        column: x => x.BreedId,
                        principalTable: "Breeds",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BreedCharacteristic_Characteristics_CharacteristicId",
                        column: x => x.CharacteristicId,
                        principalTable: "Characteristics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BreedCharacteristic_CharacteristicId",
                table: "BreedCharacteristic",
                column: "CharacteristicId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BreedCharacteristic");

            migrationBuilder.DropTable(
                name: "Breeds");

            migrationBuilder.DropTable(
                name: "Characteristics");

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
    }
}
