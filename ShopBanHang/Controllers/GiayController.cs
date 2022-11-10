using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using ShopBanHang.Models;
using PagedList;
using PagedList.Mvc;
namespace ShopBanHang.Controllers
{
    public class GiayController : Controller
    {
       private ShopGiayEntities data = new ShopGiayEntities();
        // GET: Giay
        public ActionResult LoginLogout()
        {
            return PartialView("LoginLogoutPartial");
        }
        public ActionResult Index()
        {
            return View(data.giays.Take(9));
        }
        public ActionResult Chude()
        {
            var chude = from CD in data.chudes select CD;
            return PartialView(chude);
        }

        public ActionResult GiayTheoChuDe(int id, int? page)
        {
            ViewBag.MaCD = id;
            int iSize = 3;
            int iPageNum = (page ?? 1);
            var giay = from s in data.giays where s.MaCD == id orderby id select s;
            return View(giay.ToPagedList(iPageNum, iSize));
        }
        public ActionResult Chitietgiay(int id)
        {
            var giay = from s in data.giays
                       where s.MaGiay == id
                       select s;
            return View(giay.Single());
        }
    }
}