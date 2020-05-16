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
        readonly string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\ASUS\Documents\EmpDb.mdf;Integrated Security=True;Connect Timeout=30";
        public Register AddUserDetail(Register user)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand sqlCommand = new SqlCommand("spAddUserDetail", connection);
                    sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddWithValue("@Name", user.Name);
                    sqlCommand.Parameters.AddWithValue("@Email", user.Email);
                    sqlCommand.Parameters.AddWithValue("@Password", user.Password);
                    sqlCommand.Parameters.AddWithValue("@Contact", user.Contact);
                    connection.Open();
                    sqlCommand.ExecuteNonQuery();
                    SqlDataReader dataReader = sqlCommand.ExecuteReader();
                    while (dataReader.Read())
                    {
                        user.Id = Convert.ToInt32(dataReader["Id"].ToString());
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

        public User Login(Login user)
        {
            User register = new User();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand sqlCommand = new SqlCommand("dpLogin", connection);
                    sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddWithValue("@Email", user.Email);
                    sqlCommand.Parameters.AddWithValue("@Password", user.Password);
                    connection.Open();
                    SqlDataReader dataReader = sqlCommand.ExecuteReader();
                    while (dataReader.Read())
                    {
                        register.Id = Convert.ToInt32(dataReader["Id"].ToString());
                        register.Name = dataReader["Name"].ToString();
                        register.Email = dataReader["Email"].ToString();
                       // register.Password = dataReader["Password"].ToString();
                        register.Contact = dataReader["Contact"].ToString();
                    }
                }
                // Return User Data
                return register;
            } // Exception
            catch (Exception e)
            {
                throw e;
            }
           
        }

        public List<Register> GetUser()
        {
            List<Register> users = new List<Register>();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
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