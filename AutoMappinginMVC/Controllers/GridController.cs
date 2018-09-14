﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using AutoMappinginMVC.DAL;

namespace AutoMappinginMVC.Controllers
{
    public class GridController : Controller
    {
        private CRUDDBEntities db = new CRUDDBEntities();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Employees_Read([DataSourceRequest]DataSourceRequest request)
        {
            IQueryable<Employee> employees = db.Employees;
            DataSourceResult result = employees.ToDataSourceResult(request, employee => new {
                EmployeeID = employee.EmployeeID,
                Name = employee.Name,
                Position = employee.Position,
                Age = employee.Age,
                Salary = employee.Salary
            });

            return Json(result);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}
