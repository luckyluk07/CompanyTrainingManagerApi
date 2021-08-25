using AutoMapper;
using CompanyTrainingManagerApi.Entities;
using CompanyTrainingManagerApi.Exceptions;
using CompanyTrainingManagerApi.Interfaces;
using CompanyTrainingManagerApi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompanyTrainingManagerApi.Services
{
    public class TrainingService : ITrainingService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public TrainingService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public GetTrainingDto GetTrainingByItsId(int trainDefId, int trainingId)
        {
            var trainingDef = getTrainingDefinition(trainDefId);

            var training = trainingDef.Trainings
                                .FirstOrDefault(t => t.Id == trainingId);

            if(training is null)
            {
                throw new NotFoundException("Training not found");
            }

            var trainingResult = _mapper.Map<GetTrainingDto>(training);

            return trainingResult;
        }

        IEnumerable<GetTrainingDto> ITrainingService.GetAllByDefId(int trainDefId)
        {
            var trainingDef = getTrainingDefinition(trainDefId);

            var trainings = _mapper.Map<IEnumerable<GetTrainingDto>>(trainingDef.Trainings);

            return trainings;
        }

        private TrainingDefinition getTrainingDefinition(int trainDefId)
        {
            var trainingDef = _context.TrainingsDefinitions
                                               .Include(d => d.Trainings)
                                               .FirstOrDefault(d => d.Id == trainDefId);

            if (trainingDef is null)
            {
                throw new NotFoundException("Training definition not found");
            }

            return trainingDef;
        }
    }
}
