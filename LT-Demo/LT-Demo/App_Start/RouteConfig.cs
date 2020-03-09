using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace LT_Demo
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Login", action = "Login", id = UrlParameter.Optional },
                //后面是修改过后的
                namespaces: new[] { "LT_Demo.Controllers" }//设置主路由的命名空间，防止与区域Area中控制器名称发生冲突

            ).DataTokens.Add("Area", "LT_Demo");

        }
    }
}
