using Hangfire;
using Hangfire.SqlServer;
using Nomad.App_Start;
using Nomad.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Nomad
{
    public class MvcApplication : Umbraco.Web.UmbracoApplication
    {
        private BackgroundJobServer _backgroundJobServer;
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            //BundleConfig.RegisterBundles(BundleTable.Bundles);
            AutofacConfig.RegisterServices();

        }
        protected override void OnApplicationStarted(object sender, EventArgs e)
        {
            AutofacConfig.RegisterServices();
            JobStorage.Current = new SqlServerStorage("umbracoDbDSN");
            _backgroundJobServer = new BackgroundJobServer();
            RecurringJob.AddOrUpdate(
            () => new PingHelper().Ping(),
            "*/4 * * * *");
            //BundleConfig.RegisterBundles(BundleTable.Bundles);
            base.OnApplicationStarted(sender, e);
        }

        protected override void OnApplicationEnd(object sender, EventArgs e)
        {
            _backgroundJobServer.Dispose();

            base.OnApplicationEnd(sender, e);
        }

    }
}
