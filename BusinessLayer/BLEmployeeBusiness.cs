using CommonLayer.Models;
using DataAccessLayer;

using System;
using System.Collections.Generic;

namespace BusinessLayer
{
    public class BLEmployeeBusiness
    {
        private EmployeeDataAccessDb employeeData;
        public BLEmployeeBusiness()
        {
            employeeData = new EmployeeDataAccessDb();

        }
        public List<Employee> GetEmployees()
        {
            return employeeData.GetEmployees();
        }
        public Employee GetEmployeeById(int id)
        {
            return employeeData.GetEmployeeById(id);
        }
        public bool DeleteEmployee(int id)
        {
            return employeeData.DeleteEmployees(id);
        }
        public bool CreateEmployee(Employee emp)
        {
            return employeeData.CreateEmployees(emp);
        }
        public bool UpdateEmployee(Employee emp)
        {
            return employeeData.UpdateEmployees(emp);
        }
    }
}
