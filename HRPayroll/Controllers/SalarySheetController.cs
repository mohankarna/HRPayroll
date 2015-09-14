using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HRPayroll.Service;

namespace HRPayroll.Controllers
{
    public class SalarySheetController : Controller
    {
        // GET: SalarySheet
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult IndexSearch(int branchId, int year, int month)
        {
            var servicedetail = new MonthlySalaryDetailService();

            var monthlySalaryDetails = servicedetail.GetManyWithInclude(e => e.MonthlySalaryMast.Branchid == branchId && e.MonthlySalaryMast.Year == year && e.MonthlySalaryMast.Month == month, "Employee");

            return PartialView("_IndexList", monthlySalaryDetails);
        }
        // GET: SalarySheet/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: SalarySheet/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SalarySheet/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: SalarySheet/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: SalarySheet/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: SalarySheet/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: SalarySheet/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
