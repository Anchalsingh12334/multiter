using CommonLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Data.SqlClient;
using Microsoft.Data;
using System.Collections;
using System.Data; 
namespace DataAccessLayer
{
    public class EmployeeDataAccessDb
    {
        private DbConnection db = new DbConnection();
        public List<Employee> GetEmployees()
        {
            string query = "select * from employee";
            SqlCommand command = new SqlCommand();
            command.CommandText = query;
            command.Connection = db.cnn;
            if (db.cnn.State == ConnectionState.Closed)
                db.cnn.Open();
            SqlDataReader reader = command.ExecuteReader();
            List<Employee> employees = new List<Employee>();
            while (reader.Read())
            {
                Employee emp = new Employee();
                emp.Id = (int)reader["id"];
                emp.Name = reader["Name"].ToString();
                emp.Email = reader["Email"].ToString();
                emp.Mobile = reader["Mobie"].ToString();
                emp.Address = reader["Address"].ToString();
                employees.Add(emp);
            }
            db.cnn.Close();
            return employees;


        }
        public Employee GetEmployeeById(int id)
        {
            string query = "select* from employee where Id="+id+"";
            SqlCommand command = new SqlCommand();
            command.CommandText = query;
            command.Connection = db.cnn;
            if (db.cnn.State == ConnectionState.Closed)
                db.cnn.Open();
            SqlDataReader reader = command.ExecuteReader();
            reader.Read();
          
                Employee emp = new Employee();
                emp.Id = (int)reader["id"];
                emp.Name = reader["Name"].ToString();
                emp.Email = reader["Email"].ToString();
                emp.Mobile = reader["Mobile"].ToString();
                emp.Address = reader["Address"].ToString();
               
            db.cnn.Close();
            return emp;
        }

            public bool CreateEmployees(Employee employee)
        {
            string query = "insert into Employee values('" + employee.Name + "','" + employee.Email + "','" + employee.Mobile + "','" + employee.Address + "')";
            SqlCommand cmd = new SqlCommand(query, db.cnn);
            if (db.cnn.State == ConnectionState.Closed)
                db.cnn.Open();
            int i = cmd.ExecuteNonQuery();
            db.cnn.Close();
            return Convert.ToBoolean(i);
        }

        public bool DeleteEmployees(int id)
        {
            string query = "delete from Employee where id =" + id + "";
            SqlCommand cmd = new SqlCommand(query, db.cnn);
            if (db.cnn.State ==ConnectionState.Closed)
                db.cnn.Open();
            int i = cmd.ExecuteNonQuery();
            db.cnn.Close();
            return Convert.ToBoolean(i);
        }

        public bool UpdateEmployees(Employee employee)
        {
            string query = "update employee set  name="+employee.Name+","+employee.Email+","+employee.Mobile+","+employee.Address+ "where Id="+employee.Id+"";
            SqlCommand cmd = new SqlCommand(query, db.cnn);
            if (db.cnn.State == ConnectionState.Closed)
                db.cnn.Open();
            int i = cmd.ExecuteNonQuery();
            db.cnn.Close();
            return Convert.ToBoolean(i);
        }
    }
}