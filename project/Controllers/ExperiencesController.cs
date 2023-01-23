using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using project.Models;

namespace project.Controllers
{
    public class ExperiencesController : Controller
    {
        private WazAppEntities2 db = new WazAppEntities2();

        // GET: Experiences
        public ActionResult Index()
        {
            if (Session["userid"] == null)
                return RedirectToAction("MyLogin", "Account");
            int id = (int)Session["userid"];
            Employee emp = db.Employees.Where(s => s.UserID == id).FirstOrDefault<Employee>();
            return View(db.Experiences.Where(e => e.EmployeeID == emp.EmployeeID).ToList());
        }

        // GET: Experiences/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Experience experience = db.Experiences.Find(id);
            if (experience == null)
            {
                return HttpNotFound();
            }
            return View(experience);
        }

        // GET: Experiences/Create
        public ActionResult Create()
        {
            int id = (int)Session["userid"];
            Employee emp = db.Employees.Where(s => s.UserID == id).FirstOrDefault<Employee>();
            ViewBag.EmployeeID = emp.EmployeeID;
            return View();
        }

        // POST: Experiences/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Experience experience)
        {
            if (ModelState.IsValid)
            {
                if (Session["userid"] != null)
                {
                    int id = (int)Session["userid"];
                    Employee emp = db.Employees.Where(s => s.UserID == id).FirstOrDefault<Employee>();
                    experience.EmployeeID = emp.EmployeeID;
                    db.Experiences.Add(experience);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    return RedirectToAction("MyLogin", "Account");
                }
            }

            ViewBag.EmployeeID = new SelectList(db.Employees, "EmployeeID", "Skills", experience.EmployeeID);
            return View(experience);
        }

        // GET: Experiences/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Experience experience = db.Experiences.Find(id);
            if (experience == null)
            {
                return HttpNotFound();
            }
            ViewBag.EmployeeID = new SelectList(db.Employees, "EmployeeID", "Skills", experience.EmployeeID);
            return View(experience);
        }

        // POST: Experiences/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,EmployeeID,CompanyName,PositionCompany,StartingDate,EndingDate,Qualifications")] Experience experience)
        {
            if (ModelState.IsValid)
            {
                db.Entry(experience).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EmployeeID = new SelectList(db.Employees, "EmployeeID", "Skills", experience.EmployeeID);
            return View(experience);
        }

        // GET: Experiences/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Experience experience = db.Experiences.Find(id);
            if (experience == null)
            {
                return HttpNotFound();
            }
            return View(experience);
        }

        // POST: Experiences/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Experience experience = db.Experiences.Find(id);
            db.Experiences.Remove(experience);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
