using CommonLayer.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BussinessLayer.Interface
{
    public interface IEmployeeBusiness
    {
        List<Employee> GetAllEmployees();
        Employee AddEmployee(Employee employee);
        Employee UpdateEmployee(Employee employee);
        Employee GetEmployeeInfo(int id);
        void DeleteEmployee(int id);
    }
}