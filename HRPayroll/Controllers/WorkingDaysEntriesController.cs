using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using HRPayroll.Domain.Entity;
using HRPayroll.Domain.ViewModel;
using HRPayroll.Service;

namespace HRPayroll.Controllers
{
    public class WorkingDaysEntriesController : Controller
    {
        public readonly MonthlySalaryService Service;
        public WorkingDaysEntriesController()
        {
            Service = new MonthlySalaryService();
        }

        // GET: WorkingDaysEntries
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
        public ActionResult Search(int branchId, int year, int month)
        {
            var employeeService = new EmployeeService();
            var employees = employeeService.GetMany(e => e.BranchId == branchId);
            var monthlySalaryDetails = employees.Select(x =>
                new MonthlySalaryDetail
                {
                    EmpId = x.Id,
                    Employee = x
                }
            );
            return PartialView("_List", monthlySalaryDetails);


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

        public ActionResult Create(WorkingDays mast)
        {
            var salarymast = new MonthlySalaryMast();
            var salarydetails = new List<MonthlySalaryDetail>();
            salarymast.Branchid = mast.Branchid;
            salarymast.Month = mast.Month;
            salarymast.Year = mast.Year;
            salarymast.Totaldaysinmonth = mast.Totaldaysinmonth;
            var monthlySalaryDetails = mast.WorkingDaysDetails.Select(x =>
                new MonthlySalaryDetail
                {
                    EmpId = x.EmpId,
                    AttendanceDays = x.AttendanceDays,
                    Holidays = x.Holidays,
                    LeaveDays = x.LeaveDays,
                    AbsentDays = x.AbsentDays,
                    PayDays = x.PayDays,
                    OTHours = x.OTHours
                }
            );
            salarymast.MonthlySalaryDetails = monthlySalaryDetails.ToList();
            Service.Add(salarymast);
            return RedirectToAction("Index");


        }

        // GET: WorkingDaysEntries/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MonthlySalaryMast workingDaysEntry = Service.GetById(id.GetValueOrDefault());
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
        public ActionResult Edit(MonthlySalaryMast workingDaysEntry)
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
            MonthlySalaryMast workingDaysEntry = Service.GetById(id.GetValueOrDefault());
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
            MonthlySalaryMast workingDaysEntry = Service.GetById(id);
            Service.Delete(workingDaysEntry);
            return RedirectToAction("Index");
        }


    }
}
