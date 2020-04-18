using BussinessLayer.Interface;
using CommonLayer.Model;
using Microsoft.AspNetCore.Mvc;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace BussinessLayer.Service
{
    public class EmployeeBusiness : IEmployeeBusiness
    {
        private readonly IEmployeeRepo employeeRL;
        public EmployeeBusiness(IEmployeeRepo employeeRepoL)
        {
            employeeRL = employeeRepoL;
        }
        [HttpPost]
        public Employee AddEmployee(Employee employee)
        {
            var result = employeeRL.AddEmployee(employee);
            return result;
        }
        [HttpDelete]
        public void DeleteEmployee(int id)
        {
            employeeRL.DeleteEmployee(id);
        }
        [HttpGet]
        public List<Employee> GetAllEmployees()
        {
            var result = employeeRL.GetAllEmployees();
            return result;
        }
        [HttpGet]
        public Employee GetEmployeeInfo(int id)
        {
            var result = employeeRL.GetEmployeeData(id);
            return result;
        }
        [HttpPut]
        public Employee UpdateEmployee(Employee employee)
        {
            var result = employeeRL.UpdateEmployee(employee);
            return result;
        }
    }
}

