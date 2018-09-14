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


        public EmployeeModel DetailByID(int id)
        {
            var model = new EmployeeModel();
            model = employeeService.GetEmployeeByID(id);

            return model;
        }

        public List<EmployeeModel> EmpList()
        {
            var model = new List<EmployeeModel>();
            model = employeeService.GetEmployeeList();
           
            return model;

        }

        public void Insert(EmployeeModel emp)
        {
            employeeService.InsertEmployee(emp);
        }

        public void Update(EmployeeModel emp)
        {
            employeeService.UpdateEmployee(emp);
        }

        public void Delete(int id)
        {
            employeeService.DeleteEmployee(id);
        }
    }
}