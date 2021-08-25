using AutoMapper;
using CompanyTrainingManagerApi.Entities;
using CompanyTrainingManagerApi.Exceptions;
using CompanyTrainingManagerApi.Interfaces;
using CompanyTrainingManagerApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompanyTrainingManagerApi.Services
{
    public class TrainingDefinitionService : ITrainingDefinitionService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public TrainingDefinitionService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public int CreateTrainingDefinitionWithNewCoach(CreateTrainingDefinitionDto dto)
        {
            var trainingDefinition = _mapper.Map<TrainingDefinition>(dto);

            _context.TrainingsDefinitions.Add(trainingDefinition);
            _context.SaveChanges();

            return trainingDefinition.Id;
        }

        public void DeleteTrainingDefinitionByItsId(int trainingDefinitionId)
        {
            var trainingDefinition = _context.TrainingsDefinitions
                                            .FirstOrDefault(t => t.Id == trainingDefinitionId);

            if(trainingDefinition is null)
            {
                throw new NotFoundException("Training definition not found");
            }

            _context.Remove(trainingDefinition);
            _context.SaveChanges();

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

        public void UpdateTrainingDefinitionById(int trainingDefinitionId, UpdateTrainingDefinitionDto dto)
        {
            var trainingDefinition = _context.TrainingsDefinitions
                                        .FirstOrDefault(t => t.Id == trainingDefinitionId);

            if(trainingDefinition is null)
            {
                throw new NotFoundException("Training definition not found");
            }

            trainingDefinition.Name = dto.Name;

            _context.SaveChanges();
        }
    }
}
