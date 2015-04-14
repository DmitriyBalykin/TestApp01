using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using TestApp01.Areas.Admin;
using TestApp01.Areas.Default;

namespace TestApp01
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        private static NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();
        protected void Application_Start()
        {
            logger.Info("Application start");
            logger.Trace("Application start trace");

            RegisterAreas();

            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        private void RegisterAreas()
        {
            var adminArea = new AdminAreaRegistration();
            var adminAreaContext = new AreaRegistrationContext(adminArea.AreaName, RouteTable.Routes);
            adminArea.RegisterArea(adminAreaContext);

            var defaultArea = new DefaultAreaRegistration();
            var defaultAreaContext = new AreaRegistrationContext(defaultArea.AreaName, RouteTable.Routes);
            defaultArea.RegisterArea(defaultAreaContext);
        }
        public override void Init()
        {
            logger.Info("Application init");
        }
        public override void Dispose()
        {
            logger.Info("Application dispose");
        }
        public void Application_Error()
        {
            logger.Info("Application error");
        }
        public void Application_End()
        {
            logger.Info("Application end");
        }
    }
}