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
    public class WorkingDaysEntriesController : Controller
    {
        public readonly WorkingDaysEntryService Service;
        public WorkingDaysEntriesController()
        {
            Service = new WorkingDaysEntryService();
        }

        // GET: WorkingDaysEntries
        public ActionResult Index()
        {
            var workingDaysEntries = Service.GetAll();
            return View(workingDaysEntries);
        }

        // GET: WorkingDaysEntries/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var workingDaysEntry = Service.GetById(id.GetValueOrDefault());
            if (workingDaysEntry == null)
            {
                return HttpNotFound();
            }
            return View(workingDaysEntry);
        }

        // GET: WorkingDaysEntries/Create
        public ActionResult Create()
        {

            return View();
        }

        // POST: WorkingDaysEntries/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(List<MonthlySalaryDetail> workingDaysEntry)
        {
            if (ModelState.IsValid)
            {
               // Service.Add(workingDaysEntry);
                return RedirectToAction("Index");
            }
            return View(workingDaysEntry);
        }

        // GET: WorkingDaysEntries/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WorkingDaysEntry workingDaysEntry = Service.GetById(id.GetValueOrDefault());
            if (workingDaysEntry == null)
            {
                return HttpNotFound();
            }

            return View(workingDaysEntry);
        }

        // POST: WorkingDaysEntries/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,BranchId,Year,Month,TotalDaysInMonth")] WorkingDaysEntry workingDaysEntry)
        {
            if (ModelState.IsValid)
            {
                Service.Update(workingDaysEntry);
                return RedirectToAction("Index");
            }

            return View(workingDaysEntry);
        }

        // GET: WorkingDaysEntries/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WorkingDaysEntry workingDaysEntry = Service.GetById(id.GetValueOrDefault());
            if (workingDaysEntry == null)
            {
                return HttpNotFound();
            }
            return View(workingDaysEntry);
        }

        // POST: WorkingDaysEntries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            WorkingDaysEntry workingDaysEntry = Service.GetById(id);
            Service.Delete(workingDaysEntry);
            return RedirectToAction("Index");
        }


    }
}
