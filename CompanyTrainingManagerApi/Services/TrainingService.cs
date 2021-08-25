﻿using AutoMapper;
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

        public int CreateTraining(int trainDefId, CreateTrainingDto dto)
        {
            var trainingDef = getTrainingDefinition(trainDefId);

            var training = _mapper.Map<Training>(dto);

            training.TrainingDefinition = trainingDef;

            _context.Add(training);
            _context.SaveChanges();

            return training.Id;
        }

        public void DeleteAllTrainings(int trainDefId)
        {
            var trainingDef = getTrainingDefinition(trainDefId);

            _context.Trainings.RemoveRange(trainingDef.Trainings);
            _context.SaveChanges();
        }

        public void DeleteTrainingByItsId(int trainDefId, int trainingId)
        {
            var trainingDef = getTrainingDefinition(trainDefId);

            var training = trainingDef.Trainings
                                .FirstOrDefault(t => t.Id == trainingId);

            if(training is null)
            {
                throw new NotFoundException("Training not found");
            }

            _context.Trainings.Remove(training);
            _context.SaveChanges();
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
        public void UpdateTrainingById(int trainDefId, int trainingId, UpdateTrainingDto dto)
        {
            var trainingDef = getTrainingDefinition(trainDefId);

            var training = trainingDef.Trainings
                                .FirstOrDefault(t => t.Id == trainingId);

            if (training is null)
            {
                throw new NotFoundException("Training not found");
            }

            training.EndDate = dto.EndDate;
            training.StartDate = dto.StartDate;
            training.ExpirationDate = dto.ExpirationDate;

            _context.SaveChanges();
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