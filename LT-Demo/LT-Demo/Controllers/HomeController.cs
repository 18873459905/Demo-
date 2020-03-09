using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LT.Model;
using LT.IBLL;
using LT.BLL;
namespace LT_Demo.Controllers
{
    public class HomeController : Controller
    {
        public UnitOfWork work = new UnitOfWork();
        public ActionResult Index()
        {
            //DBContent content = new DBContent();
            //List<string> list = new List<string>();
            //foreach (var item in content.LTUsers)
            //{
            //    list.Add(item.UsersAcount);
            //}

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}