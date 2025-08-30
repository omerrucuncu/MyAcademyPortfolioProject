using MyPortfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyPortfolio.Controllers
{
    public class ProjectController : Controller
    {
        MyAcademyPortfolioProjectEntities db = new MyAcademyPortfolioProjectEntities();
        public ActionResult Index()
        {
            var values = db.TblProjects.ToList();
            return View(values);
        }

        public ActionResult DeleteProject(int id)
        {
            var value = db.TblProjects.Find(id);
            db.TblProjects.Remove(value);
            db.SaveChanges();
            return RedirectToAction("Index");

        }

        [HttpGet]
        public ActionResult AddProject()
        {
            //using (var db = new MyAcademyPortfolioProjectEntities())
            //{
            //    var categories = db.TblCategories
            //        .Select(c => new SelectListItem
            //        {
            //            Value = c.CategoryId.ToString(),
            //            Text = c.CategoryName.ToString(),
            //        }).ToList();

            //    ViewBag.CategoryList = categories;
            //}

            var categories = db.TblCategories.ToList();

            List<SelectListItem> categoryList = (from x in categories select new SelectListItem
            {
                Text = x.CategoryName,
                Value = x.CategoryId.ToString()
            }).ToList();

            ViewBag.category = categoryList;
            return View();
        }

        [HttpPost]
        public ActionResult AddProject(TblProjects projects)
        {
            db.TblProjects.Add(projects);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateProject(int id)
        {
            var value = db.TblProjects.Find(id);
            var categories = db.TblCategories.ToList();
            List<SelectListItem> categoryList = (from x in categories
                                                 select new SelectListItem
                                                 {
                                                     Text = x.CategoryName,
                                                     Value = x.CategoryId.ToString()
                                                 }).ToList();
            ViewBag.category = categoryList;
            return View(value);
        }
        [HttpPost]
        public ActionResult UpdateProject(TblProjects projects)
        {
            var value = db.TblProjects.Find(projects.ProjectId);
            value.ImageUrl = projects.ImageUrl;
            value.ProjectName = projects.ProjectName;
            value.CategoryId = projects.CategoryId;
            value.GitHubUrl = projects.GitHubUrl;
            db.SaveChanges();
            return RedirectToAction("Index");

        }

    } 
}