using Emp_Data_CRUD.Models;

namespace Emp_Data_CRUD.Data
{
    public class AppDbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();

                context.Database.EnsureCreated();

                // Deparment

                if (!context.Departments.Any())
                {
                    context.Departments.AddRange(new List<Department>()
                    {

                        new Department()
                        {
                            Department_Name = "Administrative"
                        },

                        new Department()
                        {
                            Department_Name = "HR"
                        },

                        new Department()
                        {
                            Department_Name = "Sales"
                        },

                        new Department()
                        {
                            Department_Name = "Management"
                        },

                        new Department()
                        {
                            Department_Name = "IT"
                        },

                        new Department()
                        {
                            Department_Name = "Finance"
                        },

                        new Department()
                        {
                            Department_Name = "Security"
                        },


                    });
                    context.SaveChanges();
                }

                // Employee

                if (!context.Employees.Any())
                {
                    context.Employees.AddRange(new List<Employee>()
                    {

                        new Employee()
                        {
                            Employee_Name = "Dhruv",
                            Email = "shahdhruv8803@gmail.com",
                            PhoneNumber = "9313285866",
                            Gender = Enum.Gender.Male,
                            DOB = DateTime.Now.AddYears(-20).Date,
                            DepartmentId = 1
                        },
                        
                        new Employee()
                        {
                            Employee_Name = "Aesha",
                            Email = "shahaesha28996@gmail.com",
                            PhoneNumber = "9316469215",
                            Gender = Enum.Gender.Female,
                            DOB = DateTime.Now.AddYears(-27).Date,
                            DepartmentId = 2
                        },
                        
                        new Employee()
                        {
                            Employee_Name = "Smita",
                            Email = "shahsmita121070@gmail.com",
                            PhoneNumber = "9265143876",
                            Gender = Enum.Gender.Female,
                            DOB = DateTime.Now.AddYears(-53).Date,
                            DepartmentId = 3
                        },
                        
                        new Employee()
                        {
                            Employee_Name = "Chandrakant",
                            Email = "shahchandrakant15469@gmail.com",
                            PhoneNumber = "9313285866",
                            Gender = Enum.Gender.Male,
                            DOB = DateTime.Now.AddYears(-54).Date,
                            DepartmentId = 4
                        },
                        
                        new Employee()
                        {
                            Employee_Name = "Pallavi",
                            Email = "shukhadiapallavi7384@gmail.com",
                            PhoneNumber = "8401910031",
                            Gender = Enum.Gender.Female,
                            DOB = DateTime.Now.AddDays(-45).Date,
                            DepartmentId = 5
                        },
                        
                        new Employee()
                        {
                            Employee_Name = "Manish",
                            Email = "sukhadiamanish8803@gmail.com",
                            PhoneNumber = "9106498734",
                            Gender = Enum.Gender.Male,
                            DOB = DateTime.Now.AddDays(-44).Date,
                            DepartmentId = 6
                        },
                        
                    });
                    context.SaveChanges();
                }

            }
        }
    }
}
