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
    public class HrGlobalSetupsController : Controller
    {
        private readonly HrGlobalSetupService Service;
        public HrGlobalSetupsController()
    {
        Service=new HrGlobalSetupService();
    }

        // GET: HrGlobalSetups
        public ActionResult Index()
        {
            var hrGlobalSetups = Service.GetAll();
            return View(hrGlobalSetups);
        }

        // GET: HrGlobalSetups/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HrGlobalSetup hrGlobalSetup = Service.GetById(id.ToString());
            if (hrGlobalSetup == null)
            {
                return HttpNotFound();
            }
            return View(hrGlobalSetup);
        }

        // GET: HrGlobalSetups/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: HrGlobalSetups/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,WorkingHrsPerDay,OtRate")] HrGlobalSetup hrGlobalSetup)
        {
            if (ModelState.IsValid)
            {
                Service.Add(hrGlobalSetup);
                return RedirectToAction("Index");
            }

            return View(hrGlobalSetup);
        }

        // GET: HrGlobalSetups/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HrGlobalSetup hrGlobalSetup = Service.GetById(id.ToString());
            if (hrGlobalSetup == null)
            {
                return HttpNotFound();
            }
            return View(hrGlobalSetup);
        }

        // POST: HrGlobalSetups/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,WorkingHrsPerDay,OtRate")] HrGlobalSetup hrGlobalSetup)
        {
            if (ModelState.IsValid)
            {
                Service.Update(hrGlobalSetup);
                return RedirectToAction("Index");
            }
            return View(hrGlobalSetup);
        }

        // GET: HrGlobalSetups/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HrGlobalSetup hrGlobalSetup = Service.GetById(id.ToString());
            if (hrGlobalSetup == null)
            {
                return HttpNotFound();
            }
            return View(hrGlobalSetup);
        }

        // POST: HrGlobalSetups/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            HrGlobalSetup hrGlobalSetup = Service.GetById(id.ToString());
            Service.Delete(hrGlobalSetup);
            return RedirectToAction("Index");
        }

      
    }
}
