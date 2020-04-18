using CommonLayer.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.Interface
{
    public interface IEmployeeRepo
    {
        List<Employee> GetAllEmployees();
        Employee AddEmployee(Employee employee);
        Employee UpdateEmployee(Employee employee);
        Employee GetEmployeeData(int id);
        void DeleteEmployee(int id);
    }
}
