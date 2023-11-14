using Emp_Data_CRUD.Data.ViewModels;
using Emp_Data_CRUD.Models;

namespace Emp_Data_CRUD.Data.Services
{
    public interface IEmployeesService
    {
        Task<IEnumerable<Employee>> GetAll();
        Task<Employee> GetEmployeeByIDAsync(int id);
        Task<NewEmployeeDropdownsVM> GetNewEmployeeDropdownsValues();
        Task AddNewEmployeeAsync(NewEmployeeVM employee);
        Task UpdateEmployeeAsync(NewEmployeeVM employee);
        Task DeleteEmployeeAsync(Employee employee);
    }
}
