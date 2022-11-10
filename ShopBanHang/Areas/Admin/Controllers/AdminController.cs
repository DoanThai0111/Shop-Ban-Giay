using ShopBanHang.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopBanHang.Areas.Admin.Controllers
{
    public class AdminController : Controller
    {
        ShopGiayEntities data = new ShopGiayEntities();
        // GET: Admin/Admin
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(FormCollection f)
        {
            var sTenDN = f["UserName"];
            var sMK = f["PassWord"];
            //admin ad = data.admins.SingleOrDefault(n => n.TenDNAdmin == sTenDN && n.MatKhauAdmin == sMK);
            if (sTenDN == "quanly123" && sMK == "12345")
            {
                //Session["Admin"] = ad;
                return RedirectToAction("Index", "Admin");

            }
            else
            {
                ViewBag.ThongBao = "Tên đăng nhập hoặc mật khẩu không đúng!";
            }
            return View();
        }
    }
}