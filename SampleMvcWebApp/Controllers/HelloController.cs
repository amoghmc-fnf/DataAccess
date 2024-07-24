using Microsoft.AspNetCore.Mvc;
using SampleMvcWebApp.Models;

namespace SampleMvcWebApp.Controllers
{
    public class HelloController : Controller
    {
        public string Greeting() => "Hello world from .NET MVC";
        public ViewResult Details()
        {
            Employee employee = new Employee();
            employee.Id = 1;
            employee.Name = "Test";
            employee.Address = "TestAddress";
            employee.Salary = 3000;
            employee.Image = "../Images/testEmployee.jpg";
            return View(employee);
        }
    }
}
