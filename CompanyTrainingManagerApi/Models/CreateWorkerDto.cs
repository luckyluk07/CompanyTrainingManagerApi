using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompanyTrainingManagerApi.Models
{
    public class CreateWorkerDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime EmploymentDate { get; set; }
        public string DepertmentName { get; set; }
        public string JobTitle { get; set; }

        //address part
        public string Country { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string PostalCode { get; set; }
        public int HomeNumber { get; set; }
        public int? FlatNumber { get; set; }
    }
}
