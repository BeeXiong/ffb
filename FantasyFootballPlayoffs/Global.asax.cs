using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Microsoft.AspNet.SignalR;

namespace FantasyFootballPlayoffs
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            GlobalHost.Configuration.DisconnectTimeout = TimeSpan.FromSeconds(15);
            GlobalHost.Configuration.KeepAlive = TimeSpan.FromSeconds(5);
        }
        //protected void Application_BeginRequest()
        //{
        //    HttpRequestBase request = new HttpRequestWrapper(Context.Request);
        //    if (request.IsAjaxRequest())
        //    {
        //        Context.Response.SuppressFormsAuthenticationRedirect = true;
        //    }
        //}
    }
}
