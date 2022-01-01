using ProjectDemo.Models;
using ProjectDemo.UIMOdel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;


namespace ProjectDemo.Controllers
{
    public class OrderController : Controller
    {
        private UserDb db = new UserDb();

        // GET: Order
        public ActionResult AddtoCart(int id)
        {
            //if (id == null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}
            Product product = db.Products.Find(id);
            Cart cart = new Cart();

            cart.UserId = Convert.ToInt32(Session["UserId"]);
            cart.ProductName = product.ProductName;
            cart.ProductAmount = product.ProductAmount;
            cart.ProductQuantity = product.ProductQuantity;
            if(ModelState.IsValid)
            {
                db.Cart.Add(cart);
                db.SaveChanges();
                return RedirectToAction("MultipleDelete","Products");

            }
            return View(product);
        }

       
    }
}