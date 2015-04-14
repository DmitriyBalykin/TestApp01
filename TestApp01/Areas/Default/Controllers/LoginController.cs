using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestApp01.Controllers;
using TestApp01.Models.ViewModels;

namespace TestApp01.Areas.Default.Controllers
{
    public class LoginController : BaseController
    {
        //
        // GET: /Default/Login/
        [HttpGet]
        public ActionResult Index()
        {
            return View(new LoginView());
        }
        [HttpPost]
        public ActionResult Index(LoginView loginView)
        {
            if (ModelState.IsValid)
            {
                var user = Auth.Login(loginView.Email, loginView.Password, loginView.IsPersistent);
                if (user != null)
                {
                    return RedirectToAction("Index", "Home");
                }
                ModelState["Password"].Errors.Add("Неправильный пароль");
            }
            return View(loginView);
        }
        public ActionResult Logout()
        {
            Auth.Logout();
            return RedirectToAction("Index","Home");
        }

        [HttpGet]
        public ActionResult Ajax()
        {
            return View(new LoginView());
        }
        [HttpPost]
        public ActionResult Ajax(LoginView loginView)
        {
            if (ModelState.IsValid)
            {
                var user = Auth.Login(loginView.Email, loginView.Password, loginView.IsPersistent);
                if(user != null)
                {
                    return View("_Ok");
                }
                ModelState["Password"].Errors.Add("Пароли не совпадают");
            }
            return View(loginView);
        }
    }
}
