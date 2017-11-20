using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using sells.model1;
using System.Data.Entity;

namespace sells.Controllers
{
    public class HomeController : Controller
    {
        websellEntities1 db = new websellEntities1();
        public ActionResult Index()
        {
            ViewBag.Product = db.Products.ToList();
            return View();
        }

        public ActionResult Insert()
        {
            ViewBag.category = db.Category.ToList();
            ViewBag.type = db.ProductType.ToList();

            return View();
        }
        public ActionResult Delete(int id)
        {
            Products pro = db.Products.Find(id);
            if (pro == null)
            {
                return RedirectToAction("index");
            }
            db.Products.Remove(pro);
            db.SaveChanges();
            return RedirectToAction("index");
        }
        public ActionResult Edit(int id)
        {
            Products pro = db.Products.Find(id);
            if (pro == null)
            {
                return RedirectToAction("index");
            }
            ViewBag.product = pro;

            ViewBag.category = db.Category.ToList();
            ViewBag.type = db.ProductType.ToList();

            return View();
        }
        [HttpPost]
        public ActionResult add(Products pro)
        {
            
            db.Products.Add(pro);
            db.SaveChanges();

            return RedirectToAction("index");
        }
        [HttpPost]
        public ActionResult Update(Products pro)
        {
            db.Entry(pro).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("index");
        }
    }
}