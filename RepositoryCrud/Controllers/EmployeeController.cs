using Microsoft.AspNetCore.Mvc;
using RepositoryCrud.Interface;
using RepositoryCrud.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RepositoryCrud.Controllers
{
    public class EmployeeController : Controller
    {
        private ApplicationDbContext dbContext;
        private IUnits UnitRepo;
        public EmployeeController(ApplicationDbContext dbContext, IUnits UnitRepo)
        {
            this.dbContext = dbContext;
            this.UnitRepo = UnitRepo;

        }
        public IActionResult Index()
        {
            List<Employee> employees = UnitRepo.GetEmployees();//dbContext.Employees.ToList();
            return View(employees);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Employee emp)
        {
            emp = UnitRepo.Create(emp);
            return RedirectToAction("Index");
        }

        public IActionResult Details(int id)
        {
            Employee employee = GetEmployee(id);
            return View(employee);

        }
        private Employee GetEmployee(int id)
        {
            Employee employee = dbContext.Employees.Where(e => e.Id == id).FirstOrDefault();
            return employee;
        }
      
        public IActionResult Delete(int id)
        {
            var emp = dbContext.Employees.SingleOrDefault(e => e.Id == id);
            if (emp != null)
            {
                emp = UnitRepo.Delete(emp);
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Index");
            }
       
        }
        public IActionResult Edit(int id)
        {
            

            var emp = dbContext.Employees.SingleOrDefault(e => e.Id == id);
            return View(emp);
        }
        [HttpPost]
        public IActionResult Edit(Employee emp)
        {
            emp = UnitRepo.Edit(emp);
            return RedirectToAction("Index");

        }
    }
}
