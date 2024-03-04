using Employee_Management1.Models;
using Microsoft.EntityFrameworkCore;

namespace Employee_Management1.Data
{
    public class ApplicationContext : DbContext, IApplicationContext
    {
        public ApplicationContext(DbContextOptions options) : base(options) { }

        public DbSet<Employee> Employee { get; set; }
        public DbSet<EmployeeSalary> EmployeeSalary { get; set; }
    }
}
