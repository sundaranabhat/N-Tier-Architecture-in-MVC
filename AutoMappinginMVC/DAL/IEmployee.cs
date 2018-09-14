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
        List<EmployeeModel> GetEmployeeList();
        EmployeeModel GetEmployeeByID(int id);
        void InsertEmployee(EmployeeModel model);
        void UpdateEmployee(EmployeeModel model);
        void DeleteEmployee(int id);


    }
}
