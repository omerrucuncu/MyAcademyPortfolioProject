using Microsoft.Ajax.Utilities;
using MyPortfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyPortfolio.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default
        MyAcademyPortfolioProjectEntities db = new MyAcademyPortfolioProjectEntities();
        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult DefaultFeaturePartial()
        {
            var values = db.TblFeatures.ToList();
            return PartialView(values); 
        }

        public PartialViewResult DefaultAboutPartial()
        {
            var values = db.TblAbouts.ToList();
            return PartialView(values);
        }

        // FIX: Remove 'partial' keyword from method declaration
        public PartialViewResult DefaultServicePartial()
        {
            var values = db.TblServices.Where(x => x.Status == true).ToList();
            return PartialView(values);
        }

        public PartialViewResult DefaultExperiencePartial()
        {
            var values = db.TblExperiences.ToList();
            return PartialView(values);
        }

        public PartialViewResult DefaultProjectPartial()
        {
            var categories = db.TblCategories.ToList();
            ViewBag.category = categories;

            var values = db.TblProjects.ToList();

            //var values = db.TblProjects.Where(x => x.CategoryId == x.TblCategories.CategoryId).ToList();


            return PartialView(values);
        }

        public PartialViewResult DefaultTestimonialPartial()
        {
            var values = db.TblTestimonials.ToList();
            return PartialView(values);
        }

        public PartialViewResult DefaultTeamPartial()
        {
            var values = db.TblTeams.ToList();
            return PartialView(values);
        }

        [HttpGet]
        public PartialViewResult SendMessage()
        {
            return PartialView();
        }

        [HttpPost]
        public ActionResult SendMessage(TblMessages p)
        {

            db.TblMessages.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public PartialViewResult DefaultSkillPartial()
        {
            var values = db.TblSkills.ToList();
            return PartialView(values);
        }
    }


}