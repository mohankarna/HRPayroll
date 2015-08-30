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
    public class LeaveSetupsController : Controller
    {
        public readonly LeaveSetupService Service;

        public LeaveSetupsController()
        {
            Service= new LeaveSetupService();
        }

        // GET: LeaveSetups
        public ActionResult Index()
        {
            var leaveSetups = Service.GetAll();
            return View(leaveSetups);
        }

        // GET: LeaveSetups/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LeaveType leaveType = Service.GetById(id.ToString());
            if (leaveType == null)
            {
                return HttpNotFound();
            }
            return View(leaveType);
        }

        // GET: LeaveSetups/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LeaveSetups/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,LeaveName,LeaveDescription,AllowedPerYear,ServiceTypeId,EthenicId,MaritalStatusId,GenderId,AllowHalfDay,IsPayable")] LeaveType leaveType)
        {
            if (ModelState.IsValid)
            {
                Service.Add(leaveType);
                return RedirectToAction("Index");
            }

           return View(leaveType);
        }

        // GET: LeaveSetups/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LeaveType leaveType = Service.GetById(id.ToString());
            if (leaveType == null)
            {
                return HttpNotFound();
            }
            
            return View(leaveType);
        }

        // POST: LeaveSetups/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,LeaveName,LeaveDescription,AllowedPerYear,ServiceTypeId,EthenicId,MaritalStatusId,GenderId,AllowHalfDay,IsPayable")] LeaveType leaveType)
        {
            if (ModelState.IsValid)
            {
                Service.Update(leaveType);
                return RedirectToAction("Index");
            }
            return View(leaveType);
        }

        // GET: LeaveSetups/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LeaveType leaveType = Service.GetById(id.ToString());
            if (leaveType == null)
            {
                return HttpNotFound();
            }
            return View(leaveType);
        }

        // POST: LeaveSetups/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            LeaveType leaveType = Service.GetById(id.ToString());
           Service.Delete(leaveType);
            return RedirectToAction("Index");
        }

       
    }
}
