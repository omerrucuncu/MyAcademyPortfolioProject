using MyPortfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyPortfolio.Controllers
{
    public class CategoryController : Controller
    {
        MyAcademyPortfolioProjectEntities entities = new MyAcademyPortfolioProjectEntities();
        public ActionResult Index()
        {
            var values = entities.TblCategories.ToList();   
            return View(values);
        }

        [HttpGet]
        public ActionResult AddCategory()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddCategory(TblCategories categories)
        {
            entities.TblCategories.Add(categories);
            entities.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DeleteCategory(int id)
        {
            var category = entities.TblCategories.Find(id);
            entities.TblCategories.Remove(category);
            entities.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateCategory(int id)
        {
            var category = entities.TblCategories.Find(id);
            return View(category);
        }

        [HttpPost]
        public ActionResult UpdateCategory(TblCategories categories) {
            var value = entities.TblCategories.Find(categories.CategoryId);
            value.CategoryName = categories.CategoryName;
            entities.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}