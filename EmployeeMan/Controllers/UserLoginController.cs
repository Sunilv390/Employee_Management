using System;
using System.Collections.Generic;
using System.Data.Common;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using BussinessLayer.Interface;
using BussinessLayer.Service;
using CommonLayer.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Expressions;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace EmployeeManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserLoginController : ControllerBase
    {
        private readonly IUserDetail userDetail;
        private readonly IConfiguration _config;
        public UserLoginController(IUserDetail _userDetail,IConfiguration config)
        {
            userDetail = _userDetail;
            _config = config;
        }

        //POST api/Register
        //Regsiter the new User Data
        [HttpPost]
        [Route("Register")]
        public ActionResult Register(Register user)
        { 
            try
            {
                var data = userDetail.AddUserDetail(user);
                bool success = false;
                string message;
                if (data==null)
                {
                    message = "Email or Contact exists";
                    return Ok(new { success, message });
                }
                else
                {
                    success = true;
                    message = "Registered Successfully";
                    return Ok(new { success, message, data });
                }
            }
            catch (Exception e)
            {
                return BadRequest(new { e.Message });
            }
        }

        //POST api/Login
        [HttpPost]
        [Route("login")]
        public ActionResult Login(Login login)
        {
            try
            {
                User data = userDetail.Login(login);
                bool success = false;
                string message;

                if (data == null)
                {
                    message = "Enter Valid Email & Password";
                    return Ok(new { success, message });
                }
                else
                {
                    success = true;
                    message = " Login Successfully";
                    var jsonToken = GetToken(data, "login");
                    return Ok(new { success, message, data, jsonToken });
                }
        }
            catch (Exception ex)
            {
                return BadRequest(new { ex.Message });
            }
        }

        //Generates Token for Login
        public string GetToken(User data, string type)
        {
            try
            {
                var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));

                var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256Signature);

                var claims = new List<Claim>();
                claims.Add(new Claim(ClaimTypes.Role, type));
                claims.Add(new Claim("Id", data.Id.ToString()));
                claims.Add(new Claim("Email", data.Email.ToString()));

                var token = new JwtSecurityToken(_config["Jwt:Issuer"],
                    _config["Jwt:Issuer"],
                    claims,
                    expires: DateTime.Now.AddMinutes(5),
                    signingCredentials: signingCredentials
                    );
                return new JwtSecurityTokenHandler().WriteToken(token);
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        [Authorize]
        [HttpGet]
        public ActionResult GetData()
        {
            try
            {
                List<Register> register = userDetail.GetData();
                return Ok(register.ToList());
            }
            catch (Exception e)
            {
                return BadRequest(new { e.Message });
            }
        }
    }
}