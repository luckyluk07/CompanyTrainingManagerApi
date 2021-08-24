using CompanyTrainingManagerApi.Entities;
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
        public IEnumerable<Worker> GetAllWorkers()
        {
            var workers = _context.Workers
                                .ToList();
            return workers;
        }
    }
}
