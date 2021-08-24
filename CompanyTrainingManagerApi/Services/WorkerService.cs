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

        public IEnumerable<Worker> GetAllWorkers()
        {
            var workers = _context.Workers
                                .ToList();
            return workers;
        }

        public Worker GetWorkerByHisId(int workerId)
        {
            var worker = _context.Workers
                            .FirstOrDefault(w => w.Id == workerId);

            if(worker is null)
            {
                throw new NotFoundException("Worker not found");
            }

            return worker;
        }
    }
}
