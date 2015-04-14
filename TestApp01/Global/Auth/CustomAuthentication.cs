using Ninject;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Security;
using TestApp01.Model;

namespace TestApp01.Global.Auth
{
    public class CustomAuthentication : IAuthentication
    {
        private static Logger logger = NLog.LogManager.GetCurrentClassLogger();
        private const string cookieName = "_AUTH_COOKIE";
        public HttpContext HttpContext { get; set; }
        [Inject]
        public IRepository Repository { get; set; }
        public User Login(string login, string password, bool isPersistent)
        {
            User retUser = Repository.Login(login, password);
            if(retUser != null)
            {
                CreateCookie(login, isPersistent);
            }
            return retUser;
        }

        public User Login(string login)
        {
            User retUser = Repository.Users.FirstOrDefault(u => string.Compare(u.Email, login, true) == 0);
            if(retUser != null)
            {
                CreateCookie(login);
            }
            return retUser;
        }

        public void Logout()
        {
            var httpCookie = HttpContext.Response.Cookies[cookieName];
            if(httpCookie != null)
            {
                httpCookie.Value = string.Empty;
            }
        }
        private IPrincipal _currentUser;
        public IPrincipal CurrentUser
        {
            get {
                if (_currentUser == null)
                {
                    try
                    {
                        HttpCookie authCookie = HttpContext.Request.Cookies.Get(cookieName);
                        if (authCookie != null && !string.IsNullOrEmpty(authCookie.Value))
                        {
                            var ticket = FormsAuthentication.Decrypt(authCookie.Value);
                            _currentUser = new UserProvider(ticket.Name, Repository);
                        }
                        else
                        {
                            _currentUser = new UserProvider(null, null);
                        }
                    }
                    catch (Exception ex)
                    {
                        logger.Error("Authentication failed: "+ex.Message);
                        _currentUser = new UserProvider(null, null);
                    }
                }
                return _currentUser;
            }
        }
        private void CreateCookie(string userName, bool isPersistent = false)
        {
            var ticket = new FormsAuthenticationTicket(
                1,
                userName,
                DateTime.Now,
                DateTime.Now.Add(FormsAuthentication.Timeout),
                isPersistent,
                string.Empty,
                FormsAuthentication.FormsCookiePath
                );
            var encTicket = FormsAuthentication.Encrypt(ticket);
            var authCookie = new HttpCookie(cookieName) {
                Value = encTicket,
                Expires = DateTime.Now.Add(FormsAuthentication.Timeout)
            };
            HttpContext.Response.SetCookie(authCookie);
        }
    }
}