using CommonLayer.Model;
using System.Collections.Generic;

namespace BussinessLayer.Interface
{
    public interface IEmployeeBusiness
    {
        List<Employee> GetAllEmployees();
        Employee AddEmployee(Employee employee);
        Employee UpdateEmployee(Employee employee);
        Employee GetEmployeeInfo(int id);
        string DeleteEmployee(int id);
    }
}