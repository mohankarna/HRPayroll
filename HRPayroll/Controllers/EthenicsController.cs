using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HRPayroll.Domain;
using HRPayroll.Models;
using HRPayroll.Service;

namespace HRPayroll.Controllers
{
    public class EthenicsController : Controller
    {
        public readonly EthenicService Service;
        public EthenicsController()
        {
            Service = new EthenicService();
        }

        // GET: Ethenics
        public ActionResult Index()
        {
            var ethenics = Service.GetAll();
            return View(ethenics);
        }

        // GET: Ethenics/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var ethenic = Service.GetById(id.ToString());
            
            if (ethenic == null)
            {
                return HttpNotFound();
            }
            return View(ethenic);
        }

        // GET: Ethenics/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Ethenics/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,EthenicGroup")] Ethenic ethenic)
        {
            if (ModelState.IsValid)
            {
                Service.Add(ethenic);
                return RedirectToAction("Index");
               
            }

            return View(ethenic);
        }

        // GET: Ethenics/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ethenic ethenic = Service.GetById(id.ToString());
            if (ethenic == null)
            {
                return HttpNotFound();
            }
            return View(ethenic);
        }

        // POST: Ethenics/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,EthenicGroup")] Ethenic ethenic)
        {
            if (ModelState.IsValid)
            {
                Service.Update(ethenic);
                return RedirectToAction("Index");
            }
            return View(ethenic);
        }

        // GET: Ethenics/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ethenic ethenic = Service.GetById(id.ToString());
            if (ethenic == null)
            {
                return HttpNotFound();
            }
            return View(ethenic);
        }

        // POST: Ethenics/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Ethenic ethenic = Service.GetById(id.ToString());
            Service.Delete(ethenic);
            return RedirectToAction("Index");
        }

      
    }
}
