using MyPortfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyPortfolio.Controllers
{
    public class MessageController : Controller
    {
        MyAcademyPortfolioProjectEntities entities = new MyAcademyPortfolioProjectEntities();
        public ActionResult Index()
        {
            var values = entities.TblMessages.ToList();
            return View(values);
        }
    }
}