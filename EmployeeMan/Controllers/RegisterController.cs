using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BussinessLayer.Interface;
using BussinessLayer.Service;
using CommonLayer.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        private readonly IUserDetail config;
        public RegisterController(IUserDetail _config)
        {
            config = _config;
        }

        [HttpPost]
        [Route("")]
        public ActionResult Register(Register user)
        {
            try
            {
                var data = config.AddUserDetail(user);
                if (data == null)
                {
                    return BadRequest();
                }
                return Ok(new
                {
                    StatusCodeResult = "success",
                    Message = "Added Successfully",
                    data
                });
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }
    }
}