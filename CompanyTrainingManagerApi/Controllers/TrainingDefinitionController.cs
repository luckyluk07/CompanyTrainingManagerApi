using CompanyTrainingManagerApi.Entities;
using CompanyTrainingManagerApi.Interfaces;
using CompanyTrainingManagerApi.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompanyTrainingManagerApi.Controllers
{
    [Route("api/[controller]")]
    public class TrainingDefinitionController : ControllerBase
    {
        private readonly ITrainingDefinitionService _service;

        public TrainingDefinitionController(ITrainingDefinitionService service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult<IEnumerable<TrainingDefinition>> GetAll()
        {
            var trainingDefinitions = _service.GetAllTrainigDefinitions();

            return Ok(trainingDefinitions);
        }

        [HttpGet("{trainingDefinitionId}")]
        public ActionResult<TrainingDefinition> GetById([FromRoute] int trainingDefinitionId)
        {
            var trainingDefinition = _service.GetTrainingDefinitionByItsId(trainingDefinitionId);

            return Ok(trainingDefinition);
        }

        //[HttpPost]
        //public ActionResult Create([FromBody] CreateTrainingDefinitionDto dto)
        //{

        //}
    }
}
