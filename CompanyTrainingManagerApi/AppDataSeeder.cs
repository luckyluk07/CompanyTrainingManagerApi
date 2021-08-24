using CompanyTrainingManagerApi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompanyTrainingManagerApi
{
    public class AppDataSeeder
    {
        private readonly AppDbContext _context;

        public AppDataSeeder(AppDbContext context)
        {
            _context = context;
        }

        public void Seed()
        {
            if (!_context.Addresses.Any())
            {
                var addresses = getAddresses();
                _context.Addresses.AddRange(addresses);
                _context.SaveChanges();
            }

            if (!_context.Coaches.Any())
            {
                var coaches = getCoaches();
                _context.Coaches.AddRange(coaches);
                _context.SaveChanges();
            }

            if (!_context.TrainingsDefinitions.Any())
            {
                var trainingDefinitions = getTrainingDefinitons();
                _context.TrainingsDefinitions.AddRange(trainingDefinitions);
                _context.SaveChanges();
            }

            if (!_context.Trainings.Any())
            {
                var trainings = getTrainings();
                _context.Trainings.AddRange(trainings);
                _context.SaveChanges();
            }

            if (!_context.Workers.Any())
            {
                var workers = getWorkers();
                _context.Workers.AddRange(workers);
                _context.SaveChanges();
            }
        }

        private IEnumerable<Address> getAddresses()
        {
            var addresses = new List<Address>()
            {
                new Address()
                {
                    Country = "Poland",
                    City = "Lubawa",
                    PostalCode = "14-260",
                    Street = "Warszaska",
                    HomeNumber = 5
                },
                new Address()
                {
                    Country = "Poland",
                    City = "Lubawa",
                    PostalCode = "14-260",
                    Street = "Rynek",
                    HomeNumber = 2
                },
            };

            return addresses;
        }

        private IEnumerable<Coach> getCoaches()
        {
            var coaches = new List<Coach>()
            {
                new Coach()
                {
                    Name = "Jan",
                    Surname = "Kowalski",
                    CompanyName = "TestPG"
                }
            };

            return coaches;
        }

        private IEnumerable<TrainingDefinition> getTrainingDefinitons()
        {
            var trainingDefinitons = new List<TrainingDefinition>()
            {
                new TrainingDefinition()
                {
                    Name = "safe office",
                    Type = "bhp",
                    IsOnline = false,
                    AddressId = 1,
                    CoachId = 1
                }
            };

            return trainingDefinitons;
        }

        private IEnumerable<Training> getTrainings()
        {
            var trainings = new List<Training>()
            {
                new Training()
                {
                    StartDate = new DateTime(2020,1,1),
                    EndDate = new DateTime(2020,1,3),
                    ExpirationDate = new DateTime(2020,2,2),
                    TrainingDefinitionId = 1
                }
            };

            return trainings;
        }

        private IEnumerable<Worker> getWorkers()
        {
            var workers = new List<Worker>()
            {
                new Worker()
                {
                    Name = "Wojciech",
                    Surname = "Szczesny",
                    BirthDate = new DateTime(1990,5,7),
                    EmploymentDate = new DateTime(2019,3,3),
                    AddressId = 2,
                    DepartmentName = "accountancy",
                    JobTitle = "senior accountant",
                    Trainings = new List<Training>()
                    {
                        new Training()
                        {
                            StartDate = new DateTime(2020,5,5),
                            EndDate = new DateTime(2020,5,10),
                            ExpirationDate = new DateTime(2020,7,7),
                            TrainingDefinitionId = 1
                        }
                    }
                }
            };

            return workers;
        }
    }
}
