using EmployeeCRUDWithValidation.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeCRUDWithValidation.Controllers
{
    public class EmployeeController : Controller
    {
        private static List<Employee> employees;

        static EmployeeController()
        {
            employees = new List<Employee>()
            {
                new Employee(){ID = 1, Name = "Adarsh",DoB = new DateTime(1995,08,12),DoJ = new DateTime(2021,06,29),
                    Salary = 42000,Department = "HR",Password = "jfkdfjdkfj@"},
                new Employee(){ID = 2, Name = "Darshan",DoB = new DateTime(1996,06,12),DoJ = new DateTime(2022,12,29),
                    Salary = 45000,Department = "IT",Password = "jfAdfjdkfj@"}
                
            };
        }

        // GET: EmployeeController
        public ActionResult Index()
        {
            return View(employees);
        }

        // GET: EmployeeController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EmployeeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Employee employee)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    if (employees.Any(e => e.ID == employee.ID))
                    {
                        ModelState.AddModelError("ID", "ID is already exists, it should be unique");

                        return View(employee);  
                    }
                    else
                    {
                        employees.Add(employee);

                        return RedirectToAction(nameof(Index));  
                    }
                }
                else
                {
                    return View();
                }
            }
            catch
            {
                return View();
            }
        }

    }
}
