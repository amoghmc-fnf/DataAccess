using Microsoft.AspNetCore.Mvc;
using SampleMvcWebApp.Models;

namespace SampleMvcWebApp.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly EmployeeDbContext _employeeDbContext;
        public EmployeeController(EmployeeDbContext context)
        {
            this._employeeDbContext = context;
        }
        public IActionResult AllEmployees()
        {
            var employees = _employeeDbContext.Employees.ToList();
            return View(employees);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var record = _employeeDbContext.Employees.FirstOrDefault(e => e.Id == id);
            if (record == null)
            {
                return NotFound();
            }
            return View(record);
        }

        [HttpPost]
        public IActionResult Edit(Employee postedData)
        {
            var id = postedData.Id;
            var record = _employeeDbContext.Employees.FirstOrDefault(e => e.Id == id);
            if (record == null)
                return NotFound();

            record.Name = postedData.Name;
            record.Salary = postedData.Salary;
            record.Address = postedData.Address;
            record.Image = postedData.Image;
            _employeeDbContext.SaveChanges();
            return RedirectToAction("AllEmployees");
        }

        public IActionResult AddNew() => View(new Employee());

        [HttpPost]
        public IActionResult AddNew(Employee emp)
        {
            if (emp != null)
            {
                emp.Image = "../Images/" + emp.Image;
                _employeeDbContext.Employees.Add(emp);
                _employeeDbContext.SaveChanges();
                return RedirectToAction("AllEmployees");
            }
            return NotFound();
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var record = _employeeDbContext.Employees.FirstOrDefault(e => e.Id == id);
            if (record == null)
            {
                return NotFound();
            }
            return View(record);
        }

        [HttpPost]
        public IActionResult Delete(Employee postedData)
        {
            var id = postedData.Id;
            var record = _employeeDbContext.Employees.FirstOrDefault(e => e.Id == id);
            if (record == null)
                return NotFound();

            _employeeDbContext.Remove(record);
            _employeeDbContext.SaveChanges();
            return RedirectToAction("AllEmployees");
        }
    }
}
