using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CompanyTrainingManagerApi.Models
{
    public class UpdateTrainingDefinitionDto
    {
        [Required]
        public string Name { get; set; }
    }
}
