using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.Interface
{
    public interface IRepoUserDetail
    {
        EmployeeRegistration AddEmployeeDetail(EmployeeRegistration employee);
    }
}
