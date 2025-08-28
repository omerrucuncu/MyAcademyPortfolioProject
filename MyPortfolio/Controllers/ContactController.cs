using MyPortfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyPortfolio.Controllers
{
    public class ContactController : Controller
    {
        MyAcademyPortfolioProjectEntities entities = new MyAcademyPortfolioProjectEntities();
        public ActionResult Index()
        {
            var values = entities.TblContacts.ToList();
            return View(values);
        }

        public ActionResult DeleteContact(int id)
        {
            var value = entities.TblContacts.Find(id);
            entities.TblContacts.Remove(value);
            entities.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateContact(int id)
        {
            var value = entities.TblContacts.Find(id);
            return View(value);
        }

        [HttpPost]
        public ActionResult UpdateContact(TblContacts tblContacts)
        {
            var value = entities.TblContacts.Find(tblContacts.ContactId);
            value.NameSurname = tblContacts.NameSurname;
            value.Address = tblContacts.Address;
            value.Phone = tblContacts.Phone;
            value.Email = tblContacts.Email;
            entities.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]   
        public ActionResult AddContact()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddContact(TblContacts tblContacts)
        {
            entities.TblContacts.Add(tblContacts);
            entities.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}