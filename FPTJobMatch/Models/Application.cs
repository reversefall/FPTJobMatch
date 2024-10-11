using System.ComponentModel.DataAnnotations;

namespace FPTJobMatch.Models
{
    public class Application
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Full name is required.")]
        [StringLength(100, ErrorMessage = "Full name cannot be longer than 100 characters.")]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Full name must contain only letters and spaces.")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Gender is required.")]
        [RegularExpression("^(Male|Female|Other)$", ErrorMessage = "Gender must be either 'Male', 'Female'.")]
        public string Gender { get; set; }

        [Required(ErrorMessage = "Age is required.")]
        [Range(18, 100, ErrorMessage = "Age must be between 16 and 100.")]
        public int Age { get; set; }

        [Required(ErrorMessage = "Location is required.")]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Location can only contain letters.")]
        public string Location { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        [RegularExpression(@"^[\w-\.]+@gmail\.com$", ErrorMessage = "Only Gmail addresses are allowed.")]
        public string Email { get; set; }

        public string Description { get; set; }

        public int JobPostId { get; set; }
        public JobPost JobPost { get; set; }
    }
}
