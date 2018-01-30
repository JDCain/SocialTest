using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
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
            var identity = (ClaimsIdentity)User.Identity;
            var id = identity.Claims.FirstOrDefault(x=>x.Value == "Id");
            var result = int.TryParse(id?.ValueType, out var intOut);
            if (result)
            {
                using (var db = new SocialContext())
                {
                    var query = db.Friends.Where(x => x.UserId0 == intOut);
                    var innerJoinQuery =
                        from post in db.Posts
                        join friend in db.Friends on post.UserId equals friend.UserId0
                        select new { post.Text, User = db.Users.FirstOrDefault(x=>x.Id == post.UserId).Name }; //produces flat sequence
                    var test = innerJoinQuery.ToList();
                }
            }
            ViewBag.Title = "Default";
            return View();
        }

        [AllowAnonymous]
        [HttpGet]
        public ActionResult Login(string redirect)
        {
            return View();
        }

        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        [HttpPost]
        public async Task<ActionResult> Login(LoginInfo modeLogin)
        {
            if (!ModelState.IsValid)
                return View();

            using (var db = new SocialContext())
            {
                var test = await db.Users.FirstOrDefaultAsync(x => x.Name == modeLogin.User);
                if (test != null)
                {
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, test.Name),
                        new Claim(ClaimTypes.Email, test.Email),
                        new Claim("Id", "Id", test.Id.ToString())
                        
                    };
                    var id = new ClaimsIdentity(claims,
                        DefaultAuthenticationTypes.ApplicationCookie);
                    
                    Request.GetOwinContext().Authentication.SignIn(id);
                    RedirectToAction("Default", "index");
                }
            }

            return View();
        }

        [AllowAnonymous]
        public ActionResult Logoff()
        {
            Request.GetOwinContext().Authentication.SignOut();
            return RedirectToAction("Index", "Default");
        }
    }
}