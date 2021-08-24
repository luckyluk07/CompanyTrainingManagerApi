using CompanyTrainingManagerApi.Entities;
using CompanyTrainingManagerApi.Exceptions;
using CompanyTrainingManagerApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompanyTrainingManagerApi.Services
{
    public class TrainingDefinitionService : ITrainingDefinitionService
    {
        private readonly AppDbContext _context;

        public TrainingDefinitionService(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<TrainingDefinition> GetAllTrainigDefinitions()
        {
            var trainingDefinitions = _context.TrainingsDefinitions
                                            .ToList();
            return trainingDefinitions;
        }

        public TrainingDefinition GetTrainingDefinitionByItsId(int trainingDefinitionId)
        {
            var trainingDefinition = _context.TrainingsDefinitions
                                            .FirstOrDefault(t => t.Id == trainingDefinitionId);

            if(trainingDefinition is null)
            {
                throw new NotFoundException("Training definition not found");
            }

            return trainingDefinition;
        }
    }
}
