using CommonLayer.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.Interface
{
    public interface IUserService
    {
        Register AddUserDetail(Register user);
        List<Register> GetUser();
        User Login(Login login);
    }
}
