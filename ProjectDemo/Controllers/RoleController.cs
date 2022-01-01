using ProjectDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectDemo.Controllers
{
    public class RoleController : Controller
    {
        // GET: Role
        public ActionResult AddRole()
        {
            UserDb db = new  UserDb();
            ViewBag.roles = new SelectList(db.roles, "Id", "Name");
            return View();
           
           

        }
        //public ActionResult SelectUser()
        //{
        //    UserDb db = new UserDb();
        //    ViewBag.Userselect = new SelectList(db.Users, "UserId", "UserName");
        //    return View();
        //}
    }
}