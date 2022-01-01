using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Data.OleDb;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LinqToExcel;
using ProjectDemo.Fiter;
using ProjectDemo.Models;


namespace ProjectDemo.Controllers
{
    [UserAuthentication]
    public class ProductsController : Controller
    {
        private UserDb db = new UserDb();

        // GET: Products
        public ActionResult Index()
        {
            return View(db.Products.ToList());
        }







    

        // GET: Products/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // GET: Products/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Products/Create
       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProductId,ProductName,ProductAmount,ProductQuantity")] Product product)
        {
            if (ModelState.IsValid)
            {
                db.Products.Add(product);
                db.SaveChanges();
                return RedirectToAction("MultipleDelete");
            }

            return View(product);
        }

        // GET: Products/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProductId,ProductName,ProductAmount,ProductQuantity")] Product product)
        {
            if (ModelState.IsValid)
            {
                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("MultipleDelete");
            }
            return View(product);
        }

        // GET: Products/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Product product = db.Products.Find(id);
            db.Products.Remove(product);
            db.SaveChanges();
            return RedirectToAction("MultipleDelete");
        }
        public ActionResult Logout()
        {
            //FormsAuthentication.SignOut();
            //return RedirectToAction("Login");

            Session["UserName"] = string.Empty;
            Session["Password"] = string.Empty;
            return RedirectToAction("Login", "Users");
        }

        public ActionResult MultipleDelete()
        {
            ViewBag.ListProduct = this.db.Products.ToList();
            return View();
        }

        [HttpPost]
        public ActionResult MultipleDelete(FormCollection formCollection)
        {
            string[] ids = formCollection["ID"].Split(new char[] { ',' });
            foreach (string id in ids)
            {
                var product = this.db.Products.Find(int.Parse(id));
                this.db.Products.Remove(product);
                this.db.SaveChanges();
            }
            return RedirectToAction("MultipleDelete");
        }

    }
}
