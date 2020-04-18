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
                    SqlCommand sqlCommand = new SqlCommand("dpAddEmployee", con);
                    sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddWithValue("@Id", employee.Id);
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
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
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
                    SqlCommand sqlCommand = new SqlCommand("spRemoveEmployee", sqlConnection);
                    sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddWithValue("@Id", id);
                    sqlConnection.Open();
                    sqlCommand.ExecuteNonQuery();
                    sqlConnection.Close();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        /// <summary>
        /// Gets all employees.
        /// </summary>
        /// <returns>returns the list of all employee</returns>
        public List<Employee> GetAllEmployees()
        {
            List<Employee> employees = new List<Employee>();
            try
            {
                using (SqlConnection con = new SqlConnection(this.connectionString))
                {
                    SqlCommand sqlCommand = new SqlCommand("spShowAllEmployee", con);
                    sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                    con.Open();
                    SqlDataReader dataReader = sqlCommand.ExecuteReader();
                    while (dataReader.Read())
                    {
                        Employee employee = new Employee();
                        employee.Id = Convert.ToInt32(dataReader["Id"]);
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
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return employees;
        }

        /// <summary>
        /// Gets the employee data.
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
                    SqlCommand sqlCommand = new SqlCommand("spShowEmployeeById", con);
                    sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddWithValue("@Id", id);
                    con.Open();
                    SqlDataReader dataReader = sqlCommand.ExecuteReader();
                    while (dataReader.Read())
                    {
                        employee.Id = Convert.ToInt32(dataReader["Id"]);
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
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return employee;
        }

        /// <summary>
        /// Updates the employee.
        /// </summary>
        /// <param name="employee">The employee.</param>
        /// <returns>returns the updated employee</returns>
        public Employee UpdateEmployee(Employee employee)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(this.connectionString))
                {
                    SqlCommand sqlCommand = new SqlCommand("spUpdateEmployee", con);
                    sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddWithValue("@Id", employee.Id);
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
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return employee;
        }
    }
}

