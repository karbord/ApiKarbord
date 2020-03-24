using ApiKarbord.Controllers.Unit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ApiKarbord.Controllers
{
    public class HomeController : Controller
    {
        // GET: HomeApi
        public ActionResult Index()
        {
            if (!UnitDatabase.TestSqlServer(true))
            {
                return JavaScript(UnitSweet2.ShowMessage(1, "خطا در اتصال", ""));
            }
            return View();
        }


        //نمایش اطلاعات اتصال به دیتابیس 
        public ActionResult AddSqlServer()
        {
            ViewBag.serverName = UnitPublic.MyIni.Read("serverName");
            ViewBag.userName = UnitPublic.MyIni.Read("userName");
            ViewBag.password = UnitPublic.MyIni.Read("password");
            return View();
        }

        //ثبت و ویرایش اطلاعات اتصال به دیتابیس
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddSqlServer(string serverName, string userName, string password)
        {
            //ذخیره اطلاعات اس کیو ال در فایل ای ان ای در سرور
            if (string.IsNullOrEmpty(serverName)) return JavaScript(UnitSweet2.ShowMessage(3, "خطا در ورود اطلاعات", "نام سرور را وارد کنید"));
            if (string.IsNullOrEmpty(userName)) return JavaScript(UnitSweet2.ShowMessage(3, "خطا در ورود اطلاعات", "نام کاربری را وارد کنید"));
            if (string.IsNullOrEmpty(password)) return JavaScript(UnitSweet2.ShowMessage(3, "خطا در ورود اطلاعات", "کلمه عبور را وارد کنید"));
            UnitPublic.MyIni.Write("serverName", serverName);
            UnitPublic.MyIni.Write("userName", userName);
            UnitPublic.MyIni.Write("password", password);
            try
            {
                if (!UnitDatabase.TestSqlServer(true))
                {
                    return JavaScript(UnitSweet2.ShowMessage(1, "خطا در اتصال", "دوباره سعی کنید"));
                }
                return JavaScript(UnitSweet2.ShowMessage(0, "ذخیره شد", ""));
            }
            catch (Exception)
            {
                return JavaScript(UnitSweet2.ShowMessage(1, "خطا در اتصال", "دوباره سعی کنید"));
                throw;
            }
        }
    }
}