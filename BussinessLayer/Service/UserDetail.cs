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
        private readonly IRepoUserDetail repositoryUser;
        public UserDetail(IRepoUserDetail _repositoryUser)
        {
            repositoryUser = _repositoryUser;
        }

        public EmployeeRegistration AddEmployeeDetail(EmployeeRegistration employee)
        {
            try
            {
                var result = repositoryUser.AddEmployeeDetail(employee);
                if (result == null)
                {
                    throw new Exception();
                }
                return result;
            }
            catch(Exception)
            {
                throw new Exception();
            }
        }
    }
}
