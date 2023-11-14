using Emp_Data_CRUD.Data;
using Emp_Data_CRUD.Data.Services;
using Emp_Data_CRUD.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Emp_Data_CRUD.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly IEmployeesService _service;

        public EmployeesController(IEmployeesService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var data = await _service.GetAll();
            return View(data);
        }


        //GET: Employees/Create

        public async Task<IActionResult> Create()
        {
            var employeeDropdownsData = await _service.GetNewEmployeeDropdownsValues();
            ViewBag.Departments = new SelectList(employeeDropdownsData.Departments,"Id", "Department_Name");
            var data = await _service.GetAll();
            return View();
        }

        
        [HttpPost]
        public async Task<IActionResult> Create([Bind("Employee_Name,DepartmentId,Email,PhoneNumber,Gender,DOB")]NewEmployeeVM employee)
        {
            if(!ModelState.IsValid)
            {
                var employeeDropdownsData = await _service.GetNewEmployeeDropdownsValues();

                ViewBag.Departments = new SelectList(employeeDropdownsData.Departments, "Id", "Department_Name");

                // Console.WriteLine("Invalid");
                // Log or inspect ModelState errors
                // foreach (var error in ModelState.Values.SelectMany(v => v.Errors))
                // {
                    // Log or inspect the error message
                    // var errorMessage = error.ErrorMessage;
                    // var exception = error.Exception; // If there is an exception associated with the error
                    // Console.WriteLine(errorMessage);
                    // Console.WriteLine(exception);
                    // Console.WriteLine(error);
                // }
                // Console.WriteLine("Invalid");
                
                return View(employee);
            }

            // Console.WriteLine("Valid");

            await _service.AddNewEmployeeAsync(employee);
            return RedirectToAction(nameof(Index));
        }


        //GET: Employees/Edit

        public async Task<IActionResult> Edit(int id)
        {

            var employeeDetails = await _service.GetEmployeeByIDAsync(id);

            if (employeeDetails == null) return View("NotFound");

            var response = new NewEmployeeVM()
            {
                Id = employeeDetails.Id,
                Employee_Name = employeeDetails.Employee_Name,
                Email = employeeDetails.Email,
                PhoneNumber = employeeDetails.PhoneNumber,
                Gender = employeeDetails.Gender,
                DOB = employeeDetails.DOB,
                DepartmentId = employeeDetails.DepartmentId
            };

            var employeeDropdownsData = await _service.GetNewEmployeeDropdownsValues();
            ViewBag.Departments = new SelectList(employeeDropdownsData.Departments, "Id", "Department_Name");
            var data = await _service.GetAll();

            return View(response);
        }


        [HttpPost]
        public async Task<IActionResult> Edit(int id,NewEmployeeVM employee)
        {
            if (id != employee.Id) return View("NotFound");


            if (!ModelState.IsValid)
            {

                var employeeDropdownsData = await _service.GetNewEmployeeDropdownsValues();

                ViewBag.Departments = new SelectList(employeeDropdownsData.Departments, "Id", "Department_Name");

                // Console.WriteLine("Invalid");
                // Log or inspect ModelState errors
                // foreach (var error in ModelState.Values.SelectMany(v => v.Errors))
                // {
                    // Log or inspect the error message
                    // var errorMessage = error.ErrorMessage;
                    // var exception = error.Exception; // If there is an exception associated with the error
                    // Console.WriteLine(errorMessage);
                    // Console.WriteLine(exception);
                    // Console.WriteLine(error);
                // }
                // Console.WriteLine("Invalid");

                return View(employee);
            }

            // Console.WriteLine("Valid");

            await _service.UpdateEmployeeAsync(employee);
            return RedirectToAction(nameof(Index));
        }

        // Post Delete

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var employeeDetails = await _service.GetEmployeeByIDAsync(id);

            if (employeeDetails == null) return View("NotFound");

            if (id != employeeDetails.Id) return View("NotFound");

            await _service.DeleteEmployeeAsync(employeeDetails);
            return RedirectToAction(nameof(Index));
        }

    }
}
