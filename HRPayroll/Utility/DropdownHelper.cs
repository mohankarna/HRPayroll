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
       
      
    }
}