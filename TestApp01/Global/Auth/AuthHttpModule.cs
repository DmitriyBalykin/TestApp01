using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TestApp01.Global.Auth
{
    public class AuthHttpModule : IHttpModule
    {

        public void Dispose()
        {}

        public void Init(HttpApplication context)
        {
            context.AuthenticateRequest += new EventHandler(Authenticate);
        }

        void Authenticate(object sender, EventArgs e)
        {
            HttpApplication app = (HttpApplication)sender;
            HttpContext context = app.Context;

            var auth = DependencyResolver.Current.GetService<IAuthentication>();
            auth.HttpContext = context;
            context.User = auth.CurrentUser;
        }
    }
}