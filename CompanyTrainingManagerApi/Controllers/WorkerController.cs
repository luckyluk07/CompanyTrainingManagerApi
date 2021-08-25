using CompanyTrainingManagerApi.Entities;
using CompanyTrainingManagerApi.Interfaces;
using CompanyTrainingManagerApi.Models;
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
        public ActionResult<IEnumerable<GetWorkerDto>> GetAll()
        {
            var workers = _service.GetAllWorkers();
            return Ok(workers);
        }

        [HttpGet("{workerId}")]
        public ActionResult<GetWorkerDto> GetById([FromRoute] int workerId)
        {
            var worker = _service.GetWorkerByHisId(workerId);
            return Ok(worker);
        }

        [HttpDelete("{workerId}")]
        public ActionResult Delete([FromRoute] int workerId)
        {
            _service.DeleteWorkerByHisId(workerId);
            return NoContent();
        }

        [HttpPost]
        public ActionResult Create([FromBody] CreateWorkerDto dto)
        {
            int workerId = _service.CreateWorkerWithNewAddress(dto);

            return Created($"api/worker/{workerId}", null);
        }

        [HttpPut("{workerId}")]
        public ActionResult Update([FromRoute] int workerId, [FromBody] UpdateWorkerDto dto)
        {
            _service.UpdateWorkerById(workerId, dto);
            return Ok();
        }
    }
}
