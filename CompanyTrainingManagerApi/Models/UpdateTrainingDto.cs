using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CompanyTrainingManagerApi.Models
{
    public class UpdateTrainingDto
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Start date is required.")]
        public DateTime? StartDate { get; set; }
        [Required]
        public DateTime? EndDate { get; set; }
        [Required]
        public DateTime? ExpirationDate { get; set; }
    }
}
