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
    public class WorkerService : IWorkerService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public WorkerService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public int CreateWorkerWithNewAddress(CreateWorkerDto dto)
        {
            var worker = _mapper.Map<Worker>(dto);

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

            worker.DepartmentName = dto.DepartmentName;
            worker.JobTitle = dto.JobTitle;

            _context.SaveChanges();
        }
    }
}
