using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;
using SocialTest.DataModel;
using SocialTest.Models;

namespace SocialTest.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default
        public ActionResult Index()
        {
            using (var db = new SocialContext())
            {
                //var user = new User { Name = "Name" };
                //db.Users.Add(user);
                //db.SaveChanges();
                var query = from b in db.Users
                    orderby b.Name
                    select b;
                foreach (var item in query)
                {
                    
                }
                
            }
            ViewBag.Title = "Default";
            return View();
        }

        public ActionResult Login()
        {
            if (!ModelState.IsValid)
                return View();

            using (var db = new SocialContext())
            {

            }
            return View();
        }
    }
}