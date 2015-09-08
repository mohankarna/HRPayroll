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
    public class LeaveRequestsController : Controller
    {
        private readonly LeaveRequestService Service;

        public LeaveRequestsController()
        {
            Service = new LeaveRequestService();
        }


        // GET: LeaveRequests
        public ActionResult Index()
        {
            var leaveRequests = Service.GetAll();
            return View(leaveRequests);
        }

        // GET: LeaveRequests/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LeaveRequest leaveRequest = Service.GetById(id.GetValueOrDefault());
            if (leaveRequest == null)
            {
                return HttpNotFound();
            }
            return View(leaveRequest);
        }

        // GET: LeaveRequests/Create
        public ActionResult Create()
        {

            return View();
        }

        // POST: LeaveRequests/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(LeaveRequest leaveRequest)
        {
            if (ModelState.IsValid)
            {
                Service.Add(leaveRequest);
                return RedirectToAction("Index");
            }

            // ViewBag.EmployeeId = new SelectList(db.Employees, "Id", "EmployeeName", leaveRequest.EmployeeId);
            return View(leaveRequest);
        }

        // GET: LeaveRequests/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LeaveRequest leaveRequest = Service.GetById(id.GetValueOrDefault());
            if (leaveRequest == null)
            {
                return HttpNotFound();
            }
            // ViewBag.EmployeeId = new SelectList(db.Employees, "Id", "EmployeeName", leaveRequest.EmployeeId);
            return View(leaveRequest);
        }

        // POST: LeaveRequests/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,EmployeeId,LeaveType,Date,LeaveFrom,LeaveTo,TotalDays,Reason,IsHalfDay")] LeaveRequest leaveRequest)
        {
            if (ModelState.IsValid)
            {
                Service.Update(leaveRequest);
                return RedirectToAction("Index");
            }
            //ViewBag.EmployeeId = new SelectList(db.Employees, "Id", "EmployeeName", leaveRequest.EmployeeId);
            return View(leaveRequest);
        }

        // GET: LeaveRequests/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LeaveRequest leaveRequest = Service.GetById(id.GetValueOrDefault());
            if (leaveRequest == null)
            {
                return HttpNotFound();
            }
            return View(leaveRequest);
        }

        // POST: LeaveRequests/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            LeaveRequest leaveRequest = Service.GetById(id);
            Service.Delete(leaveRequest);
            return RedirectToAction("Index");
        }


    }
}
