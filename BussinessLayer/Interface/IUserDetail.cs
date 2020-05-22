using CommonLayer.Model;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace BussinessLayer.Interface
{
    public interface IUserDetail
    {
        User AddUserDetail(Register user);
        List<Register> GetData();
        User Login(Login login);
    }
}
