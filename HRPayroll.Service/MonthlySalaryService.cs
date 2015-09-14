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
                detail.BasicSalary = (payplan.BasicSalary * (double)detail.PayDays) / entity.Totaldaysinmonth;
                detail.PreviousGrade = (payplan.PreviousGrade * (double)detail.PayDays) / entity.Totaldaysinmonth;
                detail.CurrentGrade = (payplan.CurrentGrade * (double)detail.PayDays) / entity.Totaldaysinmonth;
                detail.DearnessAllowance = (payplan.DearnessAllowance * (double)detail.PayDays) / entity.Totaldaysinmonth;
                detail.HouseRent = (payplan.HouseRent * (double)detail.PayDays) / entity.Totaldaysinmonth;
                detail.SpecialAllowance = (payplan.SpecialAllowance * (double)detail.PayDays) / entity.Totaldaysinmonth;
                detail.MedicalAllowance = (payplan.MedicalAllowance * (double)detail.PayDays) / entity.Totaldaysinmonth;
                detail.OtherAllowance = (payplan.OtherAllowance * (double)detail.PayDays) / entity.Totaldaysinmonth;
                detail.TiffinAllowance = (payplan.TiffinAllowance * (double)detail.PayDays) / entity.Totaldaysinmonth;
                detail.CommunicationAllowance = (payplan.CommunicationAllowance * (double)detail.PayDays) / entity.Totaldaysinmonth;
                detail.CIT = (payplan.CIT * (double)detail.PayDays) / entity.Totaldaysinmonth;
                detail.Insurance = (payplan.Insurance * (double)detail.PayDays) / entity.Totaldaysinmonth;
                detail.OTAmount = (payplan.BasicSalary + payplan.PreviousGrade + payplan.CurrentGrade)
                    * 12 * OtRate / (365 * 8);
                detail.Total = (detail.BasicSalary + detail.PreviousGrade + detail.CurrentGrade + detail.DearnessAllowance + detail.HouseRent + detail.SpecialAllowance + detail.MedicalAllowance + detail.OtherAllowance + detail.TiffinAllowance + detail.OTAmount
    + detail.CommunicationAllowance);
                detail.PF = (detail.BasicSalary + detail.PreviousGrade + detail.CurrentGrade) * (payplan.PF / 100);
                detail.Advance = 0;
                detail.OtherAdvance = 0;
                detail.IncomeTax = 0;
                detail.SSTax = 0;
                detail.NetTotal = detail.Total - detail.PF - detail.Insurance - detail.CIT - detail.Advance - detail.OtherAdvance - detail.IncomeTax - detail.SSTax;

                monthlysalarydetails.Add(detail);
            }
            return entity;
        }

        
    }
}
