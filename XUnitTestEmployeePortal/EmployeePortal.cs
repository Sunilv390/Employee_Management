using BussinessLayer.Interface;
using CommonLayer.Model;
using EmployeeManagement.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Moq;
using System;
using Xunit;

namespace XUnitTestEmployeePortal
{
    public class EmployeePortal
    {
        private readonly Mock<IEmployeeBusiness> mock;
        private readonly IEmployeeBusiness employeeBL;
        private readonly Mock<IUserDetail> _mock;
        private readonly Mock<IConfiguration> config;
        private readonly EmployeeController employee;
        private readonly UserLoginController userLogin;

        public EmployeePortal()
        {
            mock = new Mock<IEmployeeBusiness>();
            _mock = new Mock<IUserDetail>();
            config = new Mock<IConfiguration>();
            employee = new EmployeeController(mock.Object);
            userLogin = new UserLoginController(_mock.Object, config.Object);
        }

        //Test Case to Get Employee Data By Id
        [Fact]
        public void Test_GetEmployeeData_byId()
        {
            var Ok = employee.GetEmployeeInformation(2);
            try
            {
                if (2 != employeeBL.GetEmployeeInfo(2).Id)
                {
                    Assert.IsType<NotFoundObjectResult>(Ok);
                }
               
                Assert.IsType<OkObjectResult>(Ok);
            }
            catch (Exception)
            {
                Assert.IsType<BadRequestObjectResult>(Ok);
            }
        }

        //Test Case for Adding Employee Data
        [Fact]
        public void Test_for_Adding_Data()
        {
            var data = new Employee()
            {
                Name = "",
                Email = "",
                Salary = 0,
                Designation = "",
                Experience = 0,
                ContactNumber = "",
                Department = ""
            };
            var result = employee.AddEmployee(data);
                Assert.IsType<OkObjectResult>(result);
        }

        //Test Case for Deleting Employee Data
        [Fact]
        public void Test_for_DeletingEmployee_Data()
        {
            var result = employee.DeleteEmployee(2);
            Assert.IsType<OkObjectResult>(result);
        }

        //Test Case for Updating Employee Data
        [Fact]
        public void Test_for_Updating_data()
        {
            var data = new Employee()
            {
                Name = "",
                Email = "",
                Salary = 0,
                Designation = "",
                Experience = 0,
                ContactNumber = "",
                Department = ""
            };
            var result = employee.UpdateEmployee(data);
            Assert.IsType<OkObjectResult>(result);
        }

        //Test Case for Login User
        [Fact]
        public void Test_for_LoginUserDetail()
        {
            Login data = new Login()
            {
                Email = "",
                Password = ""
            };
            var result = userLogin.Login(data);
                Assert.IsType<OkObjectResult>(result);
        }

        //Test Case for Register User Data
        [Fact]
        public void Test_for_Registering_Data()
        {
            Register data = new Register()
            {
                Name = "",
                Email = "",
                Password = "",
                Contact = ""
            };
            var result = userLogin.Register(data);
            Assert.IsType<OkObjectResult>(result);
        }

        //Test Case to Get User Data
        [Fact]
        public void Get_Data_for_LoginController()
        {
            var OkResult = userLogin.GetData();
            Assert.IsType<OkObjectResult>(OkResult);
        }
    }
}
