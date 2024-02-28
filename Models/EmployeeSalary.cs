using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Employee_Management1.Models
{
    public class EmployeeSalary
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SalaryId { get; set; }  // Remove [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Salary { get; set; }
        public DateTime PayDay { get; set; }
    }
}