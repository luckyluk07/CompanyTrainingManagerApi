using CompanyTrainingManagerApi.Entities;
using CompanyTrainingManagerApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompanyTrainingManagerApi.Interfaces
{
    public interface ITrainingService
    {
        IEnumerable<GetTrainingDto> GetAllByDefId(int trainDefId);
        GetTrainingDto GetTrainingByItsId(int trainDefId, int trainingId);
        int CreateTraining(int trainDefId, CreateTrainingDto dto);
        void DeleteTrainingByItsId(int trainDefId, int trainingId);
        void DeleteAllTrainings(int trainDefId);
        void UpdateTrainingById(int trainDefId, int trainingId, UpdateTrainingDto dto);
    }
}
