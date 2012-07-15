using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace MvcApplication1
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            var stylesBundle = new StyleBundle("~/all-styles").IncludeDirectory("~/css", "*.css");
            BundleTable.Bundles.Add(stylesBundle);

            //var scriptsBundle = new ScriptBundle("~/base-scripts").Include()
            var scriptBundle = new ScriptBundle("~/framework-js").Include(
                    "~/Scripts/jquery-1.7.2.js",
                    "~/Scripts/underscore.js",
                    "~/Scripts/backbone.js",
                    "~/js/backbone.support.js",
                    "~/Scripts/require.js",
                    "~/js/jsrender.js"
                );
            BundleTable.Bundles.Add(scriptBundle);
        }
    }
}