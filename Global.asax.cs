using Stripe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Event_Mangement
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            // Configure Stripe API keys
            StripeConfiguration.ApiKey = "pk_test_51OJz1nSECvCDJkxtTPJxmcBFVURo0ivBk47lJzGGlrXgSMs8eEFaeVtcGfRYIwEZa0jaXCsVKOrq4BVGoOxqrPu700bEPiwN7L";
        }
    }
}
