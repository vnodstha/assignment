using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MachineLearningCompany.Models
{
    public class MachineLearningCompanyFeedback
    {
        public int Id { get; set; }

        [Required]
        [ReadOnly(true)]
        public DateTime Date { get; set; }

        [Required]
        [ReadOnly(true)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Name should be entered")]
        public string Heading { get; set; }

        [Required(ErrorMessage = "Heading should be entered")]
        public string Company { get; set; }

        [Required(ErrorMessage = "Feedback should be entered")]
        public string Feedback { get; set; }

        [Range(0, 5)]
        public int Rating { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Must be a positive number")]
        public int Agree { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Must be a positive number")]
        public int Disagree { get; set; }
    }
}
