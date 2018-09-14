using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMappinginMVC.BAL;
using AutoMappinginMVC.DAL;

namespace AutoMappinginMVC.Controllers
{
    public class EmployeeController : Controller
    {
        public ActionResult Index()
        {
            var bal = new EmployeeBAL();
            var model = new List<Employee1>();
            model = bal.EmpList();
            return View(model);

        }

        public ActionResult Search(int id)
        {
            if (id != 0)
            {
                var bal = new EmployeeBAL();
                var model = new Employee1();

                model = bal.DetailByID(id);
            }
            return null;
        }

        public ActionResult Create()
        {
            var model = new Employee1();
            return View(model);
        }

        [HttpPost]
        public ActionResult Create(Employee1 emp)
        {
            if (ModelState.IsValid)
            {
                var bal = new EmployeeBAL();
                bal.InsertEmployee(emp);
                return RedirectToAction("Index", "Employee");
            }

            else
            {
                return View(emp);
            }

        }

        public ActionResult Edit(int id)
        {
           
            var bal = new EmployeeBAL();
            var model = new Employee1();
            model = bal.DetailByID(id);

            return View(model);
        }

        [HttpPost]

        public ActionResult Edit(Employee1 emp)
        {
            if (ModelState.IsValid)
            {


                var bal = new EmployeeBAL();
                var model = new Employee1();
                bal.UpdateEmployee(emp);
                return RedirectToAction("Index", "Employee");
            }

            else
            {
                return View();
            }
        }

    }
}