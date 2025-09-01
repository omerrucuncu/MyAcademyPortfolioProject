using MyPortfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyPortfolio.Controllers
{
    public class ServiceController : Controller
    {
        MyAcademyPortfolioProjectEntities db = new MyAcademyPortfolioProjectEntities();
        public ActionResult Index()
        {
            var values = db.TblServices.ToList();
            return View(values);
        }

        public ActionResult DeleteService(int id)
        {
            var values = db.TblServices.Find(id);
            db.TblServices.Remove(values);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult AddService()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddService(TblServices p)
        {
            db.TblServices.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateService(int id)
        {
            var values = db.TblServices.Find(id);
            return View(values);
        }

        [HttpPost]
        public ActionResult UpdateService(TblServices p)
        {
            var values = db.TblServices.Find(p.ServiceId);
            values.Icon = p.Icon;
            values.Title = p.Title;
            values.Description = p.Description;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult MakeActive(int id)
        {
            var values = db.TblServices.Find(id);
            values.Status = true;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult MakePassive(int id)
        {
            var values = db.TblServices.Find(id);
            values.Status = false;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}