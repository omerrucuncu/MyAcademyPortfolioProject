using MyPortfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyPortfolio.Controllers
{
    public class ExperienceController : Controller
    {
        MyAcademyPortfolioProjectEntities db = new MyAcademyPortfolioProjectEntities();
        // GET: Experience
        public ActionResult Index()
        {
            var values = db.TblExperiences.ToList();
            return View(values);
        }

        public ActionResult DeleteExperience(int id)
        {
            var values = db.TblExperiences.Find(id);
            db.TblExperiences.Remove(values);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult AddExperience()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddExperience(TblExperiences p)
        {
            db.TblExperiences.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateExperience(int id)
        {
            var values = db.TblExperiences.Find(id);
            return View(values);
        }

        [HttpPost]
        public ActionResult UpdateExperience(TblExperiences p)
        {
            var values = db.TblExperiences.Find(p.ExperienceId);
            values.StartYear = p.StartYear;
            values.EndYear = p.EndYear;
            values.Title = p.Title;
            values.Description = p.Description;
            values.Company = p.Company;
            values.Location = p.Location;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}