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
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>()
                .Property(r => r.Name)
                .IsRequired();

            modelBuilder.Entity<User>()
                .Property(u => u.Email)
                .IsRequired();

            modelBuilder.Entity<User>()
                .Property(u => u.PasswordHash)
                .IsRequired();

            modelBuilder.Entity<User>()
                .Property(u => u.RoleId)
                .IsRequired();

            modelBuilder.Entity<Worker>()
                .Property(w => w.Name)
                .IsRequired();

            modelBuilder.Entity<Worker>()
                .Property(w => w.Surname)
                .IsRequired();

            modelBuilder.Entity<Coach>()
                .Property(c => c.Name)
                .IsRequired();

            modelBuilder.Entity<Coach>()
                .Property(c => c.Surname)
                .IsRequired();
        }
    }
}
