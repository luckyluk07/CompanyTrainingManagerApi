using CompanyTrainingManagerApi.Entities;
using CompanyTrainingManagerApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompanyTrainingManagerApi.Interfaces
{
    public interface IWorkerService
    {
        IEnumerable<Worker> GetAllWorkers();
        Worker GetWorkerByHisId(int workerId);
        void DeleteWorkerByHisId(int workerId);
        int CreateWorkerWithNewAddress(CreateWorkerDto dto);
        void UpdateWorkerById(int workerId, UpdateWorkerDto dto);
    }
}
