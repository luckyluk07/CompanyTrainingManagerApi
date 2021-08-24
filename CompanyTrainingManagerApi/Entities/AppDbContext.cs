using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompanyTrainingManagerApi.Entities
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Address> Addresses { get; set; }
        public DbSet<Coach> Coaches { get; set; }
        public DbSet<TrainingDefinition> TrainingsDefinitions { get; set; }
        public DbSet<Training> Trainings { get; set; }
        public DbSet<Worker> Workers { get; set; }
    }
}
