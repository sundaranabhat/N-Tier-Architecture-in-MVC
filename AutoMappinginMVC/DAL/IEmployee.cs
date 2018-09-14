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
        List<Employee1> GetEmployeeList();
        Employee1 GetEmployeeByID(int id);
        void InsertEmployee(Employee1 model);
        void UpdateEmployee(Employee1 model);


    }
}
