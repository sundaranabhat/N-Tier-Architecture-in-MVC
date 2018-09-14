using AutoMappinginMVC.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace AutoMappinginMVC.BAL
{
    public class EmployeeBAL
    {
        private Implementation employeeService;

        public EmployeeBAL()
        {
            employeeService = new Implementation();
        }


        public Employee DetailByID(int id)
        {
            var model = new Employee();
            model = employeeService.GetEmployeeByID(id);

            return model;
        }

        public List<Employee> EmpList()
        {
            var model = new List<Employee>();
            model = employeeService.GetEmployeeList();
           
            return model;

        }

        public void InsertEmployee(Employee emp)
        {
            employeeService.InsertEmployee(emp);
        }

        public void UpdateEmployee(Employee emp)
        {
            employeeService.UpdateEmployee(emp);
        }
    }
}