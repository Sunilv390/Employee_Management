using BussinessLayer.Interface;
using CommonLayer.Model;
using EmployeeManagement.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using StackExchange.Redis.Extensions.Core.Abstractions;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace EmployeeManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserLoginController : ControllerBase
    {
        private readonly IUserDetail userDetail;
        private readonly IConfiguration _config;
        

        MessageSender sender = new MessageSender();
        SMTPService sMTP = new SMTPService();
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
                    string messageSender = "Registration successful" + "\n Email : " + Convert.ToString(user.Email) + "\n Password : " + Convert.ToString(user.Password);
                    sender.Message(messageSender);
                    sMTP.SendMail(Convert.ToString(data.Email), Convert.ToString(user.Password), messageSender);
                   
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
                    var jsonToken = GenerateToken(data, "login");
                    return Ok(new { success, message, data, jsonToken });
                }
        }
            catch (Exception ex)
            {
                return BadRequest(new { ex.Message });
            }
        }

        //GET api/GetAllData
   //     [Authorize]
        [HttpGet]
        public ActionResult GetData()
        {
            try
            {
                var register = userDetail.GetData();
                return Ok(register);
            }
            catch (Exception e)
            {
                return BadRequest(new { e.Message });
            }
        }

        //Generates Token for Login
        private string GenerateToken(User responseData, string type)
        {
            try
            {
                var symmetricSecuritykey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));

                var signingCreds = new SigningCredentials(symmetricSecuritykey, SecurityAlgorithms.HmacSha256);

                var claims = new List<Claim>();
                claims.Add(new Claim(ClaimTypes.Role, type));
                claims.Add(new Claim("Id", responseData.Id.ToString()));
                claims.Add(new Claim("Email", responseData.Email.ToString()));
                var token = new JwtSecurityToken(_config["Jwt:Issuer"],
                    _config["Jwt:Issuer"],
                    claims,
                    expires: DateTime.Now.AddMinutes(5),
                    signingCredentials: signingCreds);
                return new JwtSecurityTokenHandler().WriteToken(token);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}