using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestApp01.Controllers;
using TestApp01.Model;
using TestApp01.Model.ViewModels;
using TestApp01.Tools;

namespace TestApp01.Areas.Default.Controllers
{
    public class UserController : BaseController
    {
        //
        // GET: /User/
        public ActionResult Index()
        {
            var users = Repository.Users.ToList();
            return View(users);
        }
        public ActionResult Activated()
        {
            var users = Repository.Users.Where(u => u.ActivatedDate != null).ToList();
            return View(users);
        }
        public ActionResult Activate(int? userId)
        {
            if (userId != null)
            {
                var user = Repository.Users.Where(u => u.Id == userId).Single();
                if (user.ActivatedDate == null)
                {
                    user.ActivatedDate = DateTime.Now;
                }
                else
                {
                    user.ActivatedDate = null;
                }
                Repository.UpdateUser(user);
            }
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Register()
        {
            UserView userView = new UserView();
            return View(userView);
        }
        [HttpPost]
        public ActionResult Register(UserView userView)
        {
            if (userView.Captcha != (string)Session[CaptchaImage.CaptchaValueKey])
            {
                ModelState.AddModelError("Captcha", "Текст с картинки введен неверно");
            }
            bool anyUser = Repository.Users.Any(u => string.Compare(u.Email, userView.Email) == 0);
            if(anyUser)
            {
                ModelState.AddModelError("Email","Пользователь с таким Email уже зарегистрирован");
            }
            if(ModelState.IsValid)
            {
                User user = (User)ModelMapper.Map(userView, typeof(UserView), typeof(User));

                Repository.CreateUser(user);
                return RedirectToAction("Index", "Home");
            }
            return View(userView);
        }
        public ActionResult Captcha()
        {
            Session[CaptchaImage.CaptchaValueKey] = new Random(DateTime.Now.Millisecond).Next(1111, 9999).ToString();
            var ci = new CaptchaImage(Session[CaptchaImage.CaptchaValueKey].ToString(), 211, 50, "Arial");

            Response.Clear();
            Response.ContentType = "image/jpeg";

            ci.Image.Save(Response.OutputStream, ImageFormat.Jpeg);

            ci.Dispose();
            return null;
        }
    }
}
