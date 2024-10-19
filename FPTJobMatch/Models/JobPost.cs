using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FPTJobMatch.Models
{
    public class JobPost
    {
        public int Id { get; set; }
        public string JobName { get; set; }
        public string Description { get; set; }
        public string Industry { get; set; }
        public string RequireSkill { get; set; }
        [Required(ErrorMessage = "Salary is required.")]
        [Range(0, 99999999, ErrorMessage = "Salary must be a positive number and cannot exceed 8 digits.")]
        public int Salary { get; set; }
        public string Image { get; set; }

        public string EmployerId { get; set; }
        public User Employer { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public ICollection<Application> Applications { get; set; }

    }
}