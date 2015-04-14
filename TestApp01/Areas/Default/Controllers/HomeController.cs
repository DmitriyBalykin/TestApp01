using Ninject;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestApp01.Controllers;
using TestApp01.Model;

namespace TestApp01.Areas.Default.Controllers
{
    public class HomeController : BaseController
    {
        //
        // GET: /Intro/
        private Logger logger = LogManager.GetCurrentClassLogger();

        public HomeController()
        {
        }
        public ActionResult Index()
        {
            var cookie = new HttpCookie("test_cookie")
            {
                Value = DateTime.Now.ToString("dd.MM.yyy"),
                Expires = DateTime.Now.AddMinutes(10)
            };
            Response.SetCookie(cookie);

            return View(CurrentUser);
        }
        public ActionResult UserLogin()
        {
            return View(CurrentUser);
        }

    }
}
