using MyPortfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyPortfolio.Controllers
{
    public class TeamController : Controller
    {
        MyAcademyPortfolioProjectEntities db = new MyAcademyPortfolioProjectEntities();
        public ActionResult Index()
        {
            var values = db.TblTeams.ToList();
            return View(values);
        }

        public ActionResult DeleteTeam(int id)
        {
            var values = db.TblTeams.Find(id);
            db.TblTeams.Remove(values);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult AddTeam()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddTeam(TblTeams p)
        {
            db.TblTeams.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateTeam(int id)
        {
            var values = db.TblTeams.Find(id);
            return View(values);
        }

        [HttpPost]
        public ActionResult UpdateTeam(TblTeams p)
        {
            var values = db.TblTeams.Find(p.TeamId);
            values.ImageUrl = p.ImageUrl;
            values.NameSurname = p.NameSurname;
            values.Title = p.Title;
            values.Description = p.Description;
            values.TwitterUrl = p.TwitterUrl;
            values.FacebookUrl = p.FacebookUrl;
            values.LinkedInUrl = p.LinkedInUrl;
            values.InstagramUrl = p.InstagramUrl;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult MakeActive(int id)
        {
            var values = db.TblTeams.Find(id);
            values.Status = true;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult MakePassive(int id)
        {
            var values = db.TblTeams.Find(id);
            values.Status = false;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}