using CommonLayer.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BussinessLayer.Interface
{
    public interface IUserDetail
    {
        EmployeeRegistration AddEmployeeDetail(EmployeeRegistration employee);
    }
}
