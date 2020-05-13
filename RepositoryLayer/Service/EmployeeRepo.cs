using CommonLayer.Model;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace RepositoryLayer.Service
{
    public class EmployeeRepo : IEmployeeRepo
    {
        /// <summary>
        /// The connection string
        /// </summary>
        string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\ASUS\Documents\EmpDb.mdf;Integrated Security=True;Connect Timeout=30";

        /// <summary>
        /// Adds the employee.
        /// </summary>
        /// <param name="employee">The employee.</param>
        /// <returns>returns the employee added</returns> 
        public Employee AddEmployee(Employee employee)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(this.connectionString))
                {
                    SqlCommand sqlCommand = new SqlCommand("dbAddEmployee", con);
                    sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddWithValue("@name", employee.Name);
                    sqlCommand.Parameters.AddWithValue("@email", employee.Email);
                    sqlCommand.Parameters.AddWithValue("@salary", employee.Salary);
                    sqlCommand.Parameters.AddWithValue("@designation", employee.Designation);
                    sqlCommand.Parameters.AddWithValue("@experience", employee.Experience);
                    sqlCommand.Parameters.AddWithValue("@department", employee.Department);
                    sqlCommand.Parameters.AddWithValue("@contact", employee.ContactNumber);
                    con.Open();
                    sqlCommand.ExecuteNonQuery();
                    con.Close();
                }
            }
            catch 
            {
                throw;
            }
            return employee;
        }

        /// <summary>
        /// Deletes the employee.
        /// </summary>
        /// <param name="id">The identifier.</param>
        public void DeleteEmployee(int id)
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(this.connectionString))
                {
                    SqlCommand sqlCommand = new SqlCommand("dbRemoveEmployee", sqlConnection);
                    sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddWithValue("@id", id);
                    sqlConnection.Open();
                    sqlCommand.ExecuteNonQuery();
                    sqlConnection.Close();
                }
            }
            catch 
            {
                throw;
            }
        }

        /// <summary>
        /// Gets all records of an Employee
        /// </summary>
        /// <returns>returns the list of all employee</returns>
        public List<Employee> GetAllEmployees()
        {
            List<Employee> employees = new List<Employee>();
            try
            {
                using (SqlConnection con = new SqlConnection(this.connectionString))
                {
                    SqlCommand sqlCommand = new SqlCommand("dbShowAllEmployee", con);
                    sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                    con.Open();
                    SqlDataReader dataReader = sqlCommand.ExecuteReader();
                    while (dataReader.Read())
                    {
                        Employee employee = new Employee();
                        employee.Id = Convert.ToInt32(dataReader["id"]);
                        employee.Name = dataReader["name"].ToString();
                        employee.Email = dataReader["email"].ToString();
                        employee.Salary = Convert.ToDouble(dataReader["salary"]);
                        employee.Designation = dataReader["designation"].ToString();
                        employee.Experience = Convert.ToDouble(dataReader["experience"]);
                        employee.Department = dataReader["department"].ToString();
                        employee.ContactNumber = dataReader["contact"].ToString();

                        employees.Add(employee);
                    }
                    con.Close();
                }
            }
            catch
            {
                throw;
            }
            return employees;
        }

        /// <summary>
        /// Gets the employee data by specific Id
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>gets data of single employee</returns>
        public Employee GetEmployeeData(int id)
        {
            Employee employee = new Employee();
            try
            {
                using (SqlConnection con = new SqlConnection(this.connectionString))
                {
                    SqlCommand sqlCommand = new SqlCommand("dbShowEmployeeById", con);
                    sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddWithValue("@id", id);
                    con.Open();
                    SqlDataReader dataReader = sqlCommand.ExecuteReader();
                    while (dataReader.Read())
                    {
                        employee.Id = Convert.ToInt32(dataReader["id"]);
                        employee.Name = dataReader["name"].ToString();
                        employee.Email = dataReader["email"].ToString();
                        employee.Salary = Convert.ToDouble(dataReader["salary"]);
                        employee.Designation = dataReader["designation"].ToString();
                        employee.Experience = Convert.ToDouble(dataReader["experience"]);
                        employee.Department = dataReader["department"].ToString();
                        employee.ContactNumber = dataReader["contact"].ToString();
                    }
                }
            }
            catch
            {
                throw;
            }
            return employee;
        }

        /// <summary>
        /// Updates the employee details.
        /// </summary>
        /// <param name="employee">The employee.</param>
        /// <returns>returns the updated employee</returns>
        public Employee UpdateEmployee(Employee employee)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(this.connectionString))
                {
                    SqlCommand sqlCommand = new SqlCommand("dbUpdateEmployee", con);
                    sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddWithValue("@id", employee.Id);
                    sqlCommand.Parameters.AddWithValue("@name", employee.Name);
                    sqlCommand.Parameters.AddWithValue("@email", employee.Email);
                    sqlCommand.Parameters.AddWithValue("@salary", employee.Salary);
                    sqlCommand.Parameters.AddWithValue("@designation", employee.Designation);
                    sqlCommand.Parameters.AddWithValue("@experience", employee.Experience);
                    sqlCommand.Parameters.AddWithValue("@department", employee.Department);
                    sqlCommand.Parameters.AddWithValue("@contact", employee.ContactNumber);
                    con.Open();
                    sqlCommand.ExecuteNonQuery();
                    con.Close();
                }
            }
            catch
            {
                throw;
            }
            return employee;
        }
    }
}

