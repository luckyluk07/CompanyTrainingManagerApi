using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompanyTrainingManagerApi.Entities
{
    public class Training
    {
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime ExpirationDate { get; set; }

        public virtual TrainingDefinition TrainingDefinition { get; set; }
        public int TrainingDefinitionId { get; set; }
        public ICollection<Worker> Workers { get; set; }
    }
}
