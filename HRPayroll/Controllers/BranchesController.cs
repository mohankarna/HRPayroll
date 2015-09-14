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
    public class BranchesController : Controller
    {
       public readonly BranchService Service;
        public BranchesController()
        {
            Service = new BranchService();
        }

        // GET: Branches
        public ActionResult Index()
        {
            var branch = Service.GetAll();
            return View(branch);
        }

        // GET: Branches/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }          
            var branch = Service.GetById(id.GetValueOrDefault());
            if (branch == null)
            {
                return HttpNotFound();
            }
            return View(branch);
        }

        // GET: Branches/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Branches/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create( Branch branch)
        {
            if (ModelState.IsValid)
            {
                Service.Add(branch);
                return RedirectToAction("Index");
            }

            return View(branch);
        }

        // GET: Branches/Edit/5
        public ActionResult Edit(long id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            
            Branch branch = Service.GetById(id);
            if (branch == null)
            {
                return HttpNotFound();
            }
            return View(branch);
        }

        // POST: Branches/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit( Branch branch)
        {
            if (ModelState.IsValid)
            {
                Service.Update(branch);
                return RedirectToAction("Index");
            }
            return View(branch);
        }

        // GET: Branches/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Branch branch= Service.GetById(id.GetValueOrDefault());
            if (branch == null)
            {
                return HttpNotFound();
            }
            return View(branch);
        }

        // POST: Branches/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Branch branch = Service.GetById(id);
            Service.Delete(branch);
            return RedirectToAction("Index");
        }

      
    }
}
