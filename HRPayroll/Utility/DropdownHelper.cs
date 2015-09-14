using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;
using HRPayroll.Domain.Entity;
using HRPayroll.Service;

namespace HRPayroll.Utility
{
    public class DropdownHelper
    {

        public static IEnumerable<SelectListItem> FillddlDepartment()
        {
            var service = new DepartmentService();
            var department = service.GetAll();
            var listitems = department.Select(x =>

                new SelectListItem
                {
                    Text = x.DepartmentName,
                    Value = x.Id.ToString()
                });
            return listitems;
        }

        public static IEnumerable<SelectListItem> FillddlDesignation()
        {
            var service = new DesignationService();
            var designation = service.GetAll();
            var listitems = designation.Select(x =>

                new SelectListItem
                {
                    Text = x.DesignationName,
                    Value = x.Id.ToString()
                });
            return listitems;
        }

        public static IEnumerable<SelectListItem> FillddlBranch()
        {
            var service = new BranchService();
            var branch = service.GetAll();
            var listitems = branch.Select(x =>

                new SelectListItem
                {
                    Text = x.BranchName,
                    Value = x.Id.ToString()
                });
            return listitems;
        }

        public static IEnumerable<SelectListItem> FillddlTitle()
        {
            var service = new TitleService();
            var titles = service.GetAll();
            var listitems = titles.Select(x =>

                new SelectListItem
                {
                    Text = x.TitleName,
                    Value = x.Id.ToString()
                });
            return listitems;
        }

        public static IEnumerable<SelectListItem> FillddlGender()
        {
            var service = new GenderService();
            var genders = service.GetAll();
            var listitems = genders.Select(x =>

                new SelectListItem
                {
                    Text = x.GenderName,
                    Value = x.Id.ToString()
                });
            return listitems;
        }

        public static IEnumerable<SelectListItem> FillddlMaritalStatus()
        {
            var service = new MaritalStatusService();
            var maritalStatus = service.GetAll();
            var listitems = maritalStatus.Select(x =>

                new SelectListItem
                {
                    Text = x.Name,
                    Value = x.Id.ToString()
                });
            return listitems;
        }


        public static IEnumerable<SelectListItem> FillddlEmployee()
        {
            var service = new EmployeeService();
            var employees = service.GetAll();
            var listitems = employees.Select(x =>

                new SelectListItem
                {
                    Text = x.EmployeeName,
                    Value = x.Id.ToString()
                });
            return listitems;
        }

        public static IEnumerable<SelectListItem> FillddlLeaveType()
        {
            var service = new LeaveSetupService();
            var leaveTypes = service.GetAll();
            var listitems = leaveTypes.Select(x =>

                new SelectListItem
                {
                    Text = x.LeaveName,
                    Value = x.Id.ToString()
                });
            return listitems;
        }

        public static IEnumerable<SelectListItem> FillddlServiceType()
        {
            var service = new ServiceTypeService();
            var leaveTypes = service.GetAll();
            var listitems = leaveTypes.Select(x =>

                new SelectListItem
                {
                    Text = x.ServiceName,
                    Value = x.Id.ToString()
                });
            return listitems;
        }
        public static IEnumerable<SelectListItem> FillddlEthenicGroup()
        {
            var service = new EthenicService();
            var ethenics = service.GetAll();
            var listitems = ethenics.Select(x =>

                new SelectListItem
                {
                    Text = x.EthenicGroup,
                    Value = x.Id.ToString()
                });
            return listitems;
           

        }
        public static IEnumerable<SelectListItem> FillddlReligion()
        {
            var service = new ReligionService();
            var religions = service.GetAll();
            var listitems = religions.Select(x =>

                new SelectListItem
                {
                    Text = x.ReligionName,
                    Value = x.Id.ToString()
                });
            return listitems;


        }
       // public static IEnumerable<SelectListItem> FilldllPayPlanSetup()
       // {
       //     var service = new PayPlanSetup();
       //     var PayPlanSetups = service.GetAll();
       //     var listitems = PayPlanSetups.Select(x =>
        public static IEnumerable<SelectListItem> FillddlRoles()
        {
            var service = new RolesService();
            var ethenics = service.GetAll();
            var listitems = ethenics.Select(x =>


                


       //         new SelectListItem
       //         {
       //             Text = x.PayPlanSetupName,
       //             Value = x.Id.ToString()
       //         });
       //     return listitems;
       // }
      
                new SelectListItem
                {
                    Text = x.RoleName,
                    Value = x.Id.ToString()
                });
            return listitems;

        }



        public static IEnumerable<SelectListItem> FillddlYear()
        {
            var lstYears = new List<SelectListItem>();
            for (int i = 2013; i <= 2020; i++)
            {
                lstYears.Add(

               new SelectListItem
               {
                   Text = i.ToString(),
                   Value = i.ToString()
               });
            }
            var firstOrDefault = lstYears.FirstOrDefault(x => x.Value == System.DateTime.Now.Year.ToString());
            if (firstOrDefault != null)
                firstOrDefault.Selected = true;
            return lstYears;
        }

        public static IEnumerable<SelectListItem> FillddlMonth()
        {
            var lstMonths = new List<SelectListItem>();
            for (int i = 1; i <= 12; i++)
            {
                lstMonths.Add(

               new SelectListItem
               {
                   Text = i.ToString(),
                   Value = i.ToString()
               });
            } 
            var firstOrDefault = lstMonths.FirstOrDefault(x => x.Value == System.DateTime.Now.Month.ToString());
            if (firstOrDefault != null)
                firstOrDefault.Selected = true;
            return lstMonths;
        }
    }
}