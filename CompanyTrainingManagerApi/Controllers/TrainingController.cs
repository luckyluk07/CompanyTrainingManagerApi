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
    [Route("api/trainingDef/{trainDefId}/[controller]")]
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
    }
}
