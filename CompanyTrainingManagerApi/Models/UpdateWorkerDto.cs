using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CompanyTrainingManagerApi.Models
{
    public class UpdateWorkerDto
    {
        [Required]
        public string DepartmentName { get; set; }
        [Required]
        public string JobTitle { get; set; }
    }
}
