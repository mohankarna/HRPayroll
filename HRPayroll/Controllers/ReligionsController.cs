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
    public class ReligionsController : Controller
    {
        
         
        public readonly ReligionService  Service;

        public ReligionsController()
        {
            Service = new ReligionService();
        }

        public ActionResult Index()
        {
            var religions = Service.GetAll();
           
            return View(religions);
        }
        // GET: Religions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Religion religion = Service.GetById(id.GetValueOrDefault());
            if (religion == null)
            {
                return HttpNotFound();
            }
            return View(religion);
        }

        // GET: Religions/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Religions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create( Religion religion)
        {
            if (ModelState.IsValid)
            {
                Service.Add(religion);
                return RedirectToAction("Index");
            }

            return View(religion);
        }

        // GET: Religions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Religion religion = Service.GetById(id.GetValueOrDefault());
            if (religion == null)
            {
                return HttpNotFound();
            }
            return View(religion);
        }

        // POST: Religions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit( Religion religion)
        {
            if (ModelState.IsValid)
            {
                Service.Update(religion);
                return RedirectToAction("Index");
            }
            return View(religion);
        }

        // GET: Religions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Religion religion = Service.GetById(id.GetValueOrDefault());
            if (religion == null)
            {
                return HttpNotFound();
            }
            return View(religion);
        }

        // POST: Religions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Religion religion = Service.GetById(id);
          Service.Delete(religion);
            return RedirectToAction("Index");
        }

       
    }
}
