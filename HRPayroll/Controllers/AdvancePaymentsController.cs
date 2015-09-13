using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HRPayroll.Domain;
using HRPayroll.Domain.Entity;
using HRPayroll.Models;
using HRPayroll.Service;

namespace HRPayroll.Controllers
{
    public class AdvancePaymentsController : Controller
    {
        private readonly AdvancePaymentService Service;

        public AdvancePaymentsController ()
        {
            Service=new AdvancePaymentService();
        }

        // GET: AdvancePayments
        public ActionResult Index()
        {
            var advancePayments = Service.GetAll();
            return View(advancePayments);
        }

        // GET: AdvancePayments/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AdvancePayment advancePayment = Service.GetById(id.GetValueOrDefault());
            if (advancePayment == null)
            {
                return HttpNotFound();
            }
            return View(advancePayment);
        }

        // GET: AdvancePayments/Create
        public ActionResult Create()
        {
           
            return View();
        }

        // POST: AdvancePayments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AdvancePayment advancePayment)
        {
            if (ModelState.IsValid)
            {
                Service.Add(advancePayment);
                return RedirectToAction("Index");
            }

            
            return View(advancePayment);
        }

        // GET: AdvancePayments/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AdvancePayment advancePayment = Service.GetById(id.GetValueOrDefault());
            if (advancePayment == null)
            {
                return HttpNotFound();
            }
           
            return View(advancePayment);
        }

        // POST: AdvancePayments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit( AdvancePayment advancePayment)
        {
            if (ModelState.IsValid)
            {
                Service.Update(advancePayment);
                return RedirectToAction("Index");
            }
            Service.Update(advancePayment);
            return View(advancePayment);
        }

        // GET: AdvancePayments/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AdvancePayment advancePayment =Service.GetById(id.GetValueOrDefault());
            if (advancePayment == null)
            {
                return HttpNotFound();
            }
            return View(advancePayment);
        }

        // POST: AdvancePayments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AdvancePayment advancePayment = Service.GetById(id);
           Service.Delete(advancePayment);
            return RedirectToAction("Index");
        }

      
    }
}
