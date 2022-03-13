using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RepositoryCrud.Interface;
using RepositoryCrud.Models;
namespace RepositoryCrud.Repository
{
    public class EmployeeRepository : IUnits
    {
        private ApplicationDbContext dbContext;
        public EmployeeRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public Employee Create(Employee employee)
        {
            dbContext.Employees.Add(employee);
            dbContext.SaveChanges();
            return employee;
        }

        public Employee Delete(Employee employee)
        {
            dbContext.Employees.Remove(employee);
            dbContext.SaveChanges();
            return employee;
        }

        public Employee Edit(Employee employee)
        {

            dbContext.Employees.Update(employee);
            dbContext.SaveChanges();
            return employee;
        }

        public Employee GetEmp()
        {
            throw new NotImplementedException();
        }

        public List<Employee> GetEmployees()
        {
            List<Employee> employees = dbContext.Employees.ToList();
            return employees;
        }

       
    }
}
