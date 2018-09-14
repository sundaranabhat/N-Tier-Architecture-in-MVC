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
            var model = new List<EmployeeModel>();
            model = bal.EmpList();
            return View(model);

        }

        public ActionResult Search(int id)
        {
            if (id != 0)
            {
                var bal = new EmployeeBAL();
                var model = new EmployeeModel();

                model = bal.DetailByID(id);
                return View(model);
            }
            else
            {
                return RedirectToAction("Index", "Employee");
            }

        }

        public ActionResult Create()
        {
            var model = new EmployeeModel();
            return View(model);
        }

        [HttpPost]
        public ActionResult Create(EmployeeModel emp)
        {
            if (ModelState.IsValid)
            {
                var bal = new EmployeeBAL();
                bal.Insert(emp);
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
            var model = new EmployeeModel();
            model = bal.DetailByID(id);
            return View(model);
        }

        [HttpPost]

        public ActionResult Edit(EmployeeModel emp)
        {
            if (ModelState.IsValid)
            {
                var bal = new EmployeeBAL();
                bal.Update(emp);
                return RedirectToAction("Index", "Employee");
            }

            else
            {
                return View();
            }
        }


        public ActionResult Delete(int id)
        {
            var bal = new EmployeeBAL();
            bal.Delete(id);
            return RedirectToAction("Index", "Employee");
        }

    }
}