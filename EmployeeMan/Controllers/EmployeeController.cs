using BussinessLayer.Interface;
using CommonLayer.Model;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Controllers
{
    namespace EmployeeMangement.Controllers
    {
        [Route("api/[controller]")]
        [ApiController]
        public class EmployeeController : ControllerBase
        {
            private readonly IEmployeeBusiness employeeBL;
            public EmployeeController(IEmployeeBusiness employeeBusiL)
            {
                employeeBL = employeeBusiL;
            }
            [HttpGet]
            [Route("")]
            public List<Employee> GetAllEmployee()
            {
                var result = employeeBL.GetAllEmployees();
                return result;
            }
            [HttpGet]
            [Route("{Id}")]
            public Employee GetEmployeeInformation(int id)
            {
                var result = employeeBL.GetEmployeeInfo(id);
                return result;
            }

            [HttpPost]
            [Route("")]
            public Employee AddEmployee(Employee employee)
            {

                var result = employeeBL.AddEmployee(employee);
                return result;
            }
            [HttpDelete]
            [Route("{Id}")]
            public void DeleteEmployee(int id)
            {
                employeeBL.DeleteEmployee(id);
            }
            [HttpPut]
            [Route("{Id}")]
            public void UpdateEmployee(Employee employee)
            {
                employeeBL.UpdateEmployee(employee);
            }
        }
    }
}