using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace DataAccessWeb.Models
{
    public class Employee
    {
        public int EmpId { get; set; }
        public string EmpName { get; set; }
        public string EmpAddress { get; set; }
        public int EmpSalary { get; set; }
        public int DeptId { get; set; }
    }
    public class EmployeeDb
    {
        private static readonly string connStr = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;

        public void AddEmployee(Employee emp)
        {
            SqlConnection sqlConnection = new SqlConnection(connStr);
            SqlCommand cmd = new SqlCommand("CreateEmployee", sqlConnection);

            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@name", emp.EmpName);
            cmd.Parameters.AddWithValue("@address", emp.EmpAddress);
            cmd.Parameters.AddWithValue("@salary", emp.EmpSalary);
            cmd.Parameters.AddWithValue("@dept", emp.DeptId);

            try
            {
                sqlConnection.Open();
                cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                throw new Exception("Insertion failed!", ex);
            }
            finally
            {
                sqlConnection.Close();
                sqlConnection.Dispose();
            }
        }

        public List<Employee> GetAllEmployees()
        {
            SqlConnection sqlConnection = new SqlConnection(connStr);
            SqlCommand cmd = new SqlCommand("Select * From EmpTable", sqlConnection);
            List<Employee> employees = new List<Employee>();

            try
            {
                sqlConnection.Open();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var emp = new Employee();
                    emp.EmpId = Convert.ToInt32(reader[0]);
                    emp.EmpName = reader[1].ToString();
                    emp.EmpAddress = reader[2].ToString();
                    emp.EmpSalary = Convert.ToInt32(reader[3]);
                    if (reader[4] is DBNull)
                        emp.DeptId = 0;
                    else
                        emp.DeptId = Convert.ToInt32(reader[4]);
                    employees.Add(emp);
                }
                return employees;
            }
            catch (SqlException sqlEx)
            {
                throw new Exception("Reading of data failed!", sqlEx);
            }
            finally
            {
                sqlConnection.Close();
                sqlConnection.Dispose();
            }
        }
    }
}