using CompanyTrainingManagerApi.Entities;
using CompanyTrainingManagerApi.Exceptions;
using CompanyTrainingManagerApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompanyTrainingManagerApi.Services
{
    public class WorkerService : IWorkerService
    {
        private readonly AppDbContext _context;

        public WorkerService(AppDbContext context)
        {
            _context = context;
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
