using System;
using System.Collections.Generic;
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
                if (data == null)
                {
                    return BadRequest();
                }
                else
                {
                    return Ok(new
                    {
                        StatusCodeResult = "success",
                        Message = "Added Successfully",
                        data
                    });
                }
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }

        //POST api/Login
        [HttpPost]
        [Route("login")]
        public ActionResult Login(Login login)
        {
            try
            {
                var data = userDetail.Login(login);
                bool success = false;
                string message, jsonToken;

                if (data == null)
                {
                    message = "Enter Valid Email & Password";
                    return Ok(new { success, message });
                }
                else
                {
                    success = true;
                    message = " Login Successfully";
                    jsonToken = GetToken(data, "login");
                    return Ok(new { success, message, data, jsonToken });
                }
        }
            catch (Exception ex)
            {
                return BadRequest(new { ex.Message });
            }
        }

        //GET api
        //returns the data in SMD format
        [HttpGet]
        public ActionResult GetUser()
        {
            try
            {
                var data = userDetail.GetUser();
                if (data == null)
                {
                    return NotFound();
                }
                return Ok(new
                {
                    StatusCodeResult = "success",
                    Message = "User Data",
                    data
                });
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        public string GetToken(User data, string type)
        {
            try
            {
                var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));

                var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256Signature);

                var claims = new List<Claim>();
                claims.Add(new Claim(ClaimTypes.Role, type));
                claims.Add(new Claim("Email", data.Email.ToString()));
              //  claims.Add(new Claim("Password", data.Password.ToString()));

                var token = new JwtSecurityToken(_config["Jwt:Issuer"],
                    _config["Jwt:Issuer"],
                    claims,
                    expires: DateTime.Now.AddHours(1),
                    signingCredentials: signingCredentials
                    );
                return new JwtSecurityTokenHandler().WriteToken(token);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}