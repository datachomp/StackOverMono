using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using StructureMap;
using StackOverFaux.Data.Abstract;
using StackOverFaux.Data.Concrete;
using MvcMiniProfiler.MVCHelpers;
using MvcMiniProfiler;

namespace StackOverFaux.Web
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "Default", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                new { controller = "Home", action = "Index", id = UrlParameter.Optional } // Parameter defaults
            );

        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            //HibernatingRhinos.Profiler.Appender.EntityFramework.EntityFrameworkProfiler.Initialize();
            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);
            ViewEngines.Engines.Clear();
            ViewEngines.Engines.Add(new RazorViewEngine());
            //SD.Tools.OrmProfiler.Interceptor.InterceptorCore.Initialize("MicroOrmAppYay");

            //Setup profiler for Controllers via a Global ActionFilter
            GlobalFilters.Filters.Add(new ProfilingActionFilter());
            
            IContainer container = new Container(x =>
            {
                x.For<IBadgeRepository>().Use<SqlBadgeRepository>();
                x.For<IPostRepository>().Use<SqlPostRepository>();
                x.For<ITagRepository>().Use<SqlTagRepository>();
                x.For<IUserRepository>().Use<SqlUserRepository>();
            });

            DependencyResolver.SetResolver(new SmDependencyResolver(container));
        }

        protected void Application_BeginRequest()
        {
            MiniProfiler profiler = null;

            // might want to decide here (or maybe inside the action) whether you want
            // to profile this request - for example, using an "IsSystemAdmin" flag against
            // the user, or similar; this could also all be done in action filters, but this
            // is simple and practical; just return null for most users. For our test, we'll
            // profile only for local requests (seems reasonable)
            //if (Request.IsLocal)
            //{
                profiler = MvcMiniProfiler.MiniProfiler.Start();
            //}

            using (profiler.Step("Application_BeginRequest"))
            {
                // you can start profiling your code immediately
            }
        }

        protected void Application_EndRequest()
        {
            MvcMiniProfiler.MiniProfiler.Stop();
        }
    }
}