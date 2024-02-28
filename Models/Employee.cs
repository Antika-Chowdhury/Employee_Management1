using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Employee_Management1.Models
{
    public class Employee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EmployeeId { get; set; }
        public string FirstName { get; set; } = default;
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public DateTime DateofBirth { get; set; }
        public int? SalaryId { get; set; }  // Change int to int? to allow null
        public EmployeeSalary EmployeeSalary { get; set; } = default;  // Remove [ForeignKey("SalaryId")]
    }
}