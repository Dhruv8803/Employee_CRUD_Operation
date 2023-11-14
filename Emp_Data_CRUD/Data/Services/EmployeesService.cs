using Emp_Data_CRUD.Data.Enum;
using Emp_Data_CRUD.Data.ViewModels;
using Emp_Data_CRUD.Models;
using Microsoft.EntityFrameworkCore;

namespace Emp_Data_CRUD.Data.Services
{
    public class EmployeesService : IEmployeesService
    {
        private AppDbContext _context;
        public EmployeesService(AppDbContext context)
        {
            _context = context;
        }

      
        public async Task DeleteEmployeeAsync(Employee employee)
        {
            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Employee>> GetAll()
        {
            var result = await _context.Employees.Include(n => n.Department).ToListAsync();
            return result;
        }

        public async Task<Employee> GetEmployeeByIDAsync(int id)
        {
            var EmployeeDetails = await _context.Employees.Include(d => d.Department).FirstOrDefaultAsync(n => n.Id == id); 

            return EmployeeDetails;
        }

        public async Task<NewEmployeeDropdownsVM> GetNewEmployeeDropdownsValues()
        {
            var response = new NewEmployeeDropdownsVM(){ 
                Departments = await _context.Departments.ToListAsync() 
            };
            
            return response;
        }

        public async Task AddNewEmployeeAsync(NewEmployeeVM employee)
        {
            var newEmployee = new Employee()
            {
                Employee_Name = employee.Employee_Name,
                Email = employee.Email,
                PhoneNumber = employee.PhoneNumber,
                Gender = employee.Gender,
                DOB = employee.DOB,
                DepartmentId = employee.DepartmentId
            };

            await _context.Employees.AddAsync(newEmployee);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateEmployeeAsync(NewEmployeeVM employee)
        {
            var dbEmployee = await _context.Employees.FirstOrDefaultAsync(n => n.Id == employee.Id);

            if (dbEmployee != null)
            {
                dbEmployee.Employee_Name = employee.Employee_Name;
                dbEmployee.Email = employee.Email;
                dbEmployee.PhoneNumber = employee.PhoneNumber;
                dbEmployee.Gender = employee.Gender;
                dbEmployee.DOB = employee.DOB;
                dbEmployee.DepartmentId = employee.DepartmentId;
               
                await _context.SaveChangesAsync();

            }

            //
            
        }
    }
}
