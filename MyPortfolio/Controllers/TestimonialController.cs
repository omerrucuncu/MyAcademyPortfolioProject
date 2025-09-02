using MyPortfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyPortfolio.Controllers
{
    public class TestimonialController : Controller
    {
        MyAcademyPortfolioProjectEntities db = new MyAcademyPortfolioProjectEntities();
        public ActionResult Index()
        {
            var values = db.TblTestimonials.ToList();
            return View(values);
        }

        public ActionResult DeleteTestimonial(int id)
        {
            var values = db.TblTestimonials.Find(id);
            db.TblTestimonials.Remove(values);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult AddTestimonial()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddTestimonial(TblTestimonials p)
        {
            db.TblTestimonials.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateTestimonial(int id)
        {
            var values = db.TblTestimonials.Find(id);
            return View(values);
        }

        [HttpPost]
        public ActionResult UpdateTestimonial(TblTestimonials p)
        {
            var values = db.TblTestimonials.Find(p.TestimonialId);
            values.ImageUrl = p.ImageUrl;
            values.Comment = p.Comment;
            values.NameSurname = p.NameSurname;
            values.Title = p.Title;
            values.Status = p.Status;
            values.CommentDate = p.CommentDate;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult MakeActive(int id)
        {
            var values = db.TblTestimonials.Find(id);
            values.Status = true;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult MakePassive(int id)
        {
            var values = db.TblTestimonials.Find(id);
            values.Status = false;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}