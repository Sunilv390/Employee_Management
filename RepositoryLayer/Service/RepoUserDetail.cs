using CommonLayer.Model;
using Microsoft.Extensions.Configuration;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace RepositoryLayer.Service
{
    public class RepoUserDetail : IRepoUserDetail
    {
        readonly string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\ASUS\Documents\EmpDb.mdf;Integrated Security=True;Connect Timeout=30";
        public EmployeeRegistration AddEmployeeDetail(EmployeeRegistration employee)
        {
            try
            {
                //string con = configuration.GetConnectionString("MyConnection");
                using (SqlConnection connection = new SqlConnection(this.connectionString))
                {
                    SqlCommand sqlCommand = new SqlCommand("spAddUserDetail", connection);
                    sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddWithValue("@Name", employee.Name);
                    sqlCommand.Parameters.AddWithValue("@EmailAddress", employee.EmailAddress);
                    sqlCommand.Parameters.AddWithValue("@Password", employee.Password);
                    connection.Open();
                    sqlCommand.ExecuteNonQuery();
                    connection.Close();
                }
            }
            catch (Exception)
            {
                throw new Exception();
            }
            return employee;
        }
    }
}
