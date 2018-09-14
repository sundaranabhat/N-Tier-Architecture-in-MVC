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
        public EmployeeModel GetEmployeeByID(int id)
        {
            using (var db = new CRUDDBEntities())
            {
                //create a Mapper
                 Mapper.Initialize(cfg =>cfg.CreateMap<Employee, EmployeeModel>());
                var tempEmp = db.Employees.FirstOrDefault(x => x.EmployeeID == id);
                //Map the source to the destination
                var model = Mapper.Map<Employee, EmployeeModel>(tempEmp);
                return model;
            }

            
        }

        public List<EmployeeModel> GetEmployeeList()
        {
            using (var db = new CRUDDBEntities())
            {
              //  var TempList = new List<Employee>();
                var resultList = db.Employees.ToList();
                //inititalizing the mapper
                Mapper.Initialize(cfg => cfg.CreateMap<Employee, EmployeeModel>());

                //Mapping List<Source> to List<Destination>
                var TempList = Mapper.Map<List<Employee>,List<EmployeeModel>>(resultList);

                return TempList;
            }

        }

        public void UpdateEmployee(EmployeeModel model)
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

        public void DeleteEmployee(int id)
        {
            using(var db = new CRUDDBEntities())
            {
                var empToDelete = db.Employees.FirstOrDefault(x => x.EmployeeID == id);
                if (empToDelete != null)
                {
                    db.Employees.Remove(empToDelete);
                    db.SaveChanges();
                }
                
            }
        }

        public void InsertEmployee(EmployeeModel model)
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

    }
}