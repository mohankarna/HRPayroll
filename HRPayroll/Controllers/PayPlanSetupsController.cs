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
    public class PayPlanSetupsController : Controller
    {
       public readonly PayPlanSetupService Service;
        public PayPlanSetupsController()
        {
            Service = new PayPlanSetupService();
        }


        // GET: PayPlanSetups
        public ActionResult Index()
        {
            var payPlanSetups = Service.GetAll();
            return View(payPlanSetups);
        }

        // GET: PayPlanSetups/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var payPlanSetup = Service.GetById(id.GetValueOrDefault());
            if (payPlanSetup == null)
            {
                return HttpNotFound();
            }
            return View(payPlanSetup);
        }

        // GET: PayPlanSetups/Create
        public ActionResult Create()
        {
           
            return View();
        }

        // POST: PayPlanSetups/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PayPlanSetup payPlanSetup)
        {
            if (ModelState.IsValid)
            {
                Service.Add(payPlanSetup);
                return RedirectToAction("Index");
            }

            return View(payPlanSetup);
        }

        // GET: PayPlanSetups/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PayPlanSetup payPlanSetup = Service.GetById(id.GetValueOrDefault());
            if (payPlanSetup == null)
            {
                return HttpNotFound();
            }
            return View(payPlanSetup);
        }

        // POST: PayPlanSetups/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,EmployeeId,BasicSalary,PreviousGrade,CurrentGrade,SpecialAllow,DearnessAllow,OtherAllow,CIT,Insurance")] PayPlanSetup payPlanSetup)
        {
            if (ModelState.IsValid)
            {
                Service.Update(payPlanSetup);
                return RedirectToAction("Index");
            }
          return View(payPlanSetup);
        }

        // GET: PayPlanSetups/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PayPlanSetup payPlanSetup = Service.GetById(id.GetValueOrDefault());
            if (payPlanSetup == null)
            {
                return HttpNotFound();
            }
            return View(payPlanSetup);
        }

        // POST: PayPlanSetups/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PayPlanSetup payPlanSetup = Service.GetById(id);
           Service.Delete(payPlanSetup);
            return RedirectToAction("Index");
        }

      
    }
}
