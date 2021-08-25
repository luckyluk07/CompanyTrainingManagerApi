using CompanyTrainingManagerApi.Entities;
using CompanyTrainingManagerApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompanyTrainingManagerApi.Interfaces
{
    public interface ITrainingDefinitionService
    {
        IEnumerable<GetTrainingDefinitionDto> GetAllTrainigDefinitions();
        GetTrainingDefinitionDto GetTrainingDefinitionByItsId(int trainingDefinitionId);
        int CreateTrainingDefinitionWithNewCoach(CreateTrainingDefinitionDto dto);
        void DeleteTrainingDefinitionByItsId(int trainingDefinitionId);
        void UpdateTrainingDefinitionById(int trainingDefinitionId, UpdateTrainingDefinitionDto dto);
    }
}
