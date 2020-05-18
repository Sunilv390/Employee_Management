using BussinessLayer.Interface;
using CommonLayer.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace EmployeeManagement.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    [EnableCors("MyPolicy")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeBusiness employeeBL;
        public EmployeeController(IEmployeeBusiness employeeBusiL)
        {
            employeeBL = employeeBusiL;
        }

        //GET api/AllEmployee
        [HttpGet]
        [EnableCors("MyPolicy")]
        [Route("")]
        public ActionResult GetAllEmployee()
        {
            try
            {
                var result = employeeBL.GetAllEmployees();
                if (result == null)
                {
                    return NotFound();
                }
                return Ok(result);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        //GET api/Employee_By_Id
        [HttpGet]
        [EnableCors("MyPolicy")]
        [Route("{id}")]
        public ActionResult GetEmployeeInformation(int id)
        {
            try
            {
                if (id != employeeBL.GetEmployeeInfo(id).Id)
                {
                    return NotFound();
                }
                var result = employeeBL.GetEmployeeInfo(id);
                return Ok(result);
            }
            catch (Exception)
            {
                return BadRequest(id);
            }
        }

        //POST api/Employee Detail
        [HttpPost]
        [EnableCors("MyPolicy")]
        [Route("")]
        public ActionResult AddEmployee(Employee employee)
        {
            try
            {
                var result = employeeBL.AddEmployee(employee);
                return Ok(result);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        //DELETE api/Delete_Employee_by_ID
        [HttpDelete]
        [EnableCors("MyPolicy")]
        [Route("{id}")]
        public ActionResult DeleteEmployee(int id)
        {
            try
            {
                employeeBL.DeleteEmployee(id);
                return Ok("Deleted successfully");
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        //PUT api/UpdateEmployee Data
        [HttpPut]
        [EnableCors("MyPolicy")]
        [Route("{id}")]
        public ActionResult UpdateEmployee(Employee employee)
        {
            try
            {
                var result = employeeBL.UpdateEmployee(employee);
                return Ok(result);
            }
            catch (Exception)
            {
                return NotFound();
            }
        }
    }
}