using project.Models;
using project.Models.MyViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace project.Controllers
{
    public class DashboardController : Controller
    {

        private readonly WazAppEntities2 _context;

        public DashboardController()
        {
            _context = new WazAppEntities2();
        }

        // GET: Dashboard
        public ActionResult EmployeeProfile()
        {
            if(Session["userid"] == null)
                return RedirectToAction("MyLogin", "Account");

            int id = (int)Session["userid"];
            SystemEmployeeViewMobel systemEmployeeViewMobel = new SystemEmployeeViewMobel();
            systemEmployeeViewMobel.systemUser = _context.SystemUsers.Where(s => s.ID == id).FirstOrDefault<SystemUser>();
            systemEmployeeViewMobel.employee = _context.Employees.Where(s => s.UserID == id).FirstOrDefault<Employee>();
            return View(systemEmployeeViewMobel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EmployeeProfile(SystemEmployeeViewMobel systemEmployeeViewMobel)
        {
            if (Session["userid"] == null)
                return RedirectToAction("MyLogin", "Account");

            try
            {
                    int id = (int)Session["userid"];
                    var systemUser = _context.SystemUsers.Where(s => s.ID == id).FirstOrDefault<SystemUser>();
                    var employee = _context.Employees.Where(s => s.UserID == id).FirstOrDefault<Employee>();

                    employee.Skills = systemEmployeeViewMobel.employee.Skills;
                    employee.ImagePath = systemEmployeeViewMobel.employee.ImagePath;
                    employee.CvPath = systemEmployeeViewMobel.employee.CvPath;
                    employee.Description = systemEmployeeViewMobel.employee.Description;
                    employee.DOB = systemEmployeeViewMobel.employee.DOB;

                    systemUser.FirstName = systemEmployeeViewMobel.systemUser.FirstName;
                    systemUser.LastName = systemEmployeeViewMobel.systemUser.LastName;
                    systemUser.MobileNb = systemEmployeeViewMobel.systemUser.MobileNb;
                    systemUser.Address = systemEmployeeViewMobel.systemUser.Address;
                    _context.SaveChanges();

                    return View(systemEmployeeViewMobel);
            }
            catch (Exception ex)
            {

                throw ex;
            }


        }

        // GET: Dashboard
        public ActionResult EmployerProfile()
        {
            if (Session["userid"] == null)
                return RedirectToAction("MyLogin", "Account");

            int id = (int)Session["userid"];
            SystemEmployerViewModel systemEmployerViewModel = new SystemEmployerViewModel();
            systemEmployerViewModel.systemUser = _context.SystemUsers.Where(s => s.ID == id).FirstOrDefault<SystemUser>();
            systemEmployerViewModel.employer = _context.Employers.Where(s => s.UserID == id).FirstOrDefault<Employer>();
            return View(systemEmployerViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EmployerProfile(SystemEmployerViewModel systemEmployerViewModel)
        {
            if (Session["userid"] == null)
                return RedirectToAction("MyLogin", "Account");

            try
            {
                int id = (int)Session["userid"];
                var systemUser = _context.SystemUsers.Where(s => s.ID == id).FirstOrDefault<SystemUser>();
                var employer = _context.Employers.Where(s => s.UserID == id).FirstOrDefault<Employer>();

                employer.Position = systemEmployerViewModel.employer.Position;
                employer.Website = systemEmployerViewModel.employer.Website;
                employer.CompanyName = systemEmployerViewModel.employer.CompanyName;
                employer.CompanyAddress = systemEmployerViewModel.employer.CompanyAddress;
                employer.City = systemEmployerViewModel.employer.City;
                employer.Country = systemEmployerViewModel.employer.Country;

                systemUser.FirstName = systemEmployerViewModel.systemUser.FirstName;
                systemUser.LastName = systemEmployerViewModel.systemUser.LastName;
                systemUser.MobileNb = systemEmployerViewModel.systemUser.MobileNb;
                systemUser.Address = systemEmployerViewModel.systemUser.Address;
                _context.SaveChanges();

                return View(systemEmployerViewModel);
            }
            catch (Exception ex)
            {

                throw ex;
            }
            

        }
    }
}