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
    [Route("api/trainingDefinition/{trainDefId}/[controller]")]
    public class TrainingController : ControllerBase
    {
        private readonly ITrainingService _service;

        public TrainingController(ITrainingService service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult<IEnumerable<GetTrainingDto>> GetAll([FromRoute] int trainDefId)
        {
            var trainings = _service.GetAllByDefId(trainDefId);

            return Ok(trainings);
        }

        [HttpGet("{trainingId}")]
        public ActionResult<GetTrainingDto> GetById([FromRoute] int trainDefId,[FromRoute]int trainingId)
        {
            var training = _service.GetTrainingByItsId(trainDefId, trainingId);

            return Ok(training);
        }

        [HttpPost]
        public ActionResult Create([FromRoute] int trainDefId, [FromBody] CreateTrainingDto dto)
        {
            var trainingId = _service.CreateTraining(trainDefId, dto);

            return Created($"api/trainingDefinition/{trainDefId}/Training/{trainingId}", null);
        }

        [HttpDelete("{trainingId}")]
        public ActionResult DeleteById([FromRoute] int trainDefId, [FromRoute] int trainingId)
        {
            _service.DeleteTrainingByItsId(trainDefId, trainingId);

            return NoContent();
        }

        [HttpDelete]
        public ActionResult DeleteAll([FromRoute] int trainDefId)
        {
            _service.DeleteAllTrainings(trainDefId);

            return NoContent();
        }

        [HttpPut("{trainingId}")]
        public ActionResult UpdateById([FromRoute] int trainDefId, [FromRoute] int trainingId, [FromBody] UpdateTrainingDto dto)
        {
            _service.UpdateTrainingById(trainDefId, trainingId, dto);

            return Ok();
        }

    }
}
