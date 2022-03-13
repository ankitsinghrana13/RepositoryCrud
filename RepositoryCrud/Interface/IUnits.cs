using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RepositoryCrud.Models;

namespace RepositoryCrud.Interface
{
public    interface IUnits
    {
        List<Employee> GetEmployees();
        Employee GetEmp();
        Employee Create(Employee employee);
        Employee Edit(Employee employee);
        Employee Delete(Employee employee);
    }
}
