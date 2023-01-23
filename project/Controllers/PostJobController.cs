using project.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace project.Controllers
{
    public class PostJobController : Controller
    {
        private readonly WazAppEntities2 _context;

        public PostJobController()
        {
            _context = new WazAppEntities2();
        }

        public ActionResult PostsView()
        {
            if (Session["userid"] == null)
                return RedirectToAction("MyLogin", "Account");

            int id = (int)Session["userid"];
            Employer empr = _context.Employers.Where(s => s.UserID == id).FirstOrDefault<Employer>();

            return View(_context.JobPosts.Where(s=>s.EmployerID == empr.EmployerID).ToList());
        }
        
        // GET: PostJob
        public ActionResult CreatePost()
        {
            if (Session["userid"] == null)
                return RedirectToAction("MyLogin", "Account");

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreatePost(JobPost jobPost)
        {
            if (ModelState.IsValid)
            {
                if (Session["userid"] == null)
                    return RedirectToAction("MyLogin", "Account");

                int id = (int)Session["userid"];
                Employer empr = _context.Employers.Where(s => s.UserID == id).FirstOrDefault<Employer>();               
                jobPost.EmployerID = empr.EmployerID;
                jobPost.SystemDate = DateTime.Now;
                _context.JobPosts.Add(jobPost);
                _context.SaveChanges();
                return RedirectToAction("PostsView", "PostJobController");
            }
            return View();
        }
    }
}