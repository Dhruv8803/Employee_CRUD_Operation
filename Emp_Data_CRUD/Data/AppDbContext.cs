using Emp_Data_CRUD.Models;
using Microsoft.EntityFrameworkCore;

namespace Emp_Data_CRUD.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Employee> Employees { get; set; }

        public DbSet<Department> Departments { get; set; }
    }
}
