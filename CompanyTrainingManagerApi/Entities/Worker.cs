using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompanyTrainingManagerApi.Entities
{
    public class Worker
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime EmploymentDate { get; set; }
        public string  DepertmentName { get; set; }
        public string JobTitle { get; set; }

        public virtual Address Address { get; set; }
        public int AddressId { get; set; }
        public ICollection<Training> Trainings { get; set; }
    }
}
