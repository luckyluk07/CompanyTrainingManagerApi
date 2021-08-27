using AutoMapper;
using CompanyTrainingManagerApi.Authorization;
using CompanyTrainingManagerApi.Entities;
using CompanyTrainingManagerApi.Enums;
using CompanyTrainingManagerApi.Exceptions;
using CompanyTrainingManagerApi.Interfaces;
using CompanyTrainingManagerApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CompanyTrainingManagerApi.Services
{
    // assign value to create worker IsAUser property than it should work well
    public class WorkerService : IWorkerService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        private readonly IUserContextService _userContextService;
        private readonly IAuthorizationService _authorizationService;

        public WorkerService(AppDbContext context, IMapper mapper, IAuthorizationService authorizationService, IUserContextService userContextService)
        {
            _context = context;
            _mapper = mapper;
            _userContextService = userContextService;
            _authorizationService = authorizationService;
        }

        public int CreateWorkerWithNewAddress(CreateWorkerDto dto)
        {
            var worker = _mapper.Map<Worker>(dto);

            worker.IsAUserId = _userContextService.UserId;

            _context.Workers.Add(worker);
            _context.SaveChanges();

            return worker.Id;
        }

        public void DeleteWorkerByHisId(int workerId)
        {
            var worker = _context.Workers
                            .FirstOrDefault(w => w.Id == workerId);

            if(worker is null)
            {
                throw new NotFoundException("Worker not found");
            }

            var authorizationResult = _authorizationService.AuthorizeAsync(_userContextService.User, worker, new ResourceOperationRequirement(ResourceOperation.Delete)).Result;

            if (!authorizationResult.Succeeded)
            {
                throw new ForbidException();
            }

            _context.Remove(worker);
            _context.SaveChanges();
        }

        public IEnumerable<GetWorkerDto> GetAllWorkers()
        {
            var workers = _context.Workers
                                .Include(w => w.Address)
                                .ToList();

            var workersResult = _mapper.Map<IEnumerable<GetWorkerDto>>(workers);

            return workersResult;
        }

        public GetWorkerDto GetWorkerByHisId(int workerId)
        {
            var worker = _context.Workers
                            .Include(w => w.Address)
                            .FirstOrDefault(w => w.Id == workerId);

            if(worker is null)
            {
                throw new NotFoundException("Worker not found");
            }

            var workerResult = _mapper.Map<GetWorkerDto>(worker);

            return workerResult;
        }

        public void UpdateWorkerById(int workerId, UpdateWorkerDto dto)
        {
            var worker = _context.Workers
                            .FirstOrDefault(w => w.Id == workerId);

            if(worker is null)
            {
                throw new NotFoundException("Worker not found");
            }

            var authorizationResult = _authorizationService.AuthorizeAsync(_userContextService.User, worker, new ResourceOperationRequirement(ResourceOperation.Update)).Result;

            if (!authorizationResult.Succeeded)
            {
                throw new ForbidException();
            }

            worker.DepartmentName = dto.DepartmentName;
            worker.JobTitle = dto.JobTitle;

            _context.SaveChanges();
        }
    }
}
