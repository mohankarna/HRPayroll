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
    public class MaritalStatusController : Controller
    {
        public readonly MaritalStatusService Service;
        public MaritalStatusController()
        {
            Service = new MaritalStatusService();
        }
        // GET: MaritalStatus
        public ActionResult Index()
        {
            var maritalstatus = Service.GetAll();
            return View(maritalstatus);
        }

        // GET: MaritalStatus/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var maritalStatus = Service.GetById(id.GetValueOrDefault());

            if (maritalStatus == null)
            {
                return HttpNotFound();
            }
            return View(maritalStatus);
        }

        // GET: MaritalStatus/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MaritalStatus/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name")] MaritalStatus maritalStatus)
        {
            if (ModelState.IsValid)
            {
                Service.Add(maritalStatus);
                return RedirectToAction("Index");
            }

            return View(maritalStatus);
        }

        // GET: MaritalStatus/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MaritalStatus maritalStatus = Service.GetById(id.GetValueOrDefault());
            if (maritalStatus == null)
            {
                return HttpNotFound();
            }
            return View(maritalStatus);
        }

        // POST: MaritalStatus/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name")] MaritalStatus maritalStatus)
        {
            if (ModelState.IsValid)
            {
                Service.Update(maritalStatus);
                return RedirectToAction("Index");
            }
            return View(maritalStatus);
        }

        // GET: MaritalStatus/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MaritalStatus maritalStatus = Service.GetById(id.GetValueOrDefault());
            if (maritalStatus == null)
            {
                return HttpNotFound();
            }
            return View(maritalStatus);
        }

        // POST: MaritalStatus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MaritalStatus maritalStatus = Service.GetById(id);
            Service.Delete(maritalStatus);
             return RedirectToAction("Index");
        }

      
    }
}
