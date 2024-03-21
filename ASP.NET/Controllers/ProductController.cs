using ASP.NET.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DbContext.Models;
using DbContext.Models.DbContext.Models;

namespace DbContext.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index(string searchString)
        {
            using (var context = new ApplicationDbContext())
            {
                var products = from p in context.Products
                               select p;

                if (!String.IsNullOrEmpty(searchString))
                {
                    products = products.Where(p => p.Name.Contains(searchString));
                }

                return View(products.ToList());
            }
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
                using (ApplicationDbContext context = new ApplicationDbContext())
                {
                    context.Products.Add(product);
                    context.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            return View(product);
        }

        public ActionResult Edit(int id)
        {
            using (ApplicationDbContext context = new ApplicationDbContext())
            {
                var product = context.Products.Find(id);
                return View(product);
            }
        }

        [HttpPost]
        public ActionResult Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                using (var context = new ApplicationDbContext())
                {
                    context.Entry(product).State = System.Data.Entity.EntityState.Modified;
                    context.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            return View(product);
        }

        public ActionResult Delete(int id)
        {
            using (var context = new ApplicationDbContext())
            {
                var product = context.Products.Find(id);
                return View(product);
            }
        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            using (var context = new ApplicationDbContext())
            {
                var product = context.Products.Find(id);
                context.Products.Remove(product);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
        }
    }
}