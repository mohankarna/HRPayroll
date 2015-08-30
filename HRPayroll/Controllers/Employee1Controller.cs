using HRPayroll.Domain.Entity;
using HRPayroll.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HRPayroll.Controllers
{
    public class Employee1Controller : Controller
    {
        public readonly Employee1service Service;
        public Employee1Controller()
        {
            Service = new Employee1service();
        }
        // GET: Employee1
        public ActionResult Index()
        {
            var employeess = Service.GetAll();
            return View(employeess);
        }

        // GET: Employee1/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Employee1/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Employee1/Create
        [HttpPost]
        public ActionResult Create(Employee1 model)
        {
            try
            {
                // TODO: Add insert logic here
                if (ModelState.IsValid)
                {
                    Service.Add(model);
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Employee1/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Employee1/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Employee1/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Employee1/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
