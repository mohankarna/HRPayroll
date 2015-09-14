using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRPayroll.Data;
using HRPayroll.Data.Infrastructure;
using HRPayroll.Domain.Entity;
using HRPayroll.Service.Infrastructure;

namespace HRPayroll.Service
{
    public class MonthlySalaryService : ServiceBase<MonthlySalaryMast>
    {
        public MonthlySalaryService()
            : base(new MonthlySalaryMastRepository())
        {
        }
        public override MonthlySalaryMast Add(MonthlySalaryMast entity)
        {
            var entity2 = entity;
            var entity1 = base.GetMany(e => e.Year == entity2.Year && e.Month == entity2.Month && e.Branchid == entity2.Branchid);
            if (entity1.Any())
            {
                throw new Exception("Working Days Already Entered For this month and branch");
            }
            entity = CalculateSalary(entity);
            return base.Add(entity);
        }
        private MonthlySalaryMast CalculateSalary(MonthlySalaryMast entity)
        {
            var obj = new PayPlanSetupService();
            var monthlysalarydetails = new List<MonthlySalaryDetail>();
            double OtRate = 1.5;
            double workinghours = 8;
            entity.Createddate = System.DateTime.Now;
            entity.ApprovedBy = 1;
            entity.ApprovedDate = System.DateTime.Now;
            entity.SendForApproval = true;
            entity.Fromdate = System.DateTime.Now;
            foreach (var detail in entity.MonthlySalaryDetails)
            {
                var detail1 = detail;
                var payplan = obj.Get(o => o.EmployeeId == detail1.EmpId);
                if (payplan == null)
                {
                    throw new Exception("PayPlan Not Set For Employee Id: " + detail.EmpId.ToString());
                }
                detail.BasicSalary = Math.Round(payplan.BasicSalary * (double)detail.PayDays / entity.Totaldaysinmonth, 2);
                detail.PreviousGrade = Math.Round((payplan.PreviousGrade * (double)detail.PayDays) / entity.Totaldaysinmonth, 2);
                detail.CurrentGrade = Math.Round((payplan.CurrentGrade * (double)detail.PayDays) / entity.Totaldaysinmonth, 2);
                detail.DearnessAllowance = Math.Round((payplan.DearnessAllowance * (double)detail.PayDays) / entity.Totaldaysinmonth, 2);
                detail.HouseRent = Math.Round((payplan.HouseRent * (double)detail.PayDays) / entity.Totaldaysinmonth, 2);
                detail.SpecialAllowance = Math.Round((payplan.SpecialAllowance * (double)detail.PayDays) / entity.Totaldaysinmonth, 2);
                detail.MedicalAllowance = Math.Round((payplan.MedicalAllowance * (double)detail.PayDays) / entity.Totaldaysinmonth, 2);
                detail.OtherAllowance = Math.Round((payplan.OtherAllowance * (double)detail.PayDays) / entity.Totaldaysinmonth, 2);
                detail.TiffinAllowance = Math.Round((payplan.TiffinAllowance * (double)detail.PayDays) / entity.Totaldaysinmonth, 2);
                detail.CommunicationAllowance = Math.Round((payplan.CommunicationAllowance * (double)detail.PayDays) / entity.Totaldaysinmonth, 2);
                detail.CIT = Math.Round((payplan.CIT * (double)detail.PayDays) / entity.Totaldaysinmonth, 2);
                detail.Insurance = Math.Round((payplan.Insurance * (double)detail.PayDays) / entity.Totaldaysinmonth, 2);
                detail.OTAmount = Math.Round((payplan.BasicSalary + payplan.PreviousGrade + payplan.CurrentGrade)
                    * 12 * OtRate / (365 * workinghours), 2);
                detail.Total = Math.Round((detail.BasicSalary + detail.PreviousGrade + detail.CurrentGrade + detail.DearnessAllowance + detail.HouseRent + detail.SpecialAllowance + detail.MedicalAllowance + detail.OtherAllowance + detail.TiffinAllowance + detail.OTAmount
    + detail.CommunicationAllowance), 2);
                detail.PF = Math.Round((detail.BasicSalary + detail.PreviousGrade + detail.CurrentGrade) * (payplan.PF / 100), 2);
                detail.Advance = 0;
                detail.OtherAdvance = 0;
                detail.IncomeTax = 0;
                detail.SSTax = 0;
                detail.NetTotal = Math.Round(detail.Total - detail.PF - detail.Insurance - detail.CIT - detail.Advance - detail.OtherAdvance
                    - detail.IncomeTax - detail.SSTax, 2);

                monthlysalarydetails.Add(detail);
            }
            return entity;
        }


    }
}
