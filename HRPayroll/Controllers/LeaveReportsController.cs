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
    public class LeaveReportsController : Controller
    {
        public readonly LeaveReportService Service;
        public LeaveReportsController()
        {
            Service = new LeaveReportService();
        }

        // GET: LeaveReports
        public ActionResult Index()
        {
            var leaveReport = Service.GetAll();
            return View(leaveReport);
        }

        // GET: LeaveReports/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LeaveReport leaveReport = Service.GetById(id.ToString());
            if (leaveReport == null)
            {
                return HttpNotFound();
            }
            return View(leaveReport);
        }

        // GET: LeaveReports/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LeaveReports/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Branch,From,To")] LeaveReport leaveReport)
        {
            if (ModelState.IsValid)
            {
                Service.Add(leaveReport);
                return RedirectToAction("Index");
            }

            return View(leaveReport);
        }

        // GET: LeaveReports/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LeaveReport leaveReport = Service.GetById(id.ToString());
            if (leaveReport == null)
            {
                return HttpNotFound();
            }
            return View(leaveReport);
        }

        // POST: LeaveReports/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Branch,From,To")] LeaveReport leaveReport)
        {
            if (ModelState.IsValid)
            {
                Service.Update(leaveReport);
                return RedirectToAction("Index");
            }
            return View(leaveReport);
        }

        // GET: LeaveReports/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LeaveReport leaveReport = Service.GetById(id.ToString());
            if (leaveReport == null)
            {
                return HttpNotFound();
            }
            return View(leaveReport);
        }

        // POST: LeaveReports/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            LeaveReport leaveReport = Service.GetById(id.ToString());
            Service.Delete(leaveReport);
            return RedirectToAction("Index");
        }

       
    }
}
