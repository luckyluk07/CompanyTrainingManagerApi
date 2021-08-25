using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompanyTrainingManagerApi.Models
{
    public class CreateTrainingDefinitionDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public bool IsOnline { get; set; }
        //address part
        public int? AddressId { get; set; }

        //coach part
        public string CoachName { get; set; }
        public string CoachSurname { get; set; }
        public string CoachCompanyName { get; set; }
    }
}
