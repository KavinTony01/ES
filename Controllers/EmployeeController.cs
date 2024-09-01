using EmployeePortal.Data;
using EmployeePortal.Models;
using EmployeePortal.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EmployeePortal.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly ApplicationDBContext dBContext;

        public EmployeeController(ApplicationDBContext DBContext)
        {
            dBContext = DBContext;
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Add(AddEmployeeViewModel AddEmpViewModel)
        {
            Employee emp = new Employee
            {
                Name = AddEmpViewModel.Name,
                Email = AddEmpViewModel.Email,
                PhoneNumber = AddEmpViewModel.PhoneNumber,
                Subscribed = AddEmpViewModel.Subscribed,
            };
            await dBContext.Employees.AddAsync(emp);
            await dBContext.SaveChangesAsync(); 
            return View();
        }
        public async Task<IActionResult> List()
        {
           var Employees= await dBContext.Employees.ToListAsync();
            return View(Employees);
        }
    }

}
