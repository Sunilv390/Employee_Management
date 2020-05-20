using BussinessLayer.Interface;
using CommonLayer.Model;
using Experimental.System.Messaging;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
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
                    string messageSender = ("Registration successful" + "\n Email : " + Convert.ToString(user.Email) + "\n Password : " + (data.Password)) ;
                    sender.Message(messageSender);
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

        //GET api/GetAllData
        [Authorize]
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
                throw new Exception (e.Message);
            }
        }
    }
}