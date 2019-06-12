using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace DogBreedApp.Data
{
    public class DogContextFactory : IDesignTimeDbContextFactory<DogContext>
    {
        public DogContext CreateDbContext(string[] args)
        {
            var config = new ConfigurationBuilder()
              .SetBasePath(Directory.GetCurrentDirectory())
              .AddJsonFile("config.json")
              .Build();

            var builder = new DbContextOptionsBuilder<DogContext>();
            builder.UseSqlServer(config.GetConnectionString("DogConnectionString"));

            return new DogContext(builder.Options);
        }
    }
}
