using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Emp_Data_CRUD.Data.Enum;

namespace Emp_Data_CRUD.Models
{
    public class Employee
    {
        [Key]
        [Display(Name = "Employee ID")]
        public int Id { get; set; }

        [Display(Name = "Employee Name")]
        [Required(ErrorMessage = "Employee Name is required.")]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Employee Name should only contain alphabets.")]
        public string Employee_Name { get; set; }


        [Display(Name = "Email")]
        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Enter a valid email address.")]
        public string Email { get; set; }


        [Display(Name = "Phone Number")]
        [Required(ErrorMessage = "Phone Number is required.")]
        [RegularExpression(@"^[0-9]+$", ErrorMessage = "Phone Number should only contain numerics.")]
        [StringLength(10, MinimumLength = 10, ErrorMessage = "Phone Number must be contain exactly 10 digits.")]
        public string PhoneNumber { get; set; }


        [Display(Name = "Gender")]
        [Required(ErrorMessage = "Gender is required.")]
        public Gender Gender { get; set; }


        [Display(Name = "Date Of Birth")]
        [Required(ErrorMessage = "Date Of Birth is required.")]
        public DateTime DOB { get; set; }

        // Relationships
        public int DepartmentId { get; set; }
        [ForeignKey("DepartmentId")]
        public Department Department { get; set; }

    }
}
