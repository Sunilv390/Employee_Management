using CommonLayer.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.Interface
{
    public interface IUserService
    {
        User AddUserDetail(Register user);
        List<Register> GetData();
        User Login(Login login);
    }
}
