using BussinessLayer.Interface;
using CommonLayer.Model;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace BussinessLayer.Service
{
    public class UserDetail : IUserDetail
    {
        private readonly IUserService repositoryUser;
        public UserDetail(IUserService _repositoryUser)
        {
            repositoryUser = _repositoryUser;
        }

        public Register AddUserDetail(Register user)
        {
            try
            {
                var result = repositoryUser.AddUserDetail(user);
                if (result == null)
                {
                    throw new Exception();
                }
                return result;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public User Login(Login login)
        {
            try
            {
                var result = repositoryUser.Login(login);
                if (result == null)
                {
                    throw new Exception();
                }
                return result;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public List<Register> GetData()
        {
            try
            {
                var result = repositoryUser.GetData();
                return result;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
