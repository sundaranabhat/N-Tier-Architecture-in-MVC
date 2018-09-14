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


        public Employee1 DetailByID(int id)
        {
            var model = new Employee1();
            model = employeeService.GetEmployeeByID(id);

            return model;
        }

        public List<Employee1> EmpList()
        {
            var model = new List<Employee1>();
            model = employeeService.GetEmployeeList();
           
            return model;

        }

        public void InsertEmployee(Employee1 emp)
        {
            employeeService.InsertEmployee(emp);
        }

        public void UpdateEmployee(Employee1 emp)
        {
            employeeService.UpdateEmployee(emp);
        }
    }
}