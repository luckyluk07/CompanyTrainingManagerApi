using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompanyTrainingManagerApi.Entities
{
    public class TrainingDefinition
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public bool IsOnline { get; set; }
        public int? AddressId { get; set; }
        public virtual Address Address { get; set; }
        public int CoachId { get; set; }
        public virtual Coach Coach { get; set; }
        public virtual IEnumerable<Training> Trainings { get; set; }
    }
}
