using EFCoreAssignments.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EFCoreAssignments.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly EmployeeDBContext _employeeDBContext;

        public EmployeeController(EmployeeDBContext context)
        {
            _employeeDBContext = context;
        }

        // GET: EmployeeController
        public ActionResult Index()
        {
            if(_employeeDBContext.Employees != null)
                return View(_employeeDBContext.Employees.ToList());
            return View();
        }

        // GET: EmployeeController/Details/5
        public ActionResult Details(int id)
        {
            var employee = _employeeDBContext.Employees.Where(e => e.Id == id).First();
            return View(employee);
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
                if(ModelState.IsValid)
                {
                    _employeeDBContext.Employees.Add(employee);
                    _employeeDBContext.SaveChanges();
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    return View(employee);
                }
            }
            catch
            {
                return View();
            }
        }

        // GET: EmployeeController/Edit/5
        public ActionResult Edit(int id)
        {
            var employee = _employeeDBContext.Employees.Where(e => e.Id == id).First();
            return View(employee);
        }

        // POST: EmployeeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Employee newEmployee)
        {
            try
            {
                _employeeDBContext.Update(newEmployee);
                _employeeDBContext.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: EmployeeController/Delete/5
        public ActionResult Delete(int id)
        {
            var employee = _employeeDBContext.Employees.Where(e => e.Id == id).First();
            return View(employee);
        }

        // POST: EmployeeController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                var employee = _employeeDBContext.Employees.Where(e => e.Id == id).First();
                if(employee != null)
                {
                    _employeeDBContext.Remove(employee);
                    _employeeDBContext.SaveChanges();
                    return RedirectToAction(nameof(Index));
                }
                return NotFound();
            }
            catch
            {
                return View();
            }
        }
    }
}
