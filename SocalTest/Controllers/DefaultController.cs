using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using SocialTest.DataModel;
using SocialTest.Models;

namespace SocialTest.Controllers
{
    public class DefaultController : Controller
    {
        
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

        [AllowAnonymous]
        [HttpGet]
        public ActionResult Login()
        {
            var claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.Name, "Test"));
            claims.Add(new Claim(ClaimTypes.Email, "test@test.com"));
            var id = new ClaimsIdentity(claims,
                DefaultAuthenticationTypes.ApplicationCookie);

            Request.GetOwinContext().Authentication.SignIn(id);
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult Login(string test)
        {
            if (!ModelState.IsValid)
                return View();

            using (var db = new SocialContext())
            {

            }
            return View();
        }

        public void Logoff()
        {
            Request.GetOwinContext().Authentication.SignOut();
        }
    }
}