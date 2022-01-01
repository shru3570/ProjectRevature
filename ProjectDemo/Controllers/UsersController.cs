using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProjectDemo.Fiter;
using ProjectDemo.Models;
using ProjectDemo.Repository;

namespace ProjectDemo.Controllers
{
    
    public class UsersController : Controller
    {
        UserRepository us = new UserRepository();
        private UserDb db = new UserDb();

        // GET: Users
        [UserAuthentication]
        public ActionResult Index()
        {
            ViewBag.role = Session["RoleName"];


            return View(db.Users.ToList());
        }

        // GET: Users/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // GET: Users/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Users/Create
       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UserId,FirstName,LastName,EmailId,UserName,Password,ConfirmPassword")] User user)
        {
            if (ModelState.IsValid)
            {
                user.UserCreated = DateTime.Now;
                //user.RoleId = 2;
                us.AddUser(user);
              
                return RedirectToAction("Index");

            }
          

            return View(user);
        }

        // GET: Users/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UserId,FirstName,LastName,EmailId,UserName,Password,ConfirmPassword")] User user)
        {
            if (ModelState.IsValid)
            {
                db.Entry(user).State = EntityState.Modified;
                user.UserCreated = DateTime.Now;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(user);
        }

        // GET: Users/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            User user = db.Users.Find(id);
            db.Users.Remove(user);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

       
        //Login Method
        
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(User users)
        {
            using (UserDb db = new UserDb())
            {
                var usr = db.Users.FirstOrDefault(u => u.UserName == users.UserName && u.Password == users.Password);
               //string RoleName = usr.RoleId!=null? db.roles.Where(u => u.Id == usr.RoleId).SingleOrDefault().Name:string.Empty;


                if (usr != null)
                {
                    Session["UserId"] = usr.UserId.ToString();
                    Session["UserName"] = usr.UserName.ToString();
                   // Session["RoleName"] = RoleName;
                    return RedirectToAction("MultipleDelete","Products");
                }


                else
                {
                    ModelState.AddModelError("", "Username and password is wrong");
                }


            }
            return View();
        }
        //public ActionResult LoggedIn()
        //{
        //    if (Session["UserName"] != null)
        //    {
        //        return View("shruti");
        //    }
           
        [HttpPost]
        public ActionResult Logout()
        {
            //FormsAuthentication.SignOut();
            //return RedirectToAction("Login");

            Session["UserName"] = string.Empty;
            Session["Password"] = string.Empty;
            return RedirectToAction("Login", "Users");
        }




    }
}
