using CompanyTrainingManagerApi.Entities;
using CompanyTrainingManagerApi.Interfaces;
using CompanyTrainingManagerApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompanyTrainingManagerApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "HrManager, Admin")]
    public class TrainingDefinitionController : ControllerBase
    {
        private readonly ITrainingDefinitionService _service;

        public TrainingDefinitionController(ITrainingDefinitionService service)
        {
            _service = service;
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult<IEnumerable<GetTrainingDefinitionDto>> GetAll()
        {
            var trainingDefinitions = _service.GetAllTrainigDefinitions();

            return Ok(trainingDefinitions);
        }

        [HttpGet("{trainingDefinitionId}")]
        public ActionResult<GetTrainingDefinitionDto> GetById([FromRoute] int trainingDefinitionId)
        {
            var trainingDefinition = _service.GetTrainingDefinitionByItsId(trainingDefinitionId);

            return Ok(trainingDefinition);
        }

        [HttpPost]
        public ActionResult Create([FromBody] CreateTrainingDefinitionDto dto)
        {
            var trainingDefinitionId = _service.CreateTrainingDefinitionWithNewCoach(dto);

            return Created($"api/TrainingDefinition/{trainingDefinitionId}", null);
        }

        [HttpDelete("{trainingDefinitionId}")]
        public ActionResult Delete([FromRoute] int trainingDefinitionId)
        {
            _service.DeleteTrainingDefinitionByItsId(trainingDefinitionId);

            return NoContent();
        }

        [HttpPut("{trainingDefinitionId}")]
        public ActionResult Update([FromRoute] int trainingDefinitionId, [FromBody] UpdateTrainingDefinitionDto dto)
        {
            _service.UpdateTrainingDefinitionById(trainingDefinitionId, dto);

            return Ok();
        }
    }
}
