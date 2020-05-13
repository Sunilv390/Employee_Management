using BussinessLayer.Interface;
using CommonLayer.Model;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;

namespace BussinessLayer.Service
{
    public class EmployeeBusiness : IEmployeeBusiness
    {
        private readonly IEmployeeRepo employeeRL;
        public EmployeeBusiness(IEmployeeRepo employeeRepoL)
        {
            employeeRL = employeeRepoL;
        }
        public Employee AddEmployee(Employee employee)
        {
            try
            {
                var result = employeeRL.AddEmployee(employee);
                return result;
            }
            catch
            {
                throw;
            }
        }
        public string DeleteEmployee(int id)
        {
            try
            {
                employeeRL.DeleteEmployee(id);
                return "Deleted successfully";
            }
            catch { throw; }
        }
        public List<Employee> GetAllEmployees()
        {
            try
            {
                var result = employeeRL.GetAllEmployees();
                return result;
            }
            catch { throw; }
        }
        public Employee GetEmployeeInfo(int id)
        {
            if (id != employeeRL.GetEmployeeData(id).Id)
                throw new Exception();
            try
            {
                var result = employeeRL.GetEmployeeData(id);
                return result;
            }
            catch { throw; }
        }
        public Employee UpdateEmployee(Employee employee)
        {
            try
            {
                var result = employeeRL.UpdateEmployee(employee);
                return result;
            }
            catch { throw; }
        }
    }
}