using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompanyTrainingManagerApi.Entities
{
    public class Coach
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string CompanyName { get; set; }

        public virtual IEnumerable<TrainingDefinition> TrainingDefinitions { get; set; }
    }
}
