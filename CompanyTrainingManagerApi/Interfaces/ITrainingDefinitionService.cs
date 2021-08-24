using CompanyTrainingManagerApi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompanyTrainingManagerApi.Interfaces
{
    public interface ITrainingDefinitionService
    {
        IEnumerable<TrainingDefinition> GetAllTrainigDefinitions();
        TrainingDefinition GetTrainingDefinitionByItsId(int trainingDefinitionId);
    }
}
