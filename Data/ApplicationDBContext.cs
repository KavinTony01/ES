using Microsoft.EntityFrameworkCore;
using EmployeePortal.Models;
using EmployeePortal.Models.Entities;

namespace EmployeePortal.Data

{
    public class ApplicationDBContext:DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options):base(options)
        {
                
        }

        public DbSet<Employee> Employees { get; set; }
    }
}
