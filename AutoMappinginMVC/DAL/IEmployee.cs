//using AutoMappinginMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoMappinginMVC.DAL
{
 public  interface IEmployee
    {
        List<Employee> GetEmployeeList();
        Employee GetEmployeeByID(int id);
        void InsertEmployee(Employee model);
        void UpdateEmployee(Employee model);


    }
}
