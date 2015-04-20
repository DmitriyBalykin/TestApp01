using System.Web;
using System.Web.Optimization;

namespace TestApp01
{
    public class BundleConfig
    {
        // For more information on Bundling, visit http://go.microsoft.com/fwlink/?LinkId=254725
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));
            
            bundles.Add(new ScriptBundle("~/bundles/bootstrap")
                .Include("~/Scripts/bootstrap*"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryui")
                .Include("~/Scripts/jquery-ui*"));

            bundles.Add(new ScriptBundle("~/bundles/common")
                .Include("~/Scripts/common.js"));

            bundles.Add(new StyleBundle("~/Content/css")
                .Include("~/Content/bootstrap*")
                .Include("~/Content/site.css"));

            bundles.Add(new StyleBundle("~/Content/css/jqueryui")
                .Include("~/Content/css/jquery-ui*"));

            //BundleTable.EnableOptimizations = true;
        }
    }
}