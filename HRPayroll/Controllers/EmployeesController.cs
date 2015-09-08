using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HRPayroll.Domain.Entity;
using HRPayroll.Models;
using HRPayroll.Service;

namespace HRPayroll.Controllers
{
    public class EmployeesController : Controller
    {
         
        public readonly EmployeeService Service;

        public EmployeesController()
        {
            Service = new EmployeeService();
        }

        // GET: Employees
        public ActionResult Index()
        {
            var employees = Service.GetAll();
            // var employees = db.Employees.Include(e => e.Branch).Include(e => e.Department).Include(e => e.Designation).Include(e => e.Title);
            return View(employees);
        }

        // GET: Employees/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = Service.GetById(id.GetValueOrDefault());
           // Employee employee = Service.GetById(id.GetValueOrDefault());
            //Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // GET: Employees/Create
        public ActionResult Create()
        {
            //ViewBag.BranchId = new SelectList(db.Branches, "Id", "BranchName");
            //ViewBag.DepartmentId = new SelectList(db.Departments, "Id", "DepartmentName");
            //ViewBag.DesignationId = new SelectList(db.Designations, "Id", "DesignationName");
            //ViewBag.TitleId = new SelectList(db.Titles, "Id", "TitleName");
            return View();
        }

        // POST: Employees/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Employee employee)
        {
            if (ModelState.IsValid)
            {
                //db.Employees.Add(employee);
                //db.SaveChanges();
                Service.Add(employee);
                return RedirectToAction("Index");
            }

            //ViewBag.BranchId = new SelectList(db.Branches, "Id", "BranchName", employee.BranchId);
            //ViewBag.DepartmentId = new SelectList(db.Departments, "Id", "DepartmentName", employee.DepartmentId);
            //ViewBag.DesignationId = new SelectList(db.Designations, "Id", "DesignationName", employee.DesignationId);
            //ViewBag.TitleId = new SelectList(db.Titles, "Id", "TitleName", employee.TitleId);
            //ViewBag.GenderId = new SelectList(db.Genders, "Id", "GenderName", employee.GenderId);
            return View(employee);
        }

        // GET: Employees/Edit/5
        public ActionResult Edit(int id)
        {
            
            var employee = Service.GetById(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
           
            return View(employee);
        }

        // POST: Employees/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Employee employee)
        {
            if (ModelState.IsValid)
            {
                Service.Update(employee);             
                return RedirectToAction("Index");
            }
         
            return View(employee);
        }

        // GET: Employees/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = Service.GetById(id.GetValueOrDefault());
            //Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Employee employee =Service.GetById(id);
            Service.Delete(employee);          
            return RedirectToAction("Index");
        }

     
    }
}
