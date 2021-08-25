using CompanyTrainingManagerApi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompanyTrainingManagerApi.Models
{
    public class GetTrainingDefinitionDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public bool IsOnline { get; set; }
        public Address Address { get; set; }
        public Coach Coach { get; set; }
        public virtual IEnumerable<GetTrainingDto> Trainings { get; set; }
    }
}
