using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
//using System.Web.Mvc;

namespace ProjectDemo.Fiter
{
    public class UserAuthorization : IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationContext filterContext)
        {
            if (string.IsNullOrEmpty(Convert.ToString(filterContext.HttpContext.Session["RoleName"])))
            {
             string RoleName    = Convert.ToString( filterContext.HttpContext.Session["RoleName"]);
                

                filterContext.Result = new HttpUnauthorizedResult();
            }
        }
    }
}
