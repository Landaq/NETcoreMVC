using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAnnotiationsDemo.Models
{
    public class Employee
    {
        [Required(ErrorMessage = "First Name is Required")]
        [StringLength(30, MinimumLength = 5, ErrorMessage ="First name should be between 5 and 30 characters")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last Name is Required")]
        [StringLength(30, MinimumLength = 4,ErrorMessage = "Last name should be between 4~30 characters")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "UserName is required")]
        [RegularExpression(@"^(([A-Za-z]+[\s]{1}[A-Za-z]+)|([A-Za-z]+))$",ErrorMessage = "UserName can contain the first and last names with a single spce."+"The Last Name is optional. Only Upper and lower case alphabets are allowed")]
        public string UserName {  get; set; }

        [Required(ErrorMessage = "Please Enter the Email address")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Please enter a Valid email")]
        public string EmailId { get; set; }

        [Required(ErrorMessage = "Please Select the Department")]
        public Department? Department { get; set; }

        [Required(ErrorMessage = "Age is Required")]
        [Range(18,60,ErrorMessage = "Age must be between 18 and 60")]
        public int Age {  get; set; }

        [Required(ErrorMessage = "Please Select the Gender")]
        public Gender Gender { get; set; }

        [MinLength(5, ErrorMessage = "The Address must be at least 5 characters")]
        [MaxLength(50, ErrorMessage = "The Address cannot be more than 50 characters")]
        public string Address { get; set; }

        [DataType(DataType.Url, ErrorMessage = "Please Enter a Valid URL")]
        public string? WebsiteURL { get; set; }

        [Range(10000,1000000, ErrorMessage = "Please Enter a Value between 10000 and 1000000")]
        [DataType(DataType.Currency)]
        [Column(TypeName ="decima(18, 2)")]
        public decimal Salary { get; set; }

        public bool IsPermanent { get; set; }

        [Required(ErrorMessage = "Date of Joining is required")]
        [DataType(DataType.Date, ErrorMessage = "Invalid Date Format")]
        [ValidJoiningDate(ErrorMessage = "Date of Joining Cannot be Future Date")]
        public DateTime DateOfJoining { get; set; }

        public List<string> SkillSets { get; set; } = new List<string>();

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Password is Required")]
        [PasswordStrength]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Confirm Password is Required")]
        [Compare("Password", ErrorMessage = "Password and Confirm Password do not match")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Date of Birth is required")]
        [DataType(DataType.Date, ErrorMessage = "Invalid Date Format")]
        [MinimumAge(18,ErrorMessage ="You must be at least 18 years old.")]
        public DateTime DateOfBirth { get; set; }

        [DateRangeValidation("ToDate", ErrorMessage = "From date cannot be in the future and must be before To date.")]
        public DateTime? FromDate { get; set; }

        [DateRangeValidation("FromDate", ErrorMessage = "To date is required if From date is selected and cannot be in the future or before From date.")]
        public DateTime? ToDate { get; set; }
    }
}
