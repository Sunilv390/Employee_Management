using CommonLayer.Model;
using Microsoft.Extensions.Configuration;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace RepositoryLayer.Service
{
    public class RepoUserDetail : IUserService
    {
        private readonly IConfiguration config;
        public RepoUserDetail(IConfiguration _config)
        {
            config = _config;
        }

        public Register AddUserDetail(Register user)
        {
            try
            {
                string con = config.GetConnectionString("EmpDb");
                using (SqlConnection connection = new SqlConnection(con))
                {
                    SqlCommand sqlCommand = new SqlCommand("spAddUserDetail", connection);
                    sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                    sqlCommand.Parameters.AddWithValue("@Name", user.Name);
                    sqlCommand.Parameters.AddWithValue("@Email", user.Email);
                    sqlCommand.Parameters.AddWithValue("@Password", user.Password);
                    sqlCommand.Parameters.AddWithValue("@Contact", user.Contact);
                    sqlCommand.Parameters.AddWithValue("@Date", user.Date);
                    connection.Open();
                    sqlCommand.ExecuteNonQuery();
                    SqlDataReader dataReader = sqlCommand.ExecuteReader();
                    while (dataReader.Read())
                    {
                        user.Id = Convert.ToInt32(dataReader["Id"].ToString());
                        user.Date = Convert.ToDateTime(dataReader["Date"].ToString());
                    }
                    connection.Close();
                    return user;
                }
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }

        public Register Login(Login user)
        {
            Register register = new Register();
            try
            {
                string con = config.GetConnectionString("EmpDb");
                using (SqlConnection connection = new SqlConnection(con))
                {
                    SqlCommand sqlCommand = new SqlCommand("spLogin", connection);
                    sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddWithValue("@Email", user.Email);
                    sqlCommand.Parameters.AddWithValue("@Password", user.Password);
                    connection.Open();
                    SqlDataReader dataReader = sqlCommand.ExecuteReader();
                    while (dataReader.Read())
                    {
                        register.Id = Convert.ToInt32(dataReader["@Id"].ToString()) ;
                        register.Password = dataReader["Password"].ToString();
                        register.Name = dataReader["Name"].ToString();
                        register.Email = dataReader["Email"].ToString();
                        register.Contact = dataReader["Contact"].ToString();
                        register.Date = Convert.ToDateTime(dataReader["Date"].ToString());
                    }
                }
            } // Exception
            catch (Exception)
            {

                throw new Exception();
            }
            // Return User Data
            return register;
        }


        public List<Register> GetUser()
        {
            List<Register> users = new List<Register>();
            try
            {
                string con = config.GetConnectionString("EmpDb");
                using (SqlConnection connection = new SqlConnection(con))
                {
                    SqlCommand sqlCommand = new SqlCommand("spGetUsersDetail", connection);
                    sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                    connection.Open();
                    SqlDataReader dataReader = sqlCommand.ExecuteReader();
                    while (dataReader.Read())
                    {
                        Register user = new Register();
                        user.Id = Convert.ToInt32(dataReader["Id"].ToString());
                        user.Name = dataReader["Name"].ToString();
                        user.Email = dataReader["Email"].ToString();
                        user.Password = dataReader["Password"].ToString();
                        user.Contact = dataReader["Contact"].ToString();
                        user.Date = Convert.ToDateTime(dataReader["Date"].ToString());

                        users.Add(user);
                    }   
                    connection.Close();
                }
            }
            catch (Exception)
            {
                throw new Exception();
            }
            return users;
        }
    }
}