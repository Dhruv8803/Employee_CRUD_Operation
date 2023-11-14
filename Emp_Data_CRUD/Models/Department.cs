using System.ComponentModel.DataAnnotations;

namespace Emp_Data_CRUD.Models
{
    public class Department
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Department Name")]
        public string Department_Name { get; set; }

        // Relationships
        public List<Employee> Employees { get; set; }

    }
}
