using LT.BLL;
using LT.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;

namespace LT_Demo.Controllers
{
    public class LoginController : Controller
    {
        public UnitOfWork work = new UnitOfWork();
        //public LTDBContent LTDB = new LTDBContent();
        // GET: Login
        public ActionResult Login()
        {
            return View();
        }

        //登陆验证
        [HttpPost]
        public ActionResult LoginServer() {
            string account = Request.Form["account"];
            string pwd = Request.Form["password"];
            if (account == null || pwd == null) {
                return Content("账号或密码错误");
            }

            //将委托转换成表达式树的形式传入到需要的参数中
            Expression<Func<LTUsers, bool>> expression = u => u.UsersAcount == account
             && u.UsersPwd == pwd;
            var users = work.CreateRespository<LTUsers>().GetEntityFirst(expression);
            //string acc = Request.QueryString["account"]; get读取
            if (users != null) {
                Response.Cookies["usersId"].Value = users.Id.ToString();
                return RedirectToAction("Index", "Home");
            }
            return Content("0");
        }
        //展示数据
        public ActionResult GetEmpList(int page, int limit) {

            Expression<Func<LTCommoditys, bool>> expression = u => u.Id > 0;
            //Expression<Func<LTCommoditys, bool>> orderwher = u => u.Id ==0;
            //List<LTCommoditys> emlist = work.CreateRespository<LTCommoditys>().LoadPageEntities<LTCommoditys>(1, 10, out count, expression, orderbyLambda:u => u, true).ToList() ;

            List<LTCommoditys> emlist = work.CreateRespository<LTCommoditys>().GetEntityList(null, m => m.OrderBy(s => s.Id), includeProperties: "").Skip((page - 1) * limit).Take(limit).ToList();
            int count = work.CreateRespository<LTCommoditys>().LoadEntities(u => u.Id > 0).Count();

            List<Shops> shopslist = work.CreateRespository<Shops>().LoadEntities(u => u.Id > 0).ToList();
            List<LTCommodityTypes> typelist = work.CreateRespository<LTCommodityTypes>().LoadEntities(u => u.Id > 0).ToList();

            var que = from list in emlist
                      join list2 in shopslist on list.ShopsId equals list2.Id
                      join list3 in typelist on list.TypeId equals list3.Id
                      select new
                      {
                          Id = list.Id,
                          ShopName = list2.ShowName,
                          ShopNum = list2.ShopNum,
                          Name = list.CommodityName,
                          Price = list.Price,
                          TypeName = list3.Name,
                      };


            //int total = unit.CreateRespository<Menus>().GetCount(null);
            return Json(new { code = 0, msg = "", count = count, data = que }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult ShowData() {
            //分布视图使用2
            //return View("~/Views/Shared/layout2.cshtml");
            return View();
        }

        //删除
        [HttpPost]
        public ActionResult Delete(int id) {
            try
            {
                var list = work.CreateRespository<LTCommoditys>().GetEntityById(id);
                if (work.CreateRespository<LTCommoditys>().DeleteEntity(list))
                {
                    return Json(new { code = 0, msg = "ok" });
                }
            }
            catch (Exception ex)
            {
                return Json(new { code = 1, msg = "错误:" +ex.Message});
            }
            return Json(new { code = 1, msg = "no" });
        }

        //编辑

        public ActionResult Edit(int id) {
            LTCommoditys lTCommoditys = work.CreateRespository<LTCommoditys>().GetEntityById(id);

            List<LTCommodityTypes> lTCommodityTypes = work.CreateRespository<LTCommodityTypes>().LoadEntities(u => u.Id>0).ToList();

            Shops shops = work.CreateRespository<Shops>().GetEntityById(lTCommoditys.ShopsId);

            ViewBag.Commoditys = lTCommoditys;
            ViewBag.CommodityTypes = lTCommodityTypes;
            ViewBag.shop = shops;

            return View();
        }
        [HttpPost]
        public ActionResult UpdateMethod() {

            var shop = work.CreateRespository<Shops>().GetEntityById(2);
            shop.SalesNum = 3000;
            shop.ShopLog = "D:\\";
            shop.ShowName = "海澜之家";
            shop.Descript = "修改练习";
            shop.BackgroundImage = "asfasasf";
            if (work.CreateRespository<Shops>().EditEntity(shop)) {
                return Content("修改成功");
            }

            return Content("修改失败");
        }

    }
}