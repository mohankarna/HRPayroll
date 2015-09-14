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
    public class TaxSetupsController : Controller
    {
          public readonly TaxSetupService Service;
        public TaxSetupsController()
        {
            Service = new TaxSetupService();
        }

        // GET: TaxSetups
        public ActionResult Index()
        {
            var taxSetups = Service.GetAll();
            return View(taxSetups);
        }

        // GET: TaxSetups/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TaxSetup taxSetup = Service.GetById(id.GetValueOrDefault());
            if (taxSetup == null)
            {
                return HttpNotFound();
            }
            return View(taxSetup);
        }

        // GET: TaxSetups/Create
        public ActionResult Create()
        {
           
            return View();
        }

        // POST: TaxSetups/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create( TaxSetup taxSetup)
        {
            if (ModelState.IsValid)
            {
                Service.Add(taxSetup);
                return RedirectToAction("Index");
            }

            return View(taxSetup);
        }

        // GET: TaxSetups/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TaxSetup taxSetup = Service.GetById(id.GetValueOrDefault());
            if (taxSetup == null)
            {
                return HttpNotFound();
            }
           return View(taxSetup);
        }

        // POST: TaxSetups/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit( TaxSetup taxSetup)
        {
            if (ModelState.IsValid)
            {
                Service.Update(taxSetup);
                return RedirectToAction("Index");
            }
           return View(taxSetup);
        }

        // GET: TaxSetups/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TaxSetup taxSetup = Service.GetById(id.GetValueOrDefault());
            if (taxSetup == null)
            {
                return HttpNotFound();
            }
            return View(taxSetup);
        }

        // POST: TaxSetups/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TaxSetup taxSetup = Service.GetById(id);
           Service.Delete(taxSetup);
            return RedirectToAction("Index");
        }

      
    }
}
