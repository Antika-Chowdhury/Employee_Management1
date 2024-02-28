using Employee_Management1.Data;
using Employee_Management1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Employee_Management1.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly ApplicationContext context;
        public EmployeeController(ApplicationContext context)
        {
            this.context = context;
        }
        public IActionResult Index()
        {
            var empdata = context.Employee.Include(e => e.EmployeeSalary).ToList();
            return View(empdata);
        }

        public IActionResult AddEmployee()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddEmployee(Employee model)
        {
            if (ModelState.IsValid)
            {
                // Create an instance of EmployeeSalary
                var employeeSalary = new EmployeeSalary
                {
                    Salary = model.EmployeeSalary.Salary,
                    PayDay = model.EmployeeSalary.PayDay
                };

                // Save the employee salary to the database to get the generated SalaryId
                context.EmployeeSalary.Add(employeeSalary);
                context.SaveChanges();

                // Now set the EmployeeSalary property of the Employee object
                var employee = new Employee
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Email = model.Email,
                    Phone = model.Phone,
                    DateofBirth = model.DateofBirth,
                    EmployeeSalary = employeeSalary // Assign the EmployeeSalary object without setting the SalaryId
                };

                // Save the employee to the database
                context.Employee.Add(employee);
                context.SaveChanges();

                return RedirectToAction("Index", "Employee");
            }

            return View();
        }

       
        public IActionResult EmployeeDetails(int id)
        {
            var employee = context.Employee
                                  .Include(e => e.EmployeeSalary) // Include EmployeeSalary data
                                  .FirstOrDefault(e => e.EmployeeId == id);

            if (employee == null)
            {
                return NotFound(); // Or handle the case when employee is not found
            }

            // Construct the employeeModel using the retrieved data
            var employeeModel = new Employee
            {
                EmployeeId = employee.EmployeeId,
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                Email = employee.Email,
                Phone = employee.Phone,
                DateofBirth = employee.DateofBirth,
                SalaryId = employee.SalaryId,
                EmployeeSalary = employee.EmployeeSalary // Assign the loaded EmployeeSalary directly
            };

            return View(employeeModel);
        }


        public IActionResult EmployeeUpdate(int id)
        {
            var employee = context.Employee.Include(e => e.EmployeeSalary).FirstOrDefault(e => e.EmployeeId == id);

            if (employee == null)
            {
                return NotFound(); // Or handle the case when employee is not found
            }

            return View(employee);
        }


        [HttpPost]
        public IActionResult EmployeeUpdate(Employee model)
        {
            if (ModelState.IsValid)
            {
                var employee = context.Employee.Include(e => e.EmployeeSalary).FirstOrDefault(e => e.EmployeeId == model.EmployeeId);

                if (employee == null)
                {
                    return NotFound(); // Or handle the case when employee is not found
                }

                // Update employee details
                employee.FirstName = model.FirstName;
                employee.LastName = model.LastName;
                employee.Email = model.Email;
                employee.Phone = model.Phone;
                employee.DateofBirth = model.DateofBirth;

                // Check if EmployeeSalary exists
                if (employee.EmployeeSalary != null)
                {
                    // Update existing EmployeeSalary
                    employee.EmployeeSalary.Salary = model.EmployeeSalary.Salary;
                    employee.EmployeeSalary.PayDay = model.EmployeeSalary.PayDay;
                }
                else
                {
                    // Create new EmployeeSalary
                    employee.EmployeeSalary = new EmployeeSalary
                    {
                        Salary = model.EmployeeSalary.Salary,
                        PayDay = model.EmployeeSalary.PayDay
                    };
                }

                // Save changes to the database
                context.SaveChanges();

                // Redirect to the employee details page
                return RedirectToAction("Index", "Employee");
            }

            // If the model state is not valid, return the view with errors
            return View();
        }

    }
}
