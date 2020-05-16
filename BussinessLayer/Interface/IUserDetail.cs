using CommonLayer.Model;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace BussinessLayer.Interface
{
    public interface IUserDetail
    {
        Register AddUserDetail(Register user);
        List<Register> GetUser();
        User Login(Login login);
    }
}
