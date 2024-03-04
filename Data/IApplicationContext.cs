using Employee_Management1.Models;
using Microsoft.EntityFrameworkCore;

namespace Employee_Management1.Data
{
    public interface IApplicationContext
    {
        DbSet<Employee> Employee { get; set; }
        DbSet<EmployeeSalary> EmployeeSalary { get; set; }
    }
}