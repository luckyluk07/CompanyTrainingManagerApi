using CompanyTrainingManagerApi.Entities;
using CompanyTrainingManagerApi.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompanyTrainingManagerApi.Controllers
{
    [Route("api/[controller]")]
    public class WorkerController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IWorkerService _service;

        public WorkerController(AppDbContext context, IWorkerService service)
        {
            _context = context;
            _service = service;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Worker>> GetAll()
        {
            var workers = _service.GetAllWorkers();
            return Ok(workers);
        }

        [HttpGet("{workerId}")]
        public ActionResult<Worker> GetById([FromRoute] int workerId)
        {
            var worker = _service.GetWorkerByHisId(workerId);
            return Ok(worker);
        }
    }
}
