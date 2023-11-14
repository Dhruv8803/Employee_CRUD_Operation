using Emp_Data_CRUD.Models;

namespace Emp_Data_CRUD.Data.ViewModels
{
    public class NewEmployeeDropdownsVM
    {
        public NewEmployeeDropdownsVM()
        {
            Departments = new List<Department>();
        }
        public List<Department> Departments { get; set; }

    }
}
