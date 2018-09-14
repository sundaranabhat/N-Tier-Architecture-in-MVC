using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using AutoMappinginMVC.Models;
using AutoMapper;

namespace AutoMappinginMVC.DAL
{
    public class Implementation : IEmployee
    {
        public Employee GetEmployeeByID(int id)
        {
            using (var db = new CRUDDBEntities())
            {
                //create a Mapper
                 Mapper.Initialize(cfg =>cfg.CreateMap<Employee, Employee>() );
                var tempEmp = db.Employees.FirstOrDefault(x => x.EmployeeID == id);
                //Map the source to the destination
                var model = Mapper.Map<Employee, Employee>(tempEmp);
                return model;
            }

            //var empValue = db.Employees.FirstOrDefault(x => x.EmployeeID == id);
            //var model = new Employee();
            //if(empValue != null)
            //{
            //    model.EmployeeID = empValue.EmployeeID;
            //    model.Name = empValue.Name;
            //    model.Age = empValue.Age;
            //    model.Salary = empValue.Salary;
            //    model.Position = empValue.Position;

            //}
            //return model;
        }


        public void InsertEmployee(Employee model)
        {
            using (var db = new CRUDDBEntities())
            {
                var empToAdd = db.Employees.FirstOrDefault(x => x.EmployeeID == model.EmployeeID);

                if (empToAdd != null)
                {
                    empToAdd.EmployeeID = model.EmployeeID;
                    empToAdd.Age = model.Age;
                    empToAdd.Salary = model.Salary;
                    empToAdd.Name = model.Name;
                    empToAdd.Position = model.Position;

                    db.Entry(empToAdd).State = EntityState.Modified;
                    db.SaveChanges();
                }
            }

        }

        public List<Employee> GetEmployeeList()
        {
            using (var db = new CRUDDBEntities())
            {
                var TempList = new List<Employee>();
                var resultList = db.Employees.ToList();

                if (resultList != null)
                {
                    foreach (var item in resultList)
                    {
                        var model = new Employee();
                        model.Age = item.Age;
                        model.EmployeeID = item.EmployeeID;
                        model.Name = item.Name;
                        model.Position = item.Position;
                        model.Salary = item.Salary;

                        TempList.Add(model);
                    }
                }


                return TempList;
            }

        }

        public void UpdateEmployee(Employee model)
        {
            using (var db = new CRUDDBEntities())
            {
                var EmpToEdit = db.Employees.FirstOrDefault(x => x.EmployeeID == model.EmployeeID);

                if (EmpToEdit != null)
                {
                    EmpToEdit.EmployeeID = model.EmployeeID;
                    EmpToEdit.Age = model.Age;
                    EmpToEdit.Salary = model.Salary;
                    EmpToEdit.Position = model.Position;

                    EmpToEdit.Name = model.Name;

                    db.Entry(EmpToEdit).State = EntityState.Modified;
                    db.SaveChanges();



                }
            }
        }
    }
}